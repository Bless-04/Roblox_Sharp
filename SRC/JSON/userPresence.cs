﻿using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON
{
    public class userPresence
    {

        [JsonPropertyName("userPresenceType")]
        public Enums.Presence userPresenceType { get; init; }

        [JsonPropertyName("lastLocation")]
        public string? lastLocation { get; init; }

        [JsonPropertyName("placeId")]
        public int? placeId  { get; init; }

        [JsonPropertyName("rootPlaceId")]
        public int? rootPlaceId { get; init; }

        [JsonPropertyName("gameId")]
        public string? gameId { get; init; }

        [JsonPropertyName("universeId")]
        public int? universeId { get; init; }

        [JsonPropertyName("userId")]
        public ulong? userId { get; init; }

        [JsonPropertyName("lastOnline")]
        public DateTime? lastOnline { get; init; }

        [JsonPropertyName("invisibleModeExpiry")]
        public DateTime? invisibleModeExpiry { get; init; }

    }



    /**example return 
     * {
  "userPresences": [
    {
      "userPresenceType": 0,
      "lastLocation": "string",
      "placeId": 0,
      "rootPlaceId": 0,
      "gameId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "universeId": 0,
      "userId": 0,
      "lastOnline": "2024-09-12T16:24:42.067Z",
      "invisibleModeExpiry": "2024-09-12T16:24:42.067Z"
    }
  ]
}
    */

}
