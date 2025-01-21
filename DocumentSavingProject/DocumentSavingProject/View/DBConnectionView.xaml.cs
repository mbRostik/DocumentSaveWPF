using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DocumentSavingProject.ViewModel;

namespace DocumentSavingProject.View
{
    /// <summary>
    /// Interaction logic for DBConnectionView.xaml
    /// </summary>
    public partial class DBConnectionView : Window
    {
        public DBConnectionView(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new AddDatabaseViewModel(serviceProvider);  
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                var viewModel = DataContext as AddDatabaseViewModel;
                if (viewModel != null)
                {
                    viewModel.Password = passwordBox.Password; 
                }
            }
        }
    }
}
