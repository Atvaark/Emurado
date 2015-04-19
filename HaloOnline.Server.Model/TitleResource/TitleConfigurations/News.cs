using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class News : TitleInstance
    {
        public News(string instanceName) : base(instanceName)
        {
            Name = "";
            SortIndex = 0;
            Poster = "";
            TimeStamp = DateTime.MinValue;
            Text = "";
        }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public int SortIndex { get; set; }

        [JsonIgnore]
        public string Poster { get; set; }

        [JsonIgnore]
        public DateTime TimeStamp { get; set; }

        [JsonIgnore]
        public string Text { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.NewsClassName; }
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
                Name = TitleInstanceConstants.NewsSortIndex,
                Value = SortIndex
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.NewsPoster,
                Value = Poster
            }; 
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.NewsTimeStamp,
                Value = TimeStamp.ToString(CultureInfo.InvariantCulture)
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.NewsString,
                Value = Text
            };
        }
    }
}