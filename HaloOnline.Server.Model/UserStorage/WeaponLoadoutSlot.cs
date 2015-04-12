namespace HaloOnline.Server.Model.UserStorage
{
    public class WeaponLoadoutSlot
    {
        public string PrimaryWeapon { get; set; }
        public string SecondaryWeapon { get; set; }
        public string Grenades { get; set; }
        /// <summary>
        /// Tech slots
        /// </summary>
        public string Booster { get; set; }
        public string ConsumableFirst { get; set; }
        public string ConsumableSecond { get; set; }
        public string ConsumableThird { get; set; }
        public string ConsumableFourth { get; set; }
    }
}