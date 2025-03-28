﻿using Roblox_Sharp.Enums;
using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;
using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

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
    public class Presence : Creation<IUser>, IUser, ICloneable<User.Presence>
    {
        /// <inheritdoc/>
        [JsonPropertyName("userId")]
        public ulong UserId
        {
            get => base.CreationId ?? throw new NotRequestedException(nameof(UserId));
            init => base.CreationId = value;
        }

        /// <summary>
        /// <see cref="UserPresenceType"/> type of user
        /// </summary>
        [JsonPropertyName("presenceType")]
        public UserPresenceType PresenceType { get; init; }

        [JsonPropertyName("lastLocation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LastLocation { get; init; }

        /// <summary>
        /// unique place id
        /// </summary>
        [JsonPropertyName("placeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? PlaceId { get; init; }

        [JsonPropertyName("rootPlaceId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? RootPlaceId { get; init; }

        /// <summary>
        /// unique game id
        /// </summary>
        [JsonPropertyName("gameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? GameId { get; init; }

        /// <summary>
        /// unique universe id
        /// </summary>
        [JsonPropertyName("universeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? UniverseId { get; init; }

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
