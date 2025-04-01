using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.v1
{
    /* Same as UserByUserId but + requestedUsername
     {
      "requestedUsername": "string",
      "hasVerifiedBadge": true,
      "id": 0,
      "name": "string",
      "displayName": "string"
    }*/

    /// <summary>
    /// used to deserialize <see cref="Endpoints.Users_v1.Get_UsersAsync(System.Collections.Generic.IEnumerable{string}, bool)"/>
    /// </summary>
    public class UserByUsername : UserByUserId
    {
        /// <summary>
        /// The requested username
        /// </summary>
        [JsonPropertyName("requestedUsername")]
        public required string RequestedUsername { get; init; }
    }
}
