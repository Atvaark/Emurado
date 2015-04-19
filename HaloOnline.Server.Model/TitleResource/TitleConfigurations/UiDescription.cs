using System.Collections.Generic;
using System.Linq;

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

        public string Name { get; set; }

        public string NameId { get; set; }

        public string DescriptionId { get; set; }

        public string DescriptionShortId { get; set; }

        public string Icon { get; set; }

        public string IconMedium { get; set; }

        public string IconBig { get; set; }

        public string Video { get; set; }

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