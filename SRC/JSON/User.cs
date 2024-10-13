using Newtonsoft.Json;
using System.Text.Json.Serialization;
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
        
        public User(ulong id) => this.id = id;
        public User(string name,string? displayName = null)
        {
            this.name = name;
            this.displayName = displayName;
        }

        public User(ulong id,string name,string? displayName = null) { this.id = id; this.name = name; this.displayName = displayName; }

        [Newtonsoft.Json.JsonConstructor]
        public User() { }

        /// <summary>
        /// unique user id for the user
        /// </summary>
        [JsonProperty("id")]
        override public ulong id { get; init; }
        
        /// <summary>
        /// unique username for the user
        /// </summary>
        [JsonProperty("name")]
        public string name { get; init; }

        /// <summary>
        /// display name for the user
        /// </summary>
        [JsonProperty("displayName")]
        public string? displayName { get; init; }
        
        /// <summary>
        /// description for the user
        /// </summary>
        [JsonProperty("description")]
        public string? description { get; init; }

        /// <summary>
        /// creation date and time of user
        /// </summary>
        [JsonProperty("created")]
        public DateTime created { get; init; }

        /// <summary>
        /// <b>true</b> if user is banned, <b>false</b> otherwise
        /// </summary>
        [JsonProperty("isBanned")]
        public bool isBanned { get; init; }

        [JsonProperty("externalAppDisplayName")]
        public string? externalAppDisplayName { get; init; }

        [JsonProperty("hasVerifiedBadge")]
        public bool hasVerifiedBadge { get; init; }

        [JsonProperty("requestedUsername")]
        public string? requestedUsername { get; init; }
        
        [JsonPropertyName("presenceType")]
        public Enums.Presence presenceType { get; init; }

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

    }

    public class UserPOST
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

