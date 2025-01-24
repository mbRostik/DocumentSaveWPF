using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using BLL.BLL_Models;
using BLL.Managers;
using DAL;
using DocumentSavingProject.View;
using DocumentSavingProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DocumentSavingProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                _host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                {
                    serviceCollection.AddDbContext<DataBaseContext>(options =>
                    {
                        options.UseSqlServer(StaticInfo.CurrentConnectionString);
                    }, ServiceLifetime.Scoped);

                    serviceCollection.AddSingleton<MainWindow>();
                    serviceCollection.AddTransient<DBConnectionView>();
                    serviceCollection.AddTransient<AddDatabaseViewModel>();
                    serviceCollection.AddTransient<MoveFilesView>();
                    serviceCollection.AddTransient<MoveFilesViewModel>();
                    serviceCollection.AddTransient<ShowCoupledUsersWindow>();


                })
                .Build();

                _host.Start();

                var mainWindow = _host.Services.GetRequiredService<MainWindow>();
                MainWindow = mainWindow;
                mainWindow.Show();
            }
            catch(Exception ex)
            {
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");

                File.AppendAllText(logFilePath, $"[{DateTime.Now}] {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}{Environment.NewLine}");

                MessageBox.Show("An unexpected error occurred. Please check the error log for details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override async void OnExit(ExitEventArgs e)
        {

            if (_host != null)
            {
                await _host.StopAsync();
                _host.Dispose();
            }

            base.OnExit(e);
        }
    }

}
