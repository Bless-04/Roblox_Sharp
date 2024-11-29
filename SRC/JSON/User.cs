using System;
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
        public User(ulong userId) => this.id = userId;

       
        public User(string name,string? displayName = null)
        {
            this.name = name;
            this.displayName = displayName;
        }

        public User(ulong id,string name,string? displayName = null) { 
            this.id = id; 
            this.name = name; 
            this.displayName = displayName; 
        }

        
        public User() { }

        /// <summary>
        /// unique user id for the user
        /// </summary>
        [JsonPropertyName("id")]
        public override ulong id  { get; protected set; }
            public ulong userId
            {
                set
                {
                    if (id == default) this.id = value;
                    else throw new Exception("User.id has already been set");
                }
            }
           
        /// <summary>
        /// unique username for the user
        /// </summary>
        [JsonPropertyName("name")]
        public string name { get; private set; }
            public string username
            {
                set
                {
                    if (name == default) this.name = value;
                    else throw new Exception("User.name has already been set");
                }
            }


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
        public Presence presenceType { get; init; }

        [JsonPropertyName("previousUsernames")]
        public string[]? previousUsernames { get; init; }

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
        public override string ToString() => $"{displayName} @ {name} ({this.id})";
    }

    /// <summary>
    /// class used to serialize User POST based requests
    /// </summary>
    public sealed class UserPOST
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

        public UserPOST(ulong[] userIds, bool excludeBannedUsers=false)
        {
            this.userIds = userIds;
            this.excludeBannedUsers = excludeBannedUsers;
        }

        public UserPOST(string[] usernames, bool excludeBannedUsers=false)
        {
            this.usernames = usernames;
            this.excludeBannedUsers = excludeBannedUsers;
        }
       
    }

}

