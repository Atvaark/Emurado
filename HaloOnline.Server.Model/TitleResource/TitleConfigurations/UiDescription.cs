using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class UiDescription : TitleInstance
    {
        public UiDescription(string name) : base(name)
        {
            Name = "";
            NameId = "";
            DescriptionId = "";
            DescriptionShortId = "";
            Icon = "";
            IconMedium = "";
            IconBig = "";
            Video = "";
            ItemQuality = "";
        }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string NameId { get; set; }

        [JsonIgnore]
        public string DescriptionId { get; set; }

        [JsonIgnore]
        public string DescriptionShortId { get; set; }

        [JsonIgnore]
        public string Icon { get; set; }

        [JsonIgnore]
        public string IconMedium { get; set; }

        [JsonIgnore]
        public string IconBig { get; set; }

        [JsonIgnore]
        public string Video { get; set; }

        [JsonIgnore]
        public string ItemQuality { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.UiDescClassName; }
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
                Name = TitleInstanceConstants.UiDescUiNameId,
                Value = NameId
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.UiDescUiDescId,
                Value = DescriptionId
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.UiDescUiDescShortId,
                Value = DescriptionShortId
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.UiDescUiIcon,
                Value = Icon
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.UiDescUiIconMed,
                Value = IconMedium
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.UiDescUiIconBig,
                Value = IconBig
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.UiDescUiVideo,
                Value = Video
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.UiDescItemQuality,
                Value = ItemQuality
            };
        }

    }
}