using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Models
{

    public static class StaticInfo
    {
        private static string _currentConnectionString = "";
        public static string CurrentConnectionString
        {
            get => _currentConnectionString;
            set
            {
                _currentConnectionString = value;
                OnCurrentConnectionStringChanged?.Invoke();
            }
        }

        public static DatabaseConfig CurrentDatabaseConfig { get; set; } = new DatabaseConfig();

        public static event Action OnCurrentConnectionStringChanged;
    }
}
