using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Skinet.Storage.SQLite.EF.DbInit
{
    public class DbInitContextFactory<T> where T : DbContext
    {
        public static T CreateDbContext()
        {
            string connectionString = ConnectionStringFactory.GetDbConnectionString();
            var migrationAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlite(
                connectionString,
                ob => ob.MigrationsAssembly(migrationAssembly));
            var constructor = 
                typeof(T).GetConstructor(new Type[] { typeof(DbContextOptions<T>) });
            return (T)constructor.Invoke(new object[] { builder.Options });
        }
    }
}
