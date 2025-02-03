using Roblox_Sharp.Enums;
using Roblox_Sharp.Framework;
using System;

namespace Roblox_Sharp.Models
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
    public class User_Presence : IUser , ICloneable<User_Presence>
    {
        /// <inheritdoc/>
        public ulong userId { get; init; }

        /// <summary>
        /// <see cref="Presence_Type"/> type of user
        /// </summary>
        public Presence_Type presenceType { get; init; }

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

        /// <summary>
        /// unique universe id
        /// </summary>
        public ulong? universeId { get; init; }

        /// <summary>
        /// exact date and time user was last online
        /// </summary>
        public DateTime lastOnline { get; init; }

        public DateTime invisibleModeExpiry { get; init; }

        /// <summary>
        /// Deep Clones the instance of <see cref="User_Presence"/>
        /// </summary>
        /// <returns></returns>
        public User_Presence Clone() => new User_Presence()
        {
            presenceType = presenceType,
            lastLocation = lastLocation,
            placeId = placeId,
            rootPlaceId = rootPlaceId,
            gameId = gameId,
            universeId = universeId,
            lastOnline = lastOnline,
            invisibleModeExpiry = invisibleModeExpiry
        };
    }
}
