namespace HaloOnline.Server.Core.Log.Messages
{
    public class UpdateConnectionMessageVisitor : MessageVisitor
    {
        private readonly IConnection _connection;

        public UpdateConnectionMessageVisitor(IConnection connection)
        {
            _connection = connection;
        }

        public override void Visit(MessageHearbeat message)
        {
            _connection.ClientComputerName = message.ClientComputerName;
            _connection.ClientId = message.ClientId;
            _connection.ClientName = message.ClientName;
        }
    }
}
