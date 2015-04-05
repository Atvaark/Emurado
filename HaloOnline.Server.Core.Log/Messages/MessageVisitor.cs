namespace HaloOnline.Server.Core.Log.Messages
{
    public abstract class MessageVisitor
    {
        public virtual void Visit(MessageHearbeat message)
        {
        }

        public virtual void Visit(MessageLogin message)
        {
        }

        public virtual void Visit(MessagePort message)
        {
        }
    }
}
