using HaloOnline.Server.Core.Http.Model.Messaging;
using HaloOnline.Server.Model.Messaging;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IMessagingService
    {
        JoinChannelsResult JoinChannels(JoinChannelsRequest request);
        LeaveChannelsResult LeaveChannels(LeaveChannelsRequest request);
        SendResult Send(SendRequest request);
        SendServiceMessageResult SendServiceMessage(SendServiceMessageRequest request);
        ReceiveResult Receive(ReceiveRequest request);
    }
}
