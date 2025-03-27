using System;
using System.Text.Json.Serialization;
using Roblox_Sharp.Abstractions;

namespace Roblox_Sharp.Models.v1
{
    /// <summary>
    /// class used to serialize User v1 based requests <br/>
    /// <see href="https://users.roblox.com/v1/users/1">Request Url</see>
    /// </summary>
    public partial class User : Abstractions.User,
        IUser, ICloneable<User>, IFormattable
    {
        /// <summary>
        /// The users display name
        /// </summary>
        [JsonPropertyName("displayName")]
        public required string DisplayName { get; init; }

        /// <summary>
        /// The users description 
        /// </summary>
        [JsonPropertyName("description")]
        public required string Description { get; init; }

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

        #region Ignored

        [JsonInclude]
        [JsonPropertyName("id")]
        private ulong _id { init => base.Id = value; }

        [JsonInclude]
        [JsonPropertyName("name")]
        private string _name { init => base.Username = value; }

        /// <summary>
        /// <b>Unused, legacy attribute. For now always null to not disturb existing client code that might rely on its existence. </b><br></br>
        ///Used when user is logged in from third party app (e.g. QQ) <br></br>
        ///ExternalAppDisplayName is the name used in that app(e.g.QQ nickname
        /// </summary>
        //[JsonPropertyName("externalAppDisplayName")]
        [JsonIgnore]
        public string? ExternalAppDisplayName => null;

        /// <summary>
        /// creation date and time in the same format as the roblox website 
        /// </summary>
        [JsonIgnore]
        public string CreatedString => Created.ToString("d");
        #endregion

        /// <inheritdoc cref="User"/>
        public User Clone() => new()
        {
            UserId = Id,
            Username = Username,
            DisplayName = DisplayName,
            Description = Description,
            Created = Created,
            IsBanned = IsBanned,
            HasVerifiedBadge = HasVerifiedBadge,
        };
    }
}

