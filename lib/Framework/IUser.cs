namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// Defines a generalized template for any roblox <see cref="IUser"></see> based object
    /// all users inherit have the fields <b>userId</b> <b>username</b> and <b>displayName</b>
    /// </summary>
    public abstract class IUser : ICreation<IUser>
    {
        /// <summary>
        /// the Unique numeric id of the user.
        /// </summary>
        public ulong userId
        {
            get => base.id;
            init => base.id = value;
        }

        /// <summary>
        /// unique username for the user
        /// </summary>
        public string username { get; init; }

        private string? _displayName { get; init; }
        /// <summary>
        /// display name for the user <br></br>
        /// <b>null</b>if the display name is the same as the username <br></br>
        /// this indicates that the user has never set a display name
        /// </summary>
        public string? displayName
        {
            get => _displayName;
            init
            {
                if (value != null && value.Equals(username)) _displayName = null;
                else _displayName = value;
            }
        }
        protected IUser() { }

        public IUser(ulong userId, string username, string? displayName = null)
        {
            base.id = userId;
            this.username = username;
            this.displayName = displayName;
        }

        /// <summary>
        /// string representation of the user <br></br> 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (username == null) return $"(ID {userId})";
            if (_displayName == null) return $"{username} (ID {userId})";
            return $"{_displayName}@{username} (ID {userId})";
        } 
    }
}
