namespace HaloOnline.Server.Common
{
    public interface IServerOptions
    {
        string EndpointHostname { get; set; }
        int EndpointPort { get; set; }
        int DispatcherPort { get; set; }
        int LogPort { get; set; }
        int AppPort { get; set; }
        int ClientPort { get; set; }
        string Secret { get; set; }
    }
}