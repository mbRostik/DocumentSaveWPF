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
using DocumentSavingProject.View;
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
        }

        private void OpenAddDatabaseView(object sender, RoutedEventArgs e)
        {
            var addDatabaseView = _serviceProvider.GetRequiredService<DBConnectionView>();
            addDatabaseView.Show();
        }
    }
}