using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BLL_Models;
using System.Windows.Data;
using System.Windows;

namespace DocumentSavingProject.Converters
{
    public class FileUserSelectedMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 &&
                values[0] is Dictionary<FileDetails, FileUser> selections &&
                values[1] is FileDetails file)
            {
                return selections.ContainsKey(file) ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
