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
    public sealed class UserByUsername() : UserByUserId
    {
        [JsonPropertyName("requestedUsername")]
        public string RequestedUsername { get; }
    }
}
