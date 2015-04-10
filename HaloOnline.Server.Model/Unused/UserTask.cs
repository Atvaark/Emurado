using System.Collections.Generic;

namespace HaloOnline.Server.Model.Unused
{
    public class UserTask
    {
        public TaskId Id { get; set; }
        public string EventName { get; set; }
        public List<UserTaskFilter> Filters { get; set; }

    }
}