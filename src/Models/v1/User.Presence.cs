using Roblox_Sharp.Abstractions;
using System;
using System.Text.Json.Serialization;

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
    public partial class Presence : Creation<IUser>, IUser
    {
        /// <inheritdoc/>
        [JsonPropertyName("userId")]
        public ulong UserId
        {
            get => base.Id;
            init => base.Id = value;
        }

        /// <summary>
        /// <see cref="User.Presence.Type"/> type of user
        /// </summary>
        [JsonPropertyName("presenceType")]
        public User.Presence.Type PresenceType { get; init; }

        [JsonPropertyName("lastLocation")]
        public required string LastLocation { get; init; }

        /// <summary>
        /// unique place id
        /// </summary>
        [JsonPropertyName("placeId")]
        public ulong PlaceId { get; init; }

        [JsonPropertyName("rootPlaceId")]
        public ulong RootPlaceId { get; init; }

        /// <summary>
        /// unique game id
        /// </summary>
        [JsonPropertyName("gameId")]
        public required string GameId { get; init; } // why is this a string

        /// <summary>
        /// unique universe id
        /// </summary>
        [JsonPropertyName("universeId")]
        public ulong UniverseId { get; init; }

        /// <summary>
        /// exact date and time user was last online
        /// </summary>
        [JsonPropertyName("lastOnline")]
        public DateTime LastOnline { get; init; }

        [JsonPropertyName("invisibleModeExpiry")]
        public DateTime InvisibleModeExpiry { get; init; }
    }
}
