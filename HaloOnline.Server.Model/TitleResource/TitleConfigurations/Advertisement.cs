using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class Advertisement : TitleInstance
    {
        public Advertisement(string instanceName) : base(instanceName)
        {
            Name = "";
            SortIndex = 0;
            Url = "";
            Timer = 0;
        }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public int SortIndex { get; set; }

        [JsonIgnore]
        public string Url { get; set; }

        [JsonIgnore]
        public int Timer { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.AdvertismentClassName; }
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
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.AdvertisementSortIndex,
                Value = SortIndex
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.AdvertisementUrl,
                Value = Url
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.AdvertisementTimer,
                Value = Timer
            };
        }

    }
}