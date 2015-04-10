namespace HaloOnline.Server.Model.Messaging
{
    public static class ChannelTypes
    {
        /// <summary>
        /// Clan chat channel.
        /// The placeholder {0} is the clan id.
        /// </summary>
        public const string Clan = "#clan_{0}";

        /// <summary>
        /// Ingame all chat channel.
        /// The placeholder {0} is the game GUID.
        /// </summary>
        public const string Game = "#game_{0}";

        /// <summary>
        /// Ingame team chat channel.
        /// The placeholder {0} is the team GUID.
        /// </summary>
        public const string Gameteam = "#gameteam_{0}";

        /// <summary>
        /// General chat channel.
        /// The placeholder {0} is the channel id.
        /// </summary>
        public const string General = "#general_{0}";

        /// <summary>
        /// Party chat channel.
        /// The placeholder {0} is the party GUID.
        /// </summary>
        public const string Party = "#party_{0}";

        /// <summary>
        /// Private chat channel.
        /// The placeholder {0} is a user id.
        /// </summary>
        public const string Private = "#private_{0}";
    }
}