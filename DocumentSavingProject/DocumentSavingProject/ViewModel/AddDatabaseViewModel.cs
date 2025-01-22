using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL.BLL_Models;
using BLL.Managers;
using GalaSoft.MvvmLight.Command;

namespace DocumentSavingProject.ViewModel
{
    public class AddDatabaseViewModel : INotifyPropertyChanged
    {
        private string _serverName;
        private string _databaseName;
        private string _username;
        private string _password;
        private bool _trustServerCertificate;
        private string _statusMessage;
        private bool _isLoading;

        private readonly IServiceProvider _serviceProvider;

        public string ServerName
        {
            get => _serverName;
            set { _serverName = value; OnPropertyChanged(); }
        }

        public string DatabaseName
        {
            get => _databaseName;
            set { _databaseName = value; OnPropertyChanged(); }
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public bool TrustServerCertificate
        {
            get => _trustServerCertificate;
            set { _trustServerCertificate = value; OnPropertyChanged(); }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public RelayCommand TestConnectionCommand { get; set; }

        public AddDatabaseViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            TestConnectionCommand = new RelayCommand(async () => await TestConnection());
        }

        public async Task TestConnection()
        {
            StatusMessage = string.Empty;
            IsLoading = true;  

            var config = new DatabaseConfig
            {
                ServerName = ServerName,
                DatabaseName = DatabaseName,
                Username = Username,
                Password = Password,
                TrustServerCertificate = TrustServerCertificate
            };

            string connectionString = ConnectionTester.BuildConnectionString(config);

            if (await ConnectionTester.TestConnectionAsync(connectionString, _serviceProvider, config))
            {
                StatusMessage = "Connection successful!";
            }
            else
            {
                StatusMessage = "Connection failed. Please check the details.";
            }

            IsLoading = false;  
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
