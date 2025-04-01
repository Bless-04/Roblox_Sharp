using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.v1
{

    /*
     {
  "id": 0,
  "name": "string",
  "displayName": "string"
}
*/

    /// <summary>
    /// used to deserialize <see cref="Endpoints.Users_v1.Get_AuthenticatedAsync"/>
    /// </summary>
    [DebuggerDisplay("{DisplayName}@{Username} (ID {UserId})")]
    public class UserAuthenticated : Abstractions.User
    {
        /// <inheritdoc/>
        [JsonPropertyName("id")]
        public override required ulong UserId
        {
            get => base.Id;
            init => base.Id = value;
        }

        /// <inheritdoc/>
        [JsonPropertyName("name")]
        public override required string Username
        {
            get => base.Username;
            init => base.Username = value;
        }

        /// <summary>
        /// The users display name
        /// </summary>
        [JsonPropertyName("displayName")]
        public required string DisplayName { get; init; }
    }
}
