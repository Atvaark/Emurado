using System;
using HaloOnline.Server.Model.Serialization;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitlePropertyDateTime : TitleProperty
    {
        public override TitlePropertyType Type
        {
            get { return TitlePropertyType.Integer; }
        }

        [JsonProperty("intVal")]
        [JsonConverter(typeof(UnixEpochSecondsJsonConverter))]
        public DateTime Value { get; set; }
    }
}