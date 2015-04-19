using System.Collections.Generic;

namespace HaloOnline.Server.Model.TitleResource
{
    //TODO: Remove TitleInstanceImpl once all TitleInstance subclasses are documented
    public class TitleInstanceImpl : TitleInstance
    {
        private readonly string _className;
        private readonly List<TitleProperty> _properties;

        public TitleInstanceImpl(string instanceName, string className) : base(instanceName)
        {
            _className = className;
            _properties = new List<TitleProperty>();
        }

        public override string ClassName
        {
            get { return _className; }
        }

        public override List<TitleProperty> Properties
        {
            get { return _properties; }
        }
    }
}