using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public abstract class TitleInstance
    {
        private readonly string _instanceName;

        public TitleInstance(string instanceName)
        {
            _instanceName = instanceName;
            Parents = new List<string>();
        }

        // TODO: Check if InstanceName and the Name property are always the same
        [JsonProperty("name")]
        public string InstanceName { get { return _instanceName; } }

        [JsonProperty("className")]
        public abstract string ClassName { get; }

        [JsonProperty("parents")]
        public List<string> Parents { get; set; }

        [JsonProperty("props")]
        public abstract List<TitleProperty> Properties { get; }
    }
}
