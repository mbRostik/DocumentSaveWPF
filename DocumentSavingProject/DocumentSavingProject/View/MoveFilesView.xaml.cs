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
using Microsoft.Extensions.DependencyInjection;
using DocumentSavingProject.Converters;

namespace DocumentSavingProject.View
{
    /// <summary>
    /// Interaction logic for MoveFilesView.xaml
    /// </summary>
    public partial class MoveFilesView : Window
    {
        public MoveFilesView(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new MoveFilesViewModel(serviceProvider);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Show();
            }
        }
    }
}
