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

        private HaloDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<HaloDbContext>(null);
        }

        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<ChallengeReward> ChallengeRewards { get; set; }
        public virtual DbSet<Clan> Clans { get; set; }
        public virtual DbSet<ClanMembership> ClanMemberships { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<PartyMember> PartyMembers { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopSection> ShopSections { get; set; }
        public virtual DbSet<ShopSectionShelve> ShopSectionShelves { get; set; }
        public virtual DbSet<ShopSectionShelveItem> ShopSectionShelveItems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserChallenge> UserChallenges { get; set; }
        public virtual DbSet<UserChallengeCounter> UserChallengeCounters { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }
        public virtual DbSet<UserDataContainerType> UserDataContainerTypes { get; set; }
        public virtual DbSet<UserPresence> UserPresences { get; set; } 
        public virtual DbSet<UserPrimaryState> UserPrimaryState { get; set; }
        public virtual DbSet<UserState> UserStates { get; set; }
        public virtual DbSet<UserSubscription> UserSubscriptions { get; set; } 
        public virtual DbSet<UserTransaction> UserTransactions { get; set; }
        public virtual DbSet<UserTransactionExtendedInfoItem> UserTransactionExtendedInfoItems { get; set; }
        public virtual DbSet<UserTransactionItem> UserTransactionItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Challenge>()
                .HasMany(e => e.ChallengeRewards)
                .WithRequired(e => e.Challenge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Challenge>()
                .HasMany(e => e.UserChallenges)
                .WithRequired(e => e.Challenge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clan>()
                .HasMany(e => e.ClanMemberships)
                .WithRequired(e => e.Clan)
                .HasForeignKey(e => e.ClanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.ShopSections)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShopSection>()
                .HasMany(e => e.ShopSectionShelves)
                .WithRequired(e => e.ShopSection)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShopSectionShelve>()
                .HasMany(e => e.ShopSectionShelveItems)
                .WithRequired(e => e.ShopSectionShelve)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserChallenges)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserDatas)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.UserPrimaryState)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserStates)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Subscribers)
                .WithRequired(e => e.Subscribee);
            //    .WithMany()
            //    .Map(m =>
            //    {
            //        m.ToTable("UserSubscription");
            //        m.MapLeftKey("SubscriberId");
            //        m.MapRightKey("SubscribeeId");
            //    });

            modelBuilder.Entity<User>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.Subscriber)
                .WillCascadeOnDelete(false);
                //.Map(m =>
                //{
                //    m.ToTable("UserSubscription");
                //    m.MapRightKey("SubscriberId");
                //    m.MapLeftKey("SubscribeeId");
                //});

            modelBuilder.Entity<UserDataContainerType>()
                .HasMany(e => e.UserData)
                .WithRequired(e => e.UserDataContainerType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTransaction>()
                .HasMany(e => e.UserTransactionExtendedInfoItems)
                .WithRequired(e => e.UserTransaction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTransaction>()
                .HasMany(e => e.UserTransactionItems)
                .WithRequired(e => e.UserTransaction)
                .WillCascadeOnDelete(false);
        }

    }
}