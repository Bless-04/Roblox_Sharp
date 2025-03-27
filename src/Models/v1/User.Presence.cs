using System;
using System.Text.Json.Serialization;
using Roblox_Sharp.Abstractions;

namespace Roblox_Sharp.Models.v1;

public partial class User
{
    /**
     * example return 
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
}*/
    public partial class Presence : Abstractions.User, ICloneable<User.Presence>
    {
        /// <summary>
        /// <see cref="User.Presence.Type"/> type of user
        /// </summary>
        [JsonPropertyName("presenceType")]
        public User.Presence.Type PresenceType { get; init; }

        [JsonPropertyName("lastLocation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required string LastLocation { get; init; }

        /// <summary>
        /// unique place id
        /// </summary>
        [JsonPropertyName("placeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong PlaceId { get; init; }

        [JsonPropertyName("rootPlaceId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong RootPlaceId { get; init; }

        /// <summary>
        /// unique game id
        /// </summary>
        [JsonPropertyName("gameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GameId { get; init; }

        /// <summary>
        /// unique universe id
        /// </summary>
        [JsonPropertyName("universeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong UniverseId { get; init; }

        /// <summary>
        /// exact date and time user was last online
        /// </summary>
        [JsonPropertyName("lastOnline")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime LastOnline { get; init; }

        [JsonPropertyName("invisibleModeExpiry")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime InvisibleModeExpiry { get; init; }

        /// <summary>
        /// Deep Clones the instance of <see cref="User.Presence"/>
        /// </summary>
        /// <returns></returns>
        public Presence Clone() => new()
        {
            UserId = UserId,
            Username = Username,
            PresenceType = PresenceType,
            LastLocation = LastLocation,
            PlaceId = PlaceId,
            RootPlaceId = RootPlaceId,
            GameId = GameId,
            UniverseId = UniverseId,
            LastOnline = LastOnline,
            InvisibleModeExpiry = InvisibleModeExpiry
        };
    }
}
