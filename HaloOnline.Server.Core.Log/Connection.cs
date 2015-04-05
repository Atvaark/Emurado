namespace HaloOnline.Server.Core.Log
{
    public class Connection : IConnection
    {
        private readonly int _id;

        public Connection(int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
        }

        public bool Connected { get; set; }
        public string ClientComputerName { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
    }
}
