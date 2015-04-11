using System.Data.Entity;
using HaloOnline.Server.Core.Repository.Model;

namespace HaloOnline.Server.Core.Repository
{
    public class HaloDbContext : DbContext
    {
        public HaloDbContext()
            : this("HaloOnline.Server.Properties.Settings.HaloDbContext")
        {

        }

        private HaloDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer<HaloDbContext>(null);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<ClanMembership> ClanMemberships { get; set; }
    }
}