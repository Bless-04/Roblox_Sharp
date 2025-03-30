using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.v1
{
    /* example {
      "hasVerifiedBadge": true,
      "id": 1,
      "name": "Roblox",
      "displayName": "Roblox"
    },*/


    public class UserByUserId : Abstractions.User
    {
        [JsonPropertyName("id")]
        private ulong id { init => base.Id = value; }

        [JsonPropertyName("name")]
        private string name { init => base.Username = value; }


        [JsonPropertyName("hasVerifiedBadge")]
        public bool HasVerifiedBadge { get; init; }

        [JsonPropertyName("displayName")]
        public required string DisplayName { get; init; }
    }
}
