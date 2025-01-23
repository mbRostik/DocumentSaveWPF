
using System.Windows;
using BLL.BLL_Models;
using DocumentSavingProject.View;
using DocumentSavingProject.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentSavingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            DataContext = new MainWindowViewModel();
            if (StaticInfo.Width > 0 && StaticInfo.Height > 0)
            {
                this.Width = StaticInfo.Width;
                this.Height = StaticInfo.Height;
            }

        }

        private void OpenAddDatabaseView(object sender, RoutedEventArgs e)
        {
            bool isMaximized = this.WindowState == WindowState.Maximized;
            var addDatabaseView = _serviceProvider.GetRequiredService<DBConnectionView>();
            if (isMaximized)
            {
                addDatabaseView.WindowState = WindowState.Maximized;
            }
            else
            {
                StaticInfo.Width = this.ActualWidth;
                StaticInfo.Height = this.ActualHeight;
                addDatabaseView.Width = StaticInfo.Width;
                addDatabaseView.Height = StaticInfo.Height;
                addDatabaseView.Left = this.Left;
                addDatabaseView.Top = this.Top;
            }
            addDatabaseView.Show();
            this.Hide();

        }
        private void OpenMoveFilesView(object sender, RoutedEventArgs e)
        {
            bool isMaximized = this.WindowState == WindowState.Maximized;
            var moveFilesView = _serviceProvider.GetRequiredService<MoveFilesView>();

            if (isMaximized)
            {
                moveFilesView.WindowState = WindowState.Maximized;
            }
            else
            {
                StaticInfo.Width = this.ActualWidth;
                StaticInfo.Height = this.ActualHeight;
                moveFilesView.Width = StaticInfo.Width;
                moveFilesView.Height = StaticInfo.Height;
                moveFilesView.Left = this.Left;
                moveFilesView.Top = this.Top;
                
            }
            moveFilesView.Show();
            this.Hide();
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
    }
}