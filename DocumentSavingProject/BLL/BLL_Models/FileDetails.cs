using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Models
{
    public class FileDetails : INotifyPropertyChanged
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }

        private bool _isUserSelected;
        public bool IsUserSelected
        {
            get => _isUserSelected;
            set
            {
                _isUserSelected = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
