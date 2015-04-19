namespace HaloOnline.Server.Model.User
{
    public class UserState
    {
        /// <summary>
        /// 0 None
        /// 1 Purchased
        /// 2 Rented
        /// </summary>
        public int OwnType { get; set; }

        public long Value { get; set; }
        
        public string StateName { get; set; }

        /// <summary>
        /// 1 Level progress
        /// 2 Credits
        /// 3 Gold
        /// 4 Rent time left in milliseconds
        /// 9 Level
        /// 12 Token (account_rename_token, class_select_token)
        /// </summary>
        public int StateType { get; set; }
    }
}
