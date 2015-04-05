using System.Collections.Generic;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitleTagsPatchConfiguration
    {
        public string CombinationHash { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
