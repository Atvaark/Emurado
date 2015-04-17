using HaloOnline.Server.Core.Http.Model.Clan;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IClanService
    {
        ClanCreateResult ClanCreate(ClanCreateRequest request);
        ClanGetBaseDataResult ClanGetBaseData(ClanGetBaseDataRequest request);
        ClanGetMembershipResult ClanGetMembership(ClanGetMembershipRequest request);
        ClanJoinResult ClanJoin(ClanJoinRequest request);
        ClanKickResult ClanKick(ClanKickRequest request);
        ClanLeaveResult ClanLeave(ClanLeaveRequest request);
        ClanGetByNameResult ClanGetByName(ClanGetByNameRequest request);
    }
}
