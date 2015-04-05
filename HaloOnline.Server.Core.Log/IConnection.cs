namespace HaloOnline.Server.Core.Log
{
    public interface IConnection
    {
        int Id { get; }
        bool Connected { get; set; }
        string ClientComputerName { get; set; }
        string ClientId { get; set; }
        string ClientName { get; set; }
    }
}
