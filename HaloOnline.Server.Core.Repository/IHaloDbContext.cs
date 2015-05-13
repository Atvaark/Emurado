using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using HaloOnline.Server.Core.Repository.Model;

namespace HaloOnline.Server.Core.Repository
{
    public interface IHaloDbContext
    {
        IDbSet<Challenge> Challenges { get; set; }
        IDbSet<ChallengeReward> ChallengeRewards { get; set; }
        IDbSet<Channel> Channels { get; set; }
        IDbSet<ChannelMessage> ChannelMessages { get; set; }
        IDbSet<ChannelUser> ChannelsUsers { get; set; }
        IDbSet<Clan> Clans { get; set; }
        IDbSet<ClanMembership> ClanMemberships { get; set; }
        IDbSet<Party> Parties { get; set; }
        IDbSet<PartyMember> PartyMembers { get; set; }
        IDbSet<Session> Sessions { get; set; }
        IDbSet<Shop> Shops { get; set; }
        IDbSet<ShopSection> ShopSections { get; set; }
        IDbSet<ShopSectionShelve> ShopSectionShelves { get; set; }
        IDbSet<ShopSectionShelveItem> ShopSectionShelveItems { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<UserChallenge> UserChallenges { get; set; }
        IDbSet<UserChallengeCounter> UserChallengeCounters { get; set; }
        IDbSet<UserData> UserDatas { get; set; }
        IDbSet<UserDataContainerType> UserDataContainerTypes { get; set; }
        IDbSet<UserPresence> UserPresences { get; set; }
        IDbSet<UserPrimaryState> UserPrimaryState { get; set; }
        IDbSet<UserState> UserStates { get; set; }
        IDbSet<UserSubscription> UserSubscriptions { get; set; }
        IDbSet<UserTransaction> UserTransactions { get; set; }
        IDbSet<UserTransactionExtendedInfoItem> UserTransactionExtendedInfoItems { get; set; }
        IDbSet<UserTransactionItem> UserTransactionItems { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}