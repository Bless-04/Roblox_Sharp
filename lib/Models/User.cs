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

        /// <summary>
        /// <inheritdoc cref="IUser.username"/>
        /// </summary>
        [JsonInclude]
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
        /// <see langword="true"/> if the user is banned
        /// </summary>
        public bool isBanned { get; init; }

        /// <summary>
        /// <b>Unused, legacy attribute. For now always null to not disturb existing client code that might rely on its existence. </b><br></br>
        ///Used when user is logged in from third party app (e.g. QQ) <br></br>
        ///ExternalAppDisplayName is the name used in that app(e.g.QQ nickname
        /// </summary>
        public string? externalAppDisplayName { get; init; }

        /// <summary>
        /// <see langword="true"/> only if the user has a verified badge
        /// </summary>
        public bool hasVerifiedBadge { get; init; }

        /// <summary>
        /// The username requested by the client 
        /// </summary>
        public string? requestedUsername { get; init; }

        /// <summary>
        /// <inheritdoc cref="Presence_Type"/>
        /// </summary>
        public Presence_Type presenceType { get; init; }

        /// <summary>
        /// list of previous usernames
        /// </summary>
        public IReadOnlyList<string>? previousUsernames { get; init; }

        /// <summary>
        /// <see langword="true"/> if user is currently online
        /// </summary>
        public bool isOnline { get; init; }

        /// <summary>
        /// <see langword="true"/> if user is deleted/banned/terminated
        /// </summary>
        public bool isDeleted { get; init; }

        /// <summary>
        /// Frequents value for the user
        /// </summary>
        public int friendFrequentScore { get; init; }

        /// <summary>
        /// Frequents rank for the user.
        /// </summary>
        public int friendFrequentRank { get; init; }


        public User() { }

        /// <summary>
        /// constructor for user
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <param name="username">username of the user</param>
        /// <param name="displayName">displayname of the user</param>
        public User(ulong userId, string username, string? displayName = null) : base(userId, username, displayName) { }

        /// <summary>
        /// Deep clones the instance of <see cref="User"/>
        /// </summary>
        /// <returns></returns>
        public override User Clone()
        {
            List<string>? previousUsernamesCopy = null;

            if (previousUsernames != null)
            {
                previousUsernamesCopy = new List<string>(previousUsernames.Count);

                previousUsernamesCopy.AddRange(previousUsernames);
                
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

