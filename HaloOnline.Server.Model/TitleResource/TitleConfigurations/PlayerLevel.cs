using System.Collections.Generic;
using System.Linq;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class PlayerLevel : TitleInstance
    {
        public PlayerLevel(string instanceName) : base(instanceName)
        {
            Name = "";
            LevelIndex = 0;
            XpUnlock = 0;
            ItemsRecieved = new List<string>();
            ItemsUnlocked = new List<string>();
        }

        public string Name { get; set; }

        public int? LevelIndex { get; set; }

        public int? XpUnlock { get; set; }

        public List<string> ItemsRecieved { get; set; }

        public List<string> ItemsUnlocked { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.PlayerLevelClassName; }
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
                Name = TitleInstanceConstants.PlayerLevelLevelIndex,
                Value = LevelIndex
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.PlayerLevelXpUnlock,
                Value = XpUnlock
            };
            yield return new TitlePropertyStringList
            {
                Name = TitleInstanceConstants.PlayerLevelItemsRecieved,
                Value = ItemsRecieved
            };
            yield return new TitlePropertyStringList
            {
                Name = TitleInstanceConstants.PlayerLevelItemsUnlocked,
                Value = ItemsUnlocked
            };
        }
    }
}