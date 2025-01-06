using Roblox_Sharp.Enums;
using Roblox_Sharp.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

//for the user based requests
namespace Roblox_Sharp.Models
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
        [JsonInclude]
        /// <summary>
        /// ambiguous with username
        /// </summary>
        protected string name { init => base.username = value; }

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

        public User() { }

        public User(ulong userId, string username, string? displayName = null) : base(userId, username, displayName) { }

        public override User Clone()
        {
            List<string>? previousUsernamesCopy = null;

            if (previousUsernames != null)
            {
                previousUsernamesCopy = new List<string>(previousUsernames.Count);

                foreach (string username in previousUsernames)
                    previousUsernamesCopy.Add(username);
            }

            return new User()
            {
                id = base.id,
                username = base.username,
                displayName = base.displayName,
                description = description,
                created = created,
                isBanned = isBanned,
                externalAppDisplayName = externalAppDisplayName,
                hasVerifiedBadge = hasVerifiedBadge,
                requestedUsername = requestedUsername,
                presenceType = presenceType,
                previousUsernames = previousUsernamesCopy,
                isOnline = isOnline,
                isDeleted = isDeleted,
                friendFrequentScore = friendFrequentScore,
                friendFrequentRank = friendFrequentRank
            };
        }
    }
}

