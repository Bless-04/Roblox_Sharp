using Roblox_Sharp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class User
{
    /// <summary>
    /// class used to serialize <see cref="User"/> POST based requests
    /// </summary>
    /// <remarks>Does not require X-CSRF-Token protection because this is essentially a get request but as a POST to avoid URI limits.</remarks>

    public class Post
    {
        /// <summary>
        /// max number of ids that can be requested at a time
        /// </summary>
        public const byte MAXCreationIdS = 100;

        /// <summary>
        /// max number of usernames that can be requested at a time
        /// </summary>
        public const byte MAX_USERNAMES = MAXCreationIdS;

        /// <summary>
        /// exclude banned users
        /// </summary>
        [JsonPropertyName("excludeBannedUsers")]
        public bool ExcludeBannedUsers { get; set; }

        /// <summary>
        /// array of user ids for the post request
        /// </summary>
        [JsonPropertyName("userIds")]
        public IEnumerable<ulong>? UserIds { get; set; }

        /// <summary>
        /// array of usernames for the post request
        /// </summary>
        [JsonPropertyName("usernames")]
        public IEnumerable<string>? Usernames { get; set; }

        public Post(IEnumerable<ulong> userIds, bool excludeBannedUsers = false)
        {
            if (userIds.Count() > MAXCreationIdS) throw new InvalidUserException("Too many userIds");

            UserIds = userIds;

            ExcludeBannedUsers = excludeBannedUsers;
        }

        public Post(IEnumerable<string> usernames, bool excludeBannedUsers = false)
        {
            if (usernames.Count() > MAX_USERNAMES) throw new InvalidUserException("Too many usernames");
            Usernames = usernames;

            ExcludeBannedUsers = excludeBannedUsers;
        }
    }
}
