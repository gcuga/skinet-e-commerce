using Microsoft.EntityFrameworkCore.Design;
using Skinet.Storage.SQLite.EF.Context;

namespace Skinet.Storage.SQLite.EF.DbInit
{
    public class DesignTimeStorageDbContextFactory : IDesignTimeDbContextFactory<StorageContext>
    {
        public StorageContext CreateDbContext(string[] args)
        {
            return DbInitContextFactory<StorageContext>.CreateDbContext();
        }
    }
}
