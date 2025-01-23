using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL.BLL_Models;

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


        private readonly IServiceProvider _serviceProvider;
        public ShowCoupledUsersViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            FewUsersCollection = StaticInfo.fewUsersCollection;
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
