using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL.BLL_Models;

namespace DocumentSavingProject.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            StaticInfo.OnCurrentConnectionStringChanged += () => OnPropertyChanged(nameof(CurrentConnectionString));
        }

        public string CurrentConnectionString => StaticInfo.CurrentConnectionString;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
