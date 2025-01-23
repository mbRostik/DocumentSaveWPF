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
    public class FileUserSelectedVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selections = value as Dictionary<FileDetails, FileUser>;
            var file = parameter as FileDetails;

            if (selections != null && file != null && selections.ContainsKey(file))
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}