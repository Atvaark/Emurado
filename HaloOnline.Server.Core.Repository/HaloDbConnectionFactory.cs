using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

namespace HaloOnline.Server.Core.Repository
{
    public class HaloDbConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            // BUG: EF can't find the Connection string of HaloOnline.Server.Core.Repository.HaloDbContext
            //nameOrConnectionString = "HaloDbContext";
            //nameOrConnectionString = "Data Source=|DataDirectory|halodb.sqlite";
            return new SQLiteConnection(nameOrConnectionString);
        }
    }
}