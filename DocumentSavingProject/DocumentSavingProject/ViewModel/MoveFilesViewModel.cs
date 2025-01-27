using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLL.BLL_Models;
using CommunityToolkit.Mvvm.Input;
using DAL;
using Dapper;
using DocumentSavingProject.Helpers;
using DocumentSavingProject.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.WindowsAPICodePack.Dialogs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DocumentSavingProject.ViewModel

{
    public class MoveFilesViewModel : INotifyPropertyChanged
    {
        private string _selectedPath;
        private bool _isLoading;
        private ObservableCollection<string> _skippedFiles = new();
        private ObservableCollection<string> _notAddedToDbFiles = new();
        private ObservableCollection<string> _addedToDbFiles = new();

        

        public ObservableCollection<string> AddedToDbFiles
        {
            get => _addedToDbFiles;
            set { _addedToDbFiles = value; OnPropertyChanged(); }
        }
        public ObservableCollection<string> SkippedFiles
        {
            get => _skippedFiles;
            set { _skippedFiles = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> NotAddedToDbFiles
        {
            get => _notAddedToDbFiles;
            set { _notAddedToDbFiles = value; OnPropertyChanged(); }
        }

        public string SelectedPath
        {
            get => _selectedPath;
            set { _selectedPath = value; OnPropertyChanged(); }
        }

        public string DatabaseConfigSummary
        {
            get
            {
                if (StaticInfo.CurrentDatabaseConfig != null)
                {
                    var config = StaticInfo.CurrentDatabaseConfig;
                    return $"Server: {config.ServerName}, Database: {config.DatabaseName}";
                }
                return "No database configuration found.";
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public RelayCommand BrowseCommand { get; set; }
        public RelayCommand MoveFilesCommand { get; set; }

        private readonly IServiceProvider _serviceProvider;

        private ObservableCollection<string> _fileStructures;
        private string _selectedFileStructure;

        public ObservableCollection<string> FileStructures
        {
            get => _fileStructures;
            set { _fileStructures = value; OnPropertyChanged(); }
        }

        public string SelectedFileStructure
        {
            get => _selectedFileStructure;
            set { _selectedFileStructure = value; OnPropertyChanged(); }
        }

        public MoveFilesViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            BrowseCommand = new RelayCommand(OpenFolderDialog);
            MoveFilesCommand = new RelayCommand(async () => await MoveFilesAsync());
            FileStructures = new ObservableCollection<string>
            {
                "COGNONOME ANNO MESE"
            };

            SelectedFileStructure = FileStructures[0];
        }

        private void OpenFolderDialog()
        {
            SkippedFiles.Clear();
            NotAddedToDbFiles.Clear();
            AddedToDbFiles.Clear();
            using (var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            })
            {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    SelectedPath = dialog.FileName;
                }
            }
        }

        private async Task MoveFilesAsync()
        {
            if (Helper.IsWindowOpen<ShowCoupledUsersWindow>())
            {
                Helper.CloseExternalWindow<ShowCoupledUsersWindow>();
            }

            IsLoading = true;
            SkippedFiles.Clear();
            NotAddedToDbFiles.Clear();
            AddedToDbFiles.Clear();

            if (string.IsNullOrWhiteSpace(SelectedPath) || !Directory.Exists(SelectedPath))
            {
                IsLoading = false;
                return;
            }

            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsBuilder.UseSqlServer(StaticInfo.CurrentConnectionString);

            using var context = new DataBaseContext(optionsBuilder.Options);

            var files = Directory.GetFiles(SelectedPath);
            SelectedPath = null;
            foreach (var file in files)
            {
                try
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var parts = fileName.Split(' ');
                    if (parts.Length < 3)
                    {
                        SkippedFiles.Add(fileName);
                        OnPropertyChanged(nameof(SkippedFiles));
                        continue;
                    }

                    var name = parts[0];
                    var year = int.TryParse(parts[1], out var parsedYear) ? parsedYear : 0;
                    var month = int.TryParse(parts[2], out var parsedMonth) ? parsedMonth : 0;

                    if (year <= 0 || month <= 0 || month > 12)
                    {
                        SkippedFiles.Add(fileName);
                        OnPropertyChanged(nameof(SkippedFiles));
                        continue;
                    }



                    var fileContent = await File.ReadAllBytesAsync(file);
                    var fileDetails = new FileDetails
                    {
                        Name = name,
                        Year = year,
                        Month = month,
                        Data = fileContent,
                        FileExtension = Path.GetExtension(file),
                        FileName = fileName
                    };

                    var addedToDb = await AddFileToDatabaseAsync(fileDetails, context);
                    if (addedToDb)
                    {
                        AddedToDbFiles.Add(fileName);
                        
                    }
                    else
                    {
                        NotAddedToDbFiles.Add(fileName);
                    }
                }
                catch (Exception ex)
                {
                    SkippedFiles.Add(Path.GetFileName(file));
                    

                }
            }
            await context.Database.CloseConnectionAsync();
            files = null;
            IsLoading = false;

            if (!StaticInfo.fewUsersCollection.IsNullOrEmpty())
            {
                var showCoupledUsers = _serviceProvider.GetRequiredService<ShowCoupledUsersWindow>();
                showCoupledUsers.Show();
            }
        }

        private async Task<bool> AddFileToDatabaseAsync(FileDetails fileDetails, DataBaseContext context)
        {

            using (var connection = context.Database.GetDbConnection())
            {
                connection.ConnectionString = StaticInfo.CurrentConnectionString;
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        const string query = @"
                            SELECT PROGRESSIVO, ENTE, NOME, COGNOME, CODFISC
                            FROM ANAGDIP 
                            WHERE COGNOME = @Name";

                        var results = (await connection.QueryAsync<(int PROGRESSIVO, int ENTE, string NOME, string COGNOME, string CODFISC)>(query,
                                        new { Name = fileDetails.Name }, transaction)).ToList();

                        if (results.Count == 0)
                        {
                            transaction.Rollback();
                            return false;
                        }

                        if (results.Count > 1)
                        {
                            var fileUsers = results.Select(r => new FileUser
                            {
                                ENTE = r.ENTE,
                                Name = r.NOME,
                                SurName = r.COGNOME,
                                PROGRESSIVO = r.PROGRESSIVO,
                                CODFISC=r.CODFISC
                            }).ToList();

                            StaticInfo.fewUsersCollection.Add(new Dictionary<FileDetails, List<FileUser>>
                            {
                                { fileDetails, fileUsers }
                            });

                            transaction.Rollback(); 
                            return false;
                        }

                        var result = results.First();

                        const string insertQuery = @"
                    INSERT INTO DOCUMENTO_UPLOAD (ENTE, ANNO, MESE, SUBMESE, [FILE], FILENAME, EXTENSION, DENOMINAZIONE) OUTPUT INSERTED.ID
                    VALUES (@ENTE, @ANNO, @MESE, @SUBMESE, @FILE, @FILENAME, @EXTENSION, @DENOMINAZIONE)";

                        string Descritption = result.COGNOME + ' ' + result.NOME + ' ' + fileDetails.Month + ' ' + fileDetails.Year;

                        const string checkFileExistsQuery = @"
                        SELECT COUNT(*)
                        FROM DOCUMENTO_UPLOAD
                        WHERE FILENAME = @FILENAME AND ANNO = @ANNO AND MESE = @MESE AND EXTENSION = @EXTENSION AND ENTE=@ENTE";
                        var fileExists = await connection.ExecuteScalarAsync<int>(checkFileExistsQuery, new
                        {
                            FILENAME = fileDetails.FileName,
                            ANNO = fileDetails.Year,
                            MESE = fileDetails.Month,
                            EXTENSION = fileDetails.FileExtension,
                            ENTE = result.ENTE
                        }, transaction);

                        if (fileExists <= 0)
                        {
                            var insertedRecordId = await connection.QuerySingleOrDefaultAsync<int>(insertQuery, new
                            {
                                ENTE = result.ENTE,
                                ANNO = fileDetails.Year,
                                MESE = fileDetails.Month,
                                SUBMESE = (int?)null,
                                FILE = fileDetails.Data,
                                FILENAME = fileDetails.FileName,
                                EXTENSION = fileDetails.FileExtension,
                                DENOMINAZIONE = Descritption
                            }, transaction);

                            const string insertLinkTableQuery = @"
                                INSERT INTO DOCUMENTO_UPLOAD_DIPENDENTE (ID, DIPENDENTE)
                                VALUES (@ID, @DIPENDENTE)";

                            await connection.ExecuteAsync(insertLinkTableQuery, new
                            {
                                ID = insertedRecordId,
                                DIPENDENTE = result.PROGRESSIVO
                            }, transaction);
                        }
                        else
                        {
                            const string updateQuery = @"
                            UPDATE DOCUMENTO_UPLOAD
                            SET 
                                SUBMESE = @SUBMESE,
                                [FILE] = @FILE,
                                DENOMINAZIONE = @DENOMINAZIONE
                            WHERE FILENAME = @FILENAME AND ANNO = @ANNO AND MESE = @MESE AND EXTENSION = @EXTENSION";

                            await connection.ExecuteAsync(updateQuery, new
                            {
                                ENTE = result.ENTE,
                                SUBMESE = (int?)null,
                                FILE = fileDetails.Data,
                                DENOMINAZIONE = Descritption,
                                FILENAME = fileDetails.FileName,
                                ANNO = fileDetails.Year,
                                MESE = fileDetails.Month,
                                EXTENSION = fileDetails.FileExtension
                            }, transaction);
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
