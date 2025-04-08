using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
namespace Roblox_Sharp.Models.v1
{
    /* same as UserByUserId but with   previousUsernames
     * {
      "previousUsernames": [
        "string"
      ],
      "hasVerifiedBadge": true,
      "id": 0,
      "name": "string",
      "displayName": "string"
    }
     */

    /// <summary>
    /// Used to deserialize <see cref="Endpoints.Users_v1.Get_UserSearchAsync(string, string?, Endpoints.Limit, string?)"/>
    /// </summary>
    public class UserBySearch : UserByUserId
    {
        /// <summary>
        /// The users past previous usernames
        /// </summary>
        [JsonPropertyName("previousUsernames")]
        public required IReadOnlyList<string> PreviousUsernames { get; init; }

    }
}
