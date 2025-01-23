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
using DocumentSavingProject.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentSavingProject.View
{
    /// <summary>
    /// Interaction logic for ShowCoupledUsersWindow.xaml
    /// </summary>
    public partial class ShowCoupledUsersWindow : Window
    {
        public ShowCoupledUsersWindow(IServiceProvider serviceProvider)
        {
            this.Width = StaticInfo.Width;
            this.Height = StaticInfo.Height;
            InitializeComponent();
            DataContext = new ShowCoupledUsersViewModel(serviceProvider);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            StaticInfo.fewUsersCollection.Clear();
            base.OnClosing(e);

        }

        private void OnBackButtonClick(object sender, MouseButtonEventArgs e)
        {
            StaticInfo.fewUsersCollection.Clear();
            this.Close();
        }
    }
}
