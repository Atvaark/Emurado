namespace HaloOnline.Server.Core.Log.Messages
{
    public enum MessageType : byte
    {
        Message = 0,
        MessageHeartbeat = 1,
        MessageLog = 2,
        MessageCurrentState = 3,
        MessageProfileFrame = 4,
        MessageSwdFile = 5,
        MessageSourceFile = 6,
        MessageSwdRequest = 7,
        MessageSourceRequest = 8,
        MessageAppControl = 9,
        MessagePort = 10,
        MessageImageRequest = 11,
        MessageImageData = 12,
        MessageFontRequest = 13,
        MessageFontData = 14,
        MessageCompressed = 15,
        MessageLogin = 16
    }
}
