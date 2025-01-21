using System.Configuration;
using System.Data;
using System.Windows;
using DAL;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            _host = Host.CreateDefaultBuilder()
              .ConfigureServices((hostBuilderContext, serviceCollection) =>
              {
                  serviceCollection.AddDbContext<DataBaseContext>(options =>
                  {
                      options.UseSqlServer("");
                  }, ServiceLifetime.Singleton);
                  //serviceCollection.AddSingleton<MainWindow>();


              })
              .Build();

            _host.Start();

            //MainWindow = _host.Services.GetRequiredService<MainWindow>();
            //MainWindow.Show();

            base.OnStartup(e);
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
