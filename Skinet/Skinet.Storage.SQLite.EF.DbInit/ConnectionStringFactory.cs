using Microsoft.Extensions.Configuration;

namespace Skinet.Storage.SQLite.EF.DbInit
{
    public class ConnectionStringFactory
    {
        public const string DbConnectionName = @"DefaultConnection";
        public const string SettingFileName = @"appsettings.json";
        public static string GetDbConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(SettingFileName)
                .Build();
            return config.GetConnectionString(DbConnectionName);
        }
    }
}
