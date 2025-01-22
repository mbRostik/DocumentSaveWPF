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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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


        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public RelayCommand BrowseCommand { get; set; }
        public RelayCommand MoveFilesCommand { get; set; }

        private readonly IServiceProvider _serviceProvider;

        public MoveFilesViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            BrowseCommand = new RelayCommand(OpenFolderDialog);
            MoveFilesCommand = new RelayCommand(async () => await MoveFilesAsync());
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
                        FileName = Path.GetFileName(file)
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
            IsLoading = false;
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
                            SELECT PROGRESSIVO, ENTE, NOME, COGNOME
                            FROM ANAGDIP 
                            WHERE COGNOME = @Name";

                        var results = (await connection.QueryAsync<(int PROGRESSIVO, string ENTE, string NOME, string COGNOME)>(query,
                                        new { Name = fileDetails.Name }, transaction)).ToList();

                        if (results.Count == 0 || results.Count > 1)
                        {
                            transaction.Rollback();
                            return false;
                        }

                        var result = results.First();

                        const string insertQuery = @"
                    INSERT INTO DOCUMENTO_UPLOAD (ENTE, ANNO, MESE, SUBMESE, [FILE], FILENAME, EXTENSION, DENOMINAZIONE) OUTPUT INSERTED.ID
                    VALUES (@ENTE, @ANNO, @MESE, @SUBMESE, @FILE, @FILENAME, @EXTENSION, @DENOMINAZIONE)";

                        string Descritption = result.COGNOME + ' ' + result.NOME + ' ' + fileDetails.Month + ' ' + fileDetails.Year;
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

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error: {ex.Message}");
                        return false;
                    }
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private class FileDetails
        {
            public byte[] Data { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public string FileExtension { get; set; }
            public string FileName { get; set; }
        }
    }
}
