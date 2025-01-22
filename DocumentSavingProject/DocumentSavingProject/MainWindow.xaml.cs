using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

        }

        private void OpenAddDatabaseView(object sender, RoutedEventArgs e)
        {
            var addDatabaseView = _serviceProvider.GetRequiredService<DBConnectionView>();
            addDatabaseView.Show();
            this.Hide();
        }
        private void OpenMoveFilesView(object sender, RoutedEventArgs e)
        {
            var moveFilesView = _serviceProvider.GetRequiredService<MoveFilesView>();
            moveFilesView.Show();
            this.Hide();
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
    }
}