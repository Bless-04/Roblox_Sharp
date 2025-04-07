using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.v1
{
    /*
     {
  "description": "string",
  "created": "2025-04-01T03:44:14.631Z",
  "isBanned": true,
  "externalAppDisplayName": "string",
  "hasVerifiedBadge": true,
  "id": 0,
  "name": "string",
  "displayName": "string"
}
     */
    /// <summary>
    /// used to deserialize <see cref="Endpoints.Users_v1.Get_UserAsync(ulong)"/>
    /// <see href="https://users.roblox.com//docs/index.html">Users v1</see>
    /// </summary>
    public class DetailedUser : UserAuthenticated
    {
        #region Properties
        /// <summary>
        /// The users description 
        /// </summary>
        [JsonPropertyName("description")]
        public required string Description { get; init; } 

        /// <summary>
        /// creation date and time of user; When the User signed up
        /// </summary>
        [JsonPropertyName("created")]
        public required DateTime Created { get; init; }

        /// <summary>
        /// <see langword="true"/> if the user is banned
        /// </summary>
        [JsonPropertyName("isBanned")]
        public required bool IsBanned { get; init; }

        /// <summary>
        /// <see langword="true"/> only if the user has a verified badge
        /// </summary>
        [JsonPropertyName("hasVerifiedBadge")]
        public required bool HasVerifiedBadge { get; init; }
        #endregion
        /*
        /// <summary>
        /// <b>Unused, legacy attribute. For now always <see langword="null"/> to not disturb existing client code that might rely on its existence. </b><br></br>
        ///Used when user is logged in from third party app (e.g. QQ) <br></br>
        ///ExternalAppDisplayName is the name used in that app(e.g.QQ nickname
        /// </summary>
        //[JsonPropertyName("externalAppDisplayName")]
        //public string? ExternalAppDisplayName { get; } = null;
        */
        /// <summary>
        /// creation date and time in the same format as the roblox website 
        /// </summary>
        [JsonIgnore]
        public string CreatedString => Created.ToString("d");
    }
}

