using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    [DebuggerDisplay("@{username} (ID {userId})")]
    public partial class User() : Creation<IUser>, IUser, ICloneable<User>, IFormattable
    {
        /// <summary>
        /// constructor for user
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <param name="username">username of the user</param>
        /// <param name="displayName">displayname of the user</param>
        public User(ulong userId, string username, string? displayName = null) : this()
        {
            this.UserId = userId;
            this.Username = username;
            this.DisplayName = displayName;
        }

        #region Properties
        /// <inheritdoc/>
        [JsonPropertyName("userId")]
        public ulong UserId
        {
            get => base._id ?? throw new NotRequestedException(nameof(UserId));
            init => base._id = value;
        }

        /// <summary>
        /// unique username for the user
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; init; }

        /// <summary>
        /// <inheritdoc cref="Username"/>
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("name")]
        private string _name { init => Username = value; }

        /// <summary>
        /// display name for the user <br></br>
        /// <see langword="null"/> if the display name is the same as the username <br></br>
        /// this indicates that the user has never set a display name
        /// string representation of the user <br></br> 
        /// </summary>
        private string? _displayName { get; init; }


        /// <inheritdoc cref="_displayName"/>
        [JsonPropertyName("displayName")]
        public string? DisplayName
        {
            get => _displayName;
            init => _displayName = (value != null && value.Equals(Username)) ? null : value;
        }

        /// <summary>
        /// description for the user
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; init; }

        /// <summary>
        /// creation date and time of user
        /// </summary>
        [JsonPropertyName("created")]
        public DateTime Created { get; init; }

        /// <summary>
        /// creation date and time in the same format as the roblox website 
        /// </summary>
        [JsonIgnore]
        public string CreatedString => Created.ToString("d");

        /// <summary>
        /// <see langword="true"/> if the user is banned
        /// </summary>
        [JsonPropertyName("isBanned")]
        public bool IsBanned { get; init; }

        /// <summary>
        /// <b>Unused, legacy attribute. For now always null to not disturb existing client code that might rely on its existence. </b><br></br>
        ///Used when user is logged in from third party app (e.g. QQ) <br></br>
        ///ExternalAppDisplayName is the name used in that app(e.g.QQ nickname
        /// </summary>
        [JsonPropertyName("externalAppDisplayName")]
        public string? ExternalAppDisplayName { get; init; }

        /// <summary>
        /// <see langword="true"/> only if the user has a verified badge
        /// </summary>
        [JsonPropertyName("hasVerifiedBadge")]
        public bool HasVerifiedBadge { get; init; }

        /// <summary>
        /// The username requested by the client 
        /// </summary>
        [JsonPropertyName("requestedUsername")]
        public string? RequestedUsername { get; init; }

        /// <summary>
        /// <inheritdoc cref="UserPresenceType"/>
        /// </summary>
        [JsonPropertyName("presenceType")]
        public UserPresenceType PresenceType { get; init; }

        /// <summary>
        /// list of previous usernames
        /// </summary>
        [JsonPropertyName("previousUsernames")]
        public IReadOnlyList<string>? PreviousUsernames { get; init; }

        /// <summary>
        /// <see langword="true"/> if user is currently online
        /// </summary>
        [JsonPropertyName("isOnline")]
        public bool IsOnline { get; init; }

        /// <summary>
        /// <see langword="true"/> if user is deleted/banned/terminated
        /// </summary>
        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; init; }

        /// <summary>
        /// Frequents value for the user
        /// </summary>
        [JsonPropertyName("friendFrequentScore")]
        public int FriendFrequentScore { get; init; }

        /// <summary>
        /// Frequents rank for the user.
        /// </summary>
        [JsonPropertyName("friendFrequentRank")]
        public int FriendFrequentRank { get; init; }

        #endregion
        #region Operators
        /// <summary>
        /// <inheritdoc cref="UserId"/>
        /// </summary>
        /// <param name="userId"></param>
        public static explicit operator User(ulong userId) => new() { UserId = userId };

        /// <summary>
        /// <inheritdoc cref="Username"/>
        /// </summary>
        /// <param name="username"></param>
        public static explicit operator User(string username) => new() { Username = username };

        #endregion
        #region Functions
        /// <inheritdoc/>
        public User Clone() => new()
        {
            UserId = UserId,
            Username = Username,
            DisplayName = DisplayName,
            Description = Description,
            Created = Created,
            IsBanned = IsBanned,
            ExternalAppDisplayName = ExternalAppDisplayName,
            HasVerifiedBadge = HasVerifiedBadge,
            RequestedUsername = RequestedUsername,
            PresenceType = PresenceType,
            PreviousUsernames = PreviousUsernames?.ToList(),
            IsOnline = IsOnline,
            IsDeleted = IsDeleted,
            FriendFrequentScore = FriendFrequentScore,
            FriendFrequentRank = FriendFrequentRank
        };

        /// <inheritdoc cref="IUser.GetHashCode"/>
        public override int GetHashCode() => UserId.GetHashCode();

        /// <inheritdoc cref="IUser.Equals"/>
        public override bool Equals(object? obj) => obj is IUser user && UserId == user.UserId;

        /// <inheritdoc cref="IUser{User}.ToString"/> displayname@username (ID id)
        public override string ToString() => $"{DisplayName}@{Username} (ID {UserId})";

        /// /// <summary>
        /// Formats the user information based on the provided format string.
        /// Supported format strings:
        /// <list type="table">
        ///   <listheader>
        ///     <term>Format</term>
        ///     <description>Output</description>
        ///   </listheader>
        ///   <item>
        ///     <term>"id"</term>
        ///     <description>Returns the user ID.</description>
        ///   </item>
        ///   <item>
        ///     <term>"name"</term>
        ///     <description>Returns the username with an '@' prefix.</description>
        ///   </item>
        ///   <item>
        ///     <term>"display"</term>
        ///     <description>Returns the display name.</description>
        ///   </item>
        ///   <item>
        ///     <term>"joined"</term>
        ///     <description>Returns the user's join date.</description>
        ///   </item>
        /// </list>
        /// </summary>
        /// <returns>
        /// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)"/>
        /// </returns>
        public string ToString(string? format, IFormatProvider? formatProvider) => format == null ? ToString()
            : format switch
            {
                //user id 
                "id" => $"(ID {UserId}) ",
                "name" => "@{username} ",
                "display" => DisplayName + ' ' ?? Username,
                "joined" => CreatedString + ' ',
                _ => throw new FormatException()
            };
        #endregion
    }
}

