using System;
using System.Text.Json.Serialization;
using Roblox_Sharp.Enums;

namespace Roblox_Sharp.JSON_Models.Users
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
    [JsonSerializable(typeof(User_Presence))]
    public class User_Presence : User
    {
        [JsonInclude]
        /// <summary>
        /// <see cref="Presence_Type"/> type of user
        /// </summary>
        private Presence_Type userPresenceType {init => presenceType = value;}

        public string? lastLocation { get; init; }

        /// <summary>
        /// unique place id
        /// </summary>
        public ulong? placeId { get; init; }

        public ulong? rootPlaceId { get; init; }

        /// <summary>
        /// unique game id
        /// </summary>
        public string? gameId { get; init; }

        public ulong? universeId { get; init; }

        /// <summary>
        /// exact date and time user was last online
        /// </summary>
        public DateTime lastOnline { get; init; }

        public DateTime invisibleModeExpiry { get; init; }
    }
}
