using HaloOnline.Server.Core.Http.Model.Presence;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IPresenceService
    {
        PresenceDisconnectResult PresenceDisconnect(PresenceDisconnectRequest request);
        PresenceConnectResult PresenceConnect(PresenceConnectRequest request);
        PresenceGetUsersPresenceResult PresenceGetUsersPresence(PresenceGetUsersPresenceRequest request);
        PartyJoinResult PartyJoin(PartyJoinRequest request);
        PartyLeaveResult PartyLeave(PartyLeaveRequest request);
        PartyKickResult PartyKick(PartyKickRequest request);
        PartySetGameDataResult PartySetGameData(PartySetGameDataRequest request);
        PartyGetStatusResult PartyGetStatus(PartyGetStatusRequest request);
        CustomGameStartResult CustomGameStart(CustomGameStartRequest request);
        CustomGameStopResult CustomGameStop(CustomGameStopRequest request);
        MatchmakeStartResult MatchmakeStart(MatchmakeStartRequest request);
        MatchmakeStopResult MatchmakeStop(MatchmakeStopRequest request);
        MatchmakeGetStatusResult MatchmakeGetStatus(MatchmakeGetStatusRequest request);
        ReportOnlineStatsResult ReportOnlineStats(ReportOnlineStatsRequest request);
        GetPlaylistStatResult GetPlaylistStat(GetPlaylistStatRequest request);
    }
}
