namespace Roblox_Sharp.JSON_Models.Internal
{
    /// <summary>
    /// class used to serialize User POST based requests
    /// </summary>
    internal class User_POST
    {
        /// <summary>
        /// exclude banned users
        /// </summary>
        public bool excludeBannedUsers { get; init; }

        /// <summary>
        /// array of user ids
        /// </summary>
        public ulong[]? userIds { get; init; }

        /// <summary>
        /// array of username
        /// </summary>
        public string[]? usernames { get; init; }

        public User_POST(ulong[] userIds, bool excludeBannedUsers = false)
        {
            this.userIds = userIds;
            this.excludeBannedUsers = excludeBannedUsers;
        }

        public User_POST(string[] usernames, bool excludeBannedUsers = false)
        {
            this.usernames = usernames;
            this.excludeBannedUsers = excludeBannedUsers;
        }
    }
}
