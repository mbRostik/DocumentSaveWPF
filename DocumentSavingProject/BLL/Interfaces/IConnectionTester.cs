using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BLL_Models;

namespace BLL.Interfaces
{
    public interface IConnectionTester
    {
        Task<bool> TestConnectionAsync(string connectionString);
        string BuildConnectionString(DatabaseConfig config);
    }
}
