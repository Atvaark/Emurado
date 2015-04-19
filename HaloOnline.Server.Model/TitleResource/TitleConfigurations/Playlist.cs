using System.Collections.Generic;
using System.Linq;

namespace HaloOnline.Server.Model.TitleResource.TitleConfigurations
{
    public class Playlist : TitleInstance
    {
        public Playlist(string instanceName) : base(instanceName)
        {
            Name = "";
            GameModeCollection = new List<string>();
            MapCollection = new List<string>();
            MinPlayers = 0;
            MaxPlayers = 0;
            MaxParty = 0;
            IsTeamPlaylist = false;
        }

        public string Name { get; set; }

        public List<string> GameModeCollection { get; set; }

        public List<string> MapCollection { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        public int? MaxParty { get; set; }

        public bool IsTeamPlaylist { get; set; }

        public override string ClassName
        {
            get { return TitleInstanceConstants.PlaylistClassName; }
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
            yield return new TitlePropertyStringList
            {
                Name = TitleInstanceConstants.PlaylistGameModeCollection,
                Value = GameModeCollection
            };
            yield return new TitlePropertyStringList
            {
                Name = TitleInstanceConstants.PlaylistMapCollection,
                Value = MapCollection
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.PlaylistMinPlayers,
                Value = MinPlayers
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.PlaylistMaxPlayers,
                Value = MaxPlayers
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.PlaylistMaxParty,
                Value = MaxParty
            };
            yield return new TitlePropertyInteger
            {
                Name = TitleInstanceConstants.PlaylistIsTeamPlaylist,
                Value = IsTeamPlaylist ? 1 : 0
            };
        }
    }
}