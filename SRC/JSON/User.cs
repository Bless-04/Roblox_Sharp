using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Templates;

//for the user based requests
namespace Roblox_Sharp.JSON
{
    /** userid 
     * post request
        {
          "userIds": [
            1,2,3,4,5
          ],
          "excludeBannedUsers": false
        }
    */

    /** username 
     * post request
         {
            "usernames": [
            "string"
            ],
            "excludeBannedUsers": true
         }
     */

    /** example return; userid does not have the requestedUsername key
     * 
        {
            "data": [
                {
                  "requestedUsername": "string",
                  "hasVerifiedBadge": true,
                  "id": 0,
                  "name": "string",
                  "displayName": "string"
                }
            ]
        }
*/

    /// <summary>
    /// class used to serialize User based requests
    /// </summary>
    public class User : IUser
    {
        public User(ulong userId) : base(userId) { }

        public User(string name, string? displayName = null)
        {
            this.name = name;
            this.displayName = displayName;
        }

        public User(ulong id, string name, string? displayName = null) : base(id)
        {
            this.name = name;
            this.displayName = displayName;
        }

        public User() { }

        [JsonPropertyName("userId")]
        public ulong userId 
        { 
            get => id; 
            init => id = value; 
        } //unique to group request

        /// <summary>
        /// unique username for the user
        /// </summary>
        [JsonPropertyName("name")]
        public string name { get; init; }
        [JsonPropertyName("username")]

        public string username
        {
            get => name;
            init => name = value;
        } // unique to group request

        /// <summary>
        /// display name for the user
        /// </summary>
        [JsonPropertyName("displayName")]
        public string? displayName { get; init; }

        /// <summary>
        /// description for the user
        /// </summary>
        [JsonPropertyName("description")]
        public string? description { get; init; }

        /// <summary>
        /// creation date and time of user
        /// </summary>
        [JsonPropertyName("created")]
        public DateTime created { get; init; }

        /// <summary>
        /// <b>true</b> if user is banned, <b>false</b> otherwise
        /// </summary>
        [JsonPropertyName("isBanned")]
        public bool isBanned { get; init; }

        [JsonPropertyName("externalAppDisplayName")]
        public string? externalAppDisplayName { get; init; }

        [JsonPropertyName("hasVerifiedBadge")]
        public bool hasVerifiedBadge { get; init; }

        [JsonPropertyName("requestedUsername")]
        public string? requestedUsername { get; init; }

        [JsonPropertyName("presenceType")]
        public Presence_Type presenceType { get; init; }

        [JsonPropertyName("previousUsernames")]
        public IReadOnlyList<string>? previousUsernames { get; init; }

        /// <summary>
        /// <b>true</b> if user is currently online, <b>false</b> otherwise
        /// </summary>
        [JsonPropertyName("isOnline")]
        public bool isOnline { get; init; }

        [JsonPropertyName("isDeleted")]
        public bool isDeleted { get; init; }

        [JsonPropertyName("friendFrequentScore")]
        public int friendFrequentScore { get; init; }

        [JsonPropertyName("friendFrequentRank")]
        public int friendFrequentRank { get; init; }

        /// <summary>
        /// string representation of the user <br></br> 
        /// Format: <b> <paramref name="displayName"/> @ <paramref name="name"/> (<paramref name="id"/>) </b>
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            (name != null)
            ? $"{displayName} @ {name} ({id})"
            : $"User Id: {id}";
    }
}

