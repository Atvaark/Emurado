using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class Weapon : TitleInstance
    {
        public Weapon(string instanceName) : base(instanceName)
        {
            Name = "";
            SecondaryId = "";
            Type = "";
        }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string SecondaryId { get; set; }

        [JsonIgnore]
        public string Type { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.WeaponClassName; }
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
                Name = TitleInstanceConstants.WeaponId,
                Value = SecondaryId
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.WeaponType,
                Value = Type
            };
        }

    }
}