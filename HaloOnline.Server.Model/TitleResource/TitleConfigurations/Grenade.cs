using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class Grenade : TitleInstance
    {
        public Grenade(string instanceName) : base(instanceName)
        {
            Name = "";
            Id = "";
        }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string Id { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.GrenadeClassName; }
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
                Name = TitleInstanceConstants.GrenadeId,
                Value = Id
            };
        }
    }
}