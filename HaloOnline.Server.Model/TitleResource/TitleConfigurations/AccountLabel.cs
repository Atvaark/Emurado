using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class AccountLabel : TitleInstance
    {
        public AccountLabel(string instanceName) : base(instanceName)
        {
            Name = "";
        }

        [JsonIgnore]
        public string Name { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.AccountLabelClassName; }
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
        }
    }
}