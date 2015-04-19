using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class GameMode : TitleInstance
    {
        public GameMode(string instanceName) : base(instanceName)
        {
            Name = "";
            GameModeId = "";
            GameModeSecondaryId = "";
            GameModeRoundTimeLimit = 0;
        }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string GameModeId { get; set; }

        [JsonIgnore]
        public string GameModeSecondaryId { get; set; }

        [JsonIgnore]
        public int? GameModeRoundTimeLimit { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.GameModeClassName; }
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
                Name = TitleInstanceConstants.GameModeId,
                Value = GameModeId
            };
            yield return new TitlePropertyString
            {
                Name = TitleInstanceConstants.GameModeSecondaryId,
                Value = GameModeSecondaryId
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.GameModeRoundTimeLimit,
                Value = GameModeRoundTimeLimit
            };
        }
    }
}