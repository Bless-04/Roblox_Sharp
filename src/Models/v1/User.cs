using System;
using System.Text.Json.Serialization;
using Roblox_Sharp.Abstractions;

namespace Roblox_Sharp.Models.v1
{
    /// <summary>
    /// used to deserialize <see cref="Endpoints.Users_v1.Get_UserAsync(ulong)"/>
    /// <see href="https://users.roblox.com//docs/index.html">Users v1</see>
    /// </summary>
    public partial class User : Abstractions.User,
        IUser
    {
        #region Properties
        /// <summary>
        /// The users display name
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; } = string.Empty;

        /// <summary>
        /// The users description 
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// creation date and time of user; When the User signed up
        /// </summary>
        [JsonPropertyName("created")]
        public DateTime Created { get; init; }

        /// <summary>
        /// <see langword="true"/> if the user is banned
        /// </summary>
        [JsonPropertyName("isBanned")]
        public bool IsBanned { get; init; }

        /// <summary>
        /// <see langword="true"/> only if the user has a verified badge
        /// </summary>
        [JsonPropertyName("hasVerifiedBadge")]
        public bool HasVerifiedBadge { get; init; }
        #endregion

        #region Special Properties

        [JsonInclude]
        [JsonPropertyName("id")]
        private ulong id { init => base.Id = value; }

        
        [JsonInclude]
        [JsonPropertyName("name")]
        private string name { init => base.Username = value; }
        

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
        #endregion

    }
}

