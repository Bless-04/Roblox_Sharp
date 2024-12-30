using System.Collections.Generic;
using Roblox_Sharp.Exceptions;

namespace Roblox_Sharp.Models.Internal.POST
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
        public IReadOnlyList<ulong>? userIds { get; init; }

        /// <summary>
        /// array of username
        /// </summary>
        public IReadOnlyList<string>? usernames { get; init; }

        /// <summary>
        /// limits the length of an array
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>true if the array is less than the limit</returns>
        internal bool ArrayLengthCheck<T>(List<T> list, int limit = 100) => list.Count < limit;
        
        
        public User_POST(List<ulong> userIds, bool excludeBannedUsers = false)
        {
            if (!ArrayLengthCheck(userIds) ) throw new InvalidIdException ("Too many userIds");

            this.userIds = userIds;
            
            this.excludeBannedUsers = excludeBannedUsers;
        }

        public User_POST(List<string>usernames, bool excludeBannedUsers = false)
        {
            if (!ArrayLengthCheck(usernames) ) throw new InvalidUsernameException ("Too many usernames");
            this.usernames = usernames;
            
            this.excludeBannedUsers = excludeBannedUsers;
        }
    }
}
