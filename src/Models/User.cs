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
    public class User() : IUser<User>, ICloneable<User>, IFormattable
    {
        /// <inheritdoc cref="userId"/>
        [JsonInclude]
        private ulong? id { get; init; }

        /// <inheritdoc/>
        public ulong userId
        {
            get => id ?? throw new NotRequestedException(nameof(userId));
            init => id = value;
        }

        /// <summary>
        /// unique username for the user
        /// </summary>
        public string username
        {
            get => name;
            init => name = value;
        }

        /// <summary>
        /// <inheritdoc cref="username"/>
        /// </summary>
        [JsonInclude]
        private string name { get; init; } = string.Empty;

        /// <summary>
        /// display name for the user <br></br>
        /// <see langword="null"/> if the display name is the same as the username <br></br>
        /// this indicates that the user has never set a display name
        /// string representation of the user <br></br> 
        /// </summary>
        private string? _displayName { get; init; }

        /// <inheritdoc cref="_displayName"/>
        public string? displayName
        {
            get => _displayName;
            init => _displayName = (value != null && value.Equals(username)) ? null : value;
        }

        /// <summary>
        /// constructor for user
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <param name="username">username of the user</param>
        /// <param name="displayName">displayname of the user</param>
        public User(ulong userId, string username, string? displayName = null) : this()
        {
            this.userId = userId;
            this.username = username;
            this.displayName = displayName;
        }

        /// <summary>
        /// description for the user
        /// </summary>
        public string? description { get; init; }

        /// <summary>
        /// creation date and time of user
        /// </summary>
        public DateTime created { get; init; }

        /// <summary>
        /// creation date and time in the same format as the roblox website 
        /// </summary>
        public string created_string => created.ToString("d");

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
        /// <inheritdoc cref="PresenceType"/>
        /// </summary>
        public PresenceType presenceType { get; init; }

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

        /// <summary>
        /// <inheritdoc cref="userId"/>
        /// </summary>
        /// <param name="userId"></param>
        public static explicit operator User(ulong userId) => new User() { userId = userId };

        /// <summary>
        /// <inheritdoc cref="username"/>
        /// </summary>
        /// <param name="username"></param>
        public static explicit operator User(string username) => new User() { username = username };

        /// <inheritdoc/>
        public User Clone() => new User()
        {
            userId = userId,
            username = username,
            displayName = displayName,
            description = description,
            created = created,
            isBanned = isBanned,
            externalAppDisplayName = externalAppDisplayName,
            hasVerifiedBadge = hasVerifiedBadge,
            requestedUsername = requestedUsername,
            presenceType = presenceType,
            previousUsernames = previousUsernames?.ToList(),
            isOnline = isOnline,
            isDeleted = isDeleted,
            friendFrequentScore = friendFrequentScore,
            friendFrequentRank = friendFrequentRank
        };

        ///<inheritdoc cref="IUser.operator &lt;"/>
        public static bool operator <(User left, User right) => (IUser)left < (IUser)right;

        /// <inheritdoc cref="IUser.operator >"/>
        public static bool operator >(User left, User right) => (IUser)left > (IUser)right;

        /// <inheritdoc cref="IUser.GetHashCode"/>
        public override int GetHashCode() => userId.GetHashCode();

        /// <inheritdoc cref="IUser{User}.ToString"/> displayname@username (ID id)
        public override string ToString() => $"{displayName}@{username} (ID {userId})";

        /// <inheritdoc cref="IUser.Equals"/>
        public override bool Equals(object? obj) => obj is User user && userId == user.userId;

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
                "id" => $"(ID {userId}) ",
                "name" => "@{username} ",
                "display" => displayName + ' ' ?? username,
                "joined" => created_string + ' ',
                _ => throw new FormatException()
            };
    }
}

