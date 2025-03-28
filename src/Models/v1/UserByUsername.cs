using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Roblox_Sharp.Models.v1
{
    /* Example
     {
      "requestedUsername": "string",
      "hasVerifiedBadge": true,
      "id": 0,
      "name": "string",
      "displayName": "string"
    }*/
    public sealed class UserByUsername : UserByUserIds
    {
        [JsonPropertyName("requestedUsername")]
        public string requestedUsername { get; }
    }
}
