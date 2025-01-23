using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DocumentSavingProject.Helpers
{
    public static class Helper
    {
        public static bool IsWindowOpen<T>() where T : Window
        {
            return Application.Current.Windows.OfType<T>().Any();
        }

        public static void CloseExternalWindow<T>() where T : Window
        {
            try
            {
                Application.Current.Windows.OfType<T>().FirstOrDefault().Close();
            }
            catch { }
        }
    }
}
