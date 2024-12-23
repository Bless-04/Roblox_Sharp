using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Framework;

//for the user based requests
namespace Roblox_Sharp.JSON_Models
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

    [JsonSerializable(typeof(User))]
    /// <summary>
    /// class used to serialize User based requests
    /// </summary>
    public class User : IUser
    {
        public User(ulong userId) : base(userId) { }

        public User(string username, string? displayName = null)
        {
            this.username = username;
            this.displayName = displayName;
        }

        public User(ulong userId, string username, string? displayName = null) : base(userId)
        {
            this.username = username;
            this.displayName = displayName;
        }

        public User() { }

        [JsonInclude]
        /// <summary>
        /// ambiguous with userId
        /// </summary>
        protected ulong id { init => base.userId = value; }

        /// <summary>
        /// unique username for the user
        /// </summary>
        public string username { get; init; }

        [JsonInclude]
        /// <summary>
        /// ambiguous with username
        /// </summary>
        protected string name { init => this.username = value; }

        /// <summary>
        /// display name for the user
        /// </summary>
        public string? displayName { get; init; }

        /// <summary>
        /// description for the user
        /// </summary>
        public string? description { get; init; }

        /// <summary>
        /// creation date and time of user
        /// </summary>
        public DateTime created { get; init; }

        /// <summary>
        /// <b>true</b> if user is banned, <b>false</b> otherwise
        /// </summary>
        public bool isBanned { get; init; }
        
        public string? externalAppDisplayName { get; init; }

        public bool hasVerifiedBadge { get; init; }

        public string? requestedUsername { get; init; }

        public Presence_Type presenceType { get; init; }

        public IReadOnlyList<string>? previousUsernames { get; init; }

        /// <summary>
        /// <b>true</b> if user is currently online, <b>false</b> otherwise
        /// </summary>
        public bool isOnline { get; init; }

        public bool isDeleted { get; init; }

        public int friendFrequentScore { get; init; }

        public int friendFrequentRank { get; init; }

        /// <summary>
        /// string representation of the user <br></br> 
        /// Format: <b> <paramref name="displayName"/> @ <paramref name="username"/> (<paramref name="id"/>) </b>
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            (username != null)
            ? $"{displayName} @ {username} ({userId})"
            : $"({userId})";
    }
}

