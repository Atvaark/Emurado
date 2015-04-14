using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

namespace HaloOnline.Server.Core.Repository
{
    public class HaloDbConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            return new SQLiteConnection(nameOrConnectionString);
        }
    }
}