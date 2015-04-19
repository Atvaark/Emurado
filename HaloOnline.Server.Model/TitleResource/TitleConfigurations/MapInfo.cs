using System.Collections.Generic;
using System.Linq;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class MapInfo : TitleInstance
    {
        public MapInfo(string instanceName) : base(instanceName)
        {
            Name = "";
            MapInfoId = "";
        }

        public string Name { get; set; }

        public string MapInfoId { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.MapInfoClassName; }
        }
        
        public override List<TitleProperty> Properties
        {
            get { return GetProperties().ToList(); }
        }

        private IEnumerable<TitleProperty> GetProperties()
        {
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.TitleInstanceName,
                Value = Name
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.MapInfoId,
                Value = MapInfoId
            };
        }
    }
}