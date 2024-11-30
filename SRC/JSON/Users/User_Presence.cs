using System;
using System.Text.Json.Serialization;
using Roblox_Sharp.Enums;

namespace Roblox_Sharp.JSON.Users
{
    //Presence is an Instance of User
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

    sealed public class User_Presence : User
    {
        /// <summary>
        /// <see cref="Presence_Type"/> type of user
        /// </summary>
        [JsonPropertyName("userPresenceType")]
        public Presence_Type userPresenceType
        {
            get => presenceType;
            init => presenceType = value;
        }

        [JsonPropertyName("lastLocation")]
        public string? lastLocation { get; init; }

        /// <summary>
        /// unique place id
        /// </summary>
        [JsonPropertyName("placeId")]
        public ulong? placeId { get; init; }

        [JsonPropertyName("rootPlaceId")]
        public ulong? rootPlaceId { get; init; }

        /// <summary>
        /// unique game id
        /// </summary>
        [JsonPropertyName("gameId")]
        public string? gameId { get; init; }

        [JsonPropertyName("universeId")]
        public ulong? universeId { get; init; }

        /// <summary>
        /// unique user id
        /// </summary>
        [JsonPropertyName("userId")]
        [JsonIgnore]
        private ulong _userId
        {
            get => userId;
            init => userId = value;
        }

        /// <summary>
        /// exact date and time user was last online
        /// </summary>
        [JsonPropertyName("lastOnline")]
        public DateTime? lastOnline { get; init; }

        [JsonPropertyName("invisibleModeExpiry")]
        public DateTime? invisibleModeExpiry { get; init; }
    }
}
