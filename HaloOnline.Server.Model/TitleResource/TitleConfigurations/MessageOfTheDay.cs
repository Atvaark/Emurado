using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class MessageOfTheDay : TitleInstance
    {
        public MessageOfTheDay(string instanceName) : base(instanceName)
        {
        }

        [JsonIgnore]
        public DayOfWeek Day { get; set; }

        [JsonIgnore]
        public string MotdUiDescId { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.MotdClassName; }
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
                Value = GetNameString(Day)
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.MotdUiDescId,
                Value = MotdUiDescId
            };
        }

        private string GetNameString(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return TitleInstanceConstants.MotdSunday;
                case DayOfWeek.Monday:
                    return TitleInstanceConstants.MotdMonday;
                case DayOfWeek.Tuesday:
                    return TitleInstanceConstants.MotdTuesday;
                case DayOfWeek.Wednesday:
                    return TitleInstanceConstants.MotdWednesday;
                case DayOfWeek.Thursday:
                    return TitleInstanceConstants.MotdThursday;
                case DayOfWeek.Friday:
                    return TitleInstanceConstants.MotdFriday;
                case DayOfWeek.Saturday:
                    return TitleInstanceConstants.MotdSaturday;
                default:
                    throw new ArgumentOutOfRangeException("day");
            }
        }
    }
}