using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BLL_Models;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL.Managers
{
    public static class ConnectionTester
    {
        public static string BuildConnectionString(DatabaseConfig config)
        {
            return $"Server={config.ServerName};Database={config.DatabaseName};User Id={config.Username};Password={config.Password};TrustServerCertificate={config.TrustServerCertificate};";

        }

        public static async Task<List<Dictionary<string, object>>> ExecuteRawQueryAsync(DataBaseContext context, string query)
        {
           
            using var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandText = query;

            if (context.Database.GetDbConnection().State == System.Data.ConnectionState.Closed)
            {
                await context.Database.GetDbConnection().OpenAsync();
            }

            using var reader = await command.ExecuteReaderAsync();
            var results = new List<Dictionary<string, object>>();

            while (await reader.ReadAsync())
            {
                var row = new Dictionary<string, object>();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.GetValue(i);
                }
                results.Add(row);
            }

            return results;
        }

        public static async Task<bool> TestTableExistsAsync(DataBaseContext context, string tableName)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandText = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tableName";
            var parameter = command.CreateParameter();
            parameter.ParameterName = "@tableName";
            parameter.Value = tableName;
            command.Parameters.Add(parameter);

            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result) > 0;
        }

        public static async Task<bool> TestConnectionAsync(string connectionString, IServiceProvider serviceProvider, DatabaseConfig config)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
                optionsBuilder.UseSqlServer(connectionString);

                using var context = new DataBaseContext(optionsBuilder.Options);
                await context.Database.OpenConnectionAsync();

                var requiredTables = new[] { "DOCUMENTO_UPLOAD_DIPENDENTE", "DOCUMENTO_UPLOAD", "ANAGDIP" };
                foreach (var requiredTable in requiredTables)
                {
                    if(!await TestTableExistsAsync(context, requiredTable))
                    {
                        return false;
                    }
                }

                StaticInfo.CurrentConnectionString = connectionString;
                StaticInfo.CurrentDatabaseConfig = config;
                await context.Database.CloseConnectionAsync();
                return true;
            }
            catch
            {
                return false; 
            }
        }
    }
}
