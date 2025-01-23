using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BLL.BLL_Models;
using CommunityToolkit.Mvvm.Input;
using DAL;
using System.Windows;
using Dapper;
using DocumentSavingProject.View;
using Microsoft.EntityFrameworkCore;
using MS.WindowsAPICodePack.Internal;
using DocumentSavingProject.Helpers;

namespace DocumentSavingProject.ViewModel
{
    public class ShowCoupledUsersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Dictionary<FileDetails, List<FileUser>>> _fewUsersCollection;

        public ObservableCollection<Dictionary<FileDetails, List<FileUser>>> FewUsersCollection
        {
            get => _fewUsersCollection;
            set
            {
                _fewUsersCollection = value;
                OnPropertyChanged();
                UpdateFileDetailsList();
            }
        }

        private ObservableCollection<FileDetails> _fewUsersCollectionKeys = new();
        public ObservableCollection<FileDetails> FewUsersCollectionKeys
        {
            get => _fewUsersCollectionKeys;
            set
            {
                _fewUsersCollectionKeys = value;
                OnPropertyChanged();
            }
        }

        private FileDetails _selectedFile;
        public FileDetails SelectedFile
        {
            get => _selectedFile;
            set
            {
                _selectedFile = value;
                OnPropertyChanged();
                UpdateSelectedFileUsers();
            }
        }

        private ObservableCollection<FileUser> _selectedFileUsers = new();
        public ObservableCollection<FileUser> SelectedFileUsers
        {
            get => _selectedFileUsers;
            set
            {
                _selectedFileUsers = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<FileDetails, FileUser> _fileUserSelections = new();
        public Dictionary<FileDetails, FileUser> FileUserSelections
        {
            get => _fileUserSelections;
            set
            {
                _fileUserSelections = value;
                OnPropertyChanged();
            }
        }

        private FileUser _selectedFileUser;
        public FileUser SelectedFileUser
        {
            get => _selectedFileUser;
            set
            {
                if (_selectedFileUser == value)
                {
                    _selectedFileUser = null;

                    OnPropertyChanged(nameof(SelectedFileUser));
                }
                else
                {
                    _selectedFileUser = value;
                }

                OnPropertyChanged();
                UpdateFileUserSelection();
            }
        }

        public ICommand RemoveUserCommand { get; }
        private readonly IServiceProvider _serviceProvider;
        public RelayCommand ConfirmUserListCommand { get; set; }
        public ShowCoupledUsersViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            FewUsersCollection = StaticInfo.fewUsersCollection;
            RemoveUserCommand = new RelayCommand<FileUser>(RemoveUser);
            ConfirmUserListCommand = new RelayCommand(async () => await ConfirmUserList());
        }
        private void RemoveUser(FileUser user)
        {
            if (SelectedFile != null && FileUserSelections.ContainsKey(SelectedFile))
            {
                if (FileUserSelections[SelectedFile] == user)
                {
                    FileUserSelections.Remove(SelectedFile);
                }

                UpdateSelectedFileUsers();
            }
        }

        private async Task ConfirmUserList()
        {
            if(FileUserSelections != null && FileUserSelections.Any())
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
                optionsBuilder.UseSqlServer(StaticInfo.CurrentConnectionString);

                using var context = new DataBaseContext(optionsBuilder.Options);

                foreach (var item in FileUserSelections)
                {
                    using (var connection = context.Database.GetDbConnection())
                    {
                        connection.ConnectionString = StaticInfo.CurrentConnectionString;
                        if (connection.State == ConnectionState.Closed)
                            await connection.OpenAsync();

                        using (var transaction = connection.BeginTransaction())
                        {
                            const string insertQuery = @"
                    INSERT INTO DOCUMENTO_UPLOAD (ENTE, ANNO, MESE, SUBMESE, [FILE], FILENAME, EXTENSION, DENOMINAZIONE) OUTPUT INSERTED.ID
                    VALUES (@ENTE, @ANNO, @MESE, @SUBMESE, @FILE, @FILENAME, @EXTENSION, @DENOMINAZIONE)"
                            ;

                            string Descritption = item.Value.Name + ' ' + item.Value.SurName + ' ' + item.Key.Month + ' ' + item.Key.Year;

                            var insertedRecordId = await connection.QuerySingleOrDefaultAsync<int>(insertQuery, new
                            {
                                ENTE = item.Value.ENTE,
                                ANNO = item.Key.Year,
                                MESE = item.Key.Month,
                                SUBMESE = (int?)null,
                                FILE = item.Key.Data,
                                FILENAME = item.Key.FileName,
                                EXTENSION = item.Key.FileExtension,
                                DENOMINAZIONE = Descritption
                            }, transaction);

                            const string insertLinkTableQuery = @"
                        INSERT INTO DOCUMENTO_UPLOAD_DIPENDENTE (ID, DIPENDENTE)
                        VALUES (@ID, @DIPENDENTE)";

                            await connection.ExecuteAsync(insertLinkTableQuery, new
                            {
                                ID = insertedRecordId,
                                DIPENDENTE = item.Value.PROGRESSIVO
                            }, transaction);

                            transaction.Commit();

                            Application.Current.Windows.OfType<MoveFilesView>().FirstOrDefault().FileWithMultUsersAdd(item.Key.FileName);

                        }
                    }
                }

                
            }
            Helper.CloseExternalWindow<ShowCoupledUsersWindow>();
        }
        private void UpdateFileUserSelection()
        {
            if (SelectedFile != null && SelectedFileUser != null)
            {
                if (FileUserSelections.ContainsKey(SelectedFile))
                {
                    FileUserSelections[SelectedFile] = SelectedFileUser;
                }
                else
                {
                    FileUserSelections.Add(SelectedFile, SelectedFileUser);
                }
            }
        }
        private void UpdateFileDetailsList()
        {
            FewUsersCollectionKeys = new ObservableCollection<FileDetails>(
                FewUsersCollection.SelectMany(d => d.Keys));
        }

        private void UpdateSelectedFileUsers()
        {
            if (SelectedFile != null)
            {
                // Update the list of users for the selected file
                var users = FewUsersCollection
                    .Where(d => d.ContainsKey(SelectedFile))
                    .SelectMany(d => d[SelectedFile])
                    .ToList();

                SelectedFileUsers = new ObservableCollection<FileUser>(users);

                // Check if a user was previously selected for this file
                if (FileUserSelections.ContainsKey(SelectedFile))
                {
                    SelectedFileUser = FileUserSelections[SelectedFile];
                }
                else
                {
                    SelectedFileUser = null;
                }
            }
            else
            {
                SelectedFileUsers.Clear();
                SelectedFileUser = null;
            }
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
