using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// for  <see cref="Models.v1.UserByUserId"/> and <see cref="Models.v1.UserByUsername"/>
    /// </summary>
    internal sealed class UserByX
    {
        #region Properties
        public bool ExcludeBannedUsers { get; }

        [JsonPropertyName("userIds")]
        public IEnumerable<ulong>? UserIds { get; }

        [JsonPropertyName("usernames")]
        public IEnumerable<string>? Usernames { get; }
        #endregion

        public UserByX(IEnumerable<ulong> UserIds, bool ExcludeBannedUsers)
        {
            this.UserIds = UserIds;
            this.ExcludeBannedUsers = ExcludeBannedUsers;
        }

        public UserByX(IEnumerable<string> Usernames, bool ExcludeBannedUsers)
        {
            this.Usernames = Usernames;
            this.ExcludeBannedUsers = ExcludeBannedUsers;
        }

        /// <returns>A serialized version of the <see cref="UserByX"/> </returns>
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
