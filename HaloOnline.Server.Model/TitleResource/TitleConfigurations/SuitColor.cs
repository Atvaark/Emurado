using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class SuitColor : TitleInstance
    {
        public SuitColor(string instanceName) : base(instanceName)
        {
            Name = "";
            Color = new Color();
            ColorType = SuitColorType.Primary;
            UiListId = "";
        }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public Color Color { get; set; }

        [JsonIgnore]
        public SuitColorType ColorType { get; set; }

        [JsonIgnore]
        public string UiListId { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.ColorClassName; }
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
                Name = TitleInstanceConstants.ColorType,
                Value = GetSuitColorTypeString(ColorType)
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.ColorR,
                Value = Color.R
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.ColorG,
                Value = Color.G
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.ColorB,
                Value = Color.B
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.ColorUiListId,
                Value = UiListId
            };
        }

        private string GetSuitColorTypeString(SuitColorType suitColorType)
        {
            switch (suitColorType)
            {
                case SuitColorType.Primary:
                    return TitleInstanceConstants.ColorTypePrimary;
                case SuitColorType.Secondary:
                    return TitleInstanceConstants.ColorTypeSecondary;
                case SuitColorType.Visor:
                    return TitleInstanceConstants.ColorTypeVisor;
                case SuitColorType.Lights:
                    return TitleInstanceConstants.ColorTypeLights;
                case SuitColorType.Holo:
                    return TitleInstanceConstants.ColorTypeHolo;
                default:
                    throw new ArgumentOutOfRangeException("suitColorType");
            }
        }
    }
}