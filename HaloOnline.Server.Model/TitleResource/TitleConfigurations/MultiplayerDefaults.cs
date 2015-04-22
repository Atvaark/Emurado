using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class MultiplayerDefaults : TitleInstance
    {
        public MultiplayerDefaults(string instanceName) : base(instanceName)
        {
            Name = "";
            DefaultPlaylist = "";
            DefaultMap = "";
            DefaultGameMode = "";
        }

        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public string DefaultPlaylist { get; set; }
        [JsonIgnore]
        public string DefaultMap { get; set; }
        [JsonIgnore]
        public string DefaultGameMode { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.MpDefaultsClassName; }
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
                Name = TitleInstanceConstants.MpDefaultsDefaultPlaylist,
                Value = DefaultPlaylist
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.MpDefaultsDefaultMap,
                Value = DefaultMap
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.MpDefaultsDefaultGameMode,
                Value = DefaultGameMode
            };
        }
    }
}