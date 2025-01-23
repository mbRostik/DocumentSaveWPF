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
using BLL.BLL_Models;
using DocumentSavingProject.Converters;
using DocumentSavingProject.Helpers;
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

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            bool isMaximized = this.WindowState == WindowState.Maximized;

            if (isMaximized)
            {
                base.OnClosing(e);
                if (Helper.IsWindowOpen<ShowCoupledUsersWindow>())
                {
                    Helper.CloseExternalWindow<ShowCoupledUsersWindow>();
                }
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    Application.Current.MainWindow.Show();
                }
            }
            else
            {
                StaticInfo.Width = this.ActualWidth;
                StaticInfo.Height = this.ActualHeight;
                if (Helper.IsWindowOpen<ShowCoupledUsersWindow>())
                {
                    Helper.CloseExternalWindow<ShowCoupledUsersWindow>();
                }
                base.OnClosing(e);


                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                    Application.Current.MainWindow.Hide();
                    Application.Current.MainWindow.Height = StaticInfo.Height;
                    Application.Current.MainWindow.Width = StaticInfo.Width;
                    Application.Current.MainWindow.Left = this.Left;
                    Application.Current.MainWindow.Top = this.Top;
                    Application.Current.MainWindow.UpdateLayout();
                    Application.Current.MainWindow.Show();
                }
            }

        }

        protected void OnBackButtonClick(object sender, MouseButtonEventArgs e)
        {

            bool isMaximized = this.WindowState == WindowState.Maximized;

            if (isMaximized)
            {
                if (Helper.IsWindowOpen<ShowCoupledUsersWindow>())
                {
                    Helper.CloseExternalWindow<ShowCoupledUsersWindow>();
                }
                this.Close();

                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    Application.Current.MainWindow.Show();
                }
            }
            else
            {
                StaticInfo.Width = this.ActualWidth;
                StaticInfo.Height = this.ActualHeight;

                this.Close();

                if (Helper.IsWindowOpen<ShowCoupledUsersWindow>())
                {
                    Helper.CloseExternalWindow<ShowCoupledUsersWindow>();
                }

                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Hide();
                    Application.Current.MainWindow.Height = StaticInfo.Height;
                    Application.Current.MainWindow.Width = StaticInfo.Width;
                    Application.Current.MainWindow.Left = this.Left;
                    Application.Current.MainWindow.Top = this.Top;
                    Application.Current.MainWindow.UpdateLayout();
                    Application.Current.MainWindow.Show();
                }
            }
        }

    }
}
