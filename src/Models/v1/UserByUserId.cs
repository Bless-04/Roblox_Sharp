using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.v1
{
    /* {
      "hasVerifiedBadge": true,
      "id": 1,
      "name": "Roblox",
      "displayName": "Roblox"
    },*/

    /// <summary>
    /// used to deserialize <see cref="Endpoints.Users_v1.Get_UsersAsync(System.Collections.Generic.IEnumerable{ulong}, bool)"/>
    /// </summary>
    public class UserByUserId : UserAuthenticated
    {
       
        /// <inheritdoc cref="UserInfo.HasVerifiedBadge"/>
        [JsonPropertyName("hasVerifiedBadge")]
        public required bool HasVerifiedBadge { get; init; }
    }
}
