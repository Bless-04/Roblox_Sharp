using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Roblox_Sharp.Models.v1
{
    /* example {
      "hasVerifiedBadge": true,
      "id": 1,
      "name": "Roblox",
      "displayName": "Roblox"
    },*/


    public class UserByUserIds : Abstractions.User
    {
        [JsonPropertyName("hasVerifiedBadge")]
        public bool hasVerifiedBadge { get; init; }

        [JsonPropertyName("name")]
        public required string name { init => base.Username = value; }

        [JsonPropertyName("displayName")]
        public required string DisplayName { get; init; }
    }
}
