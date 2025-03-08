using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;
using System.Text.Json.Serialization;
using System;
namespace Roblox_Sharp.Models
{
    //TODO: finish
    /// <summary>
    /// Represents a game
    /// </summary>
    [Obsolete("This class is not finished")]
    public partial class Game : Creation<Game>, ICloneable<Game>
    {
        /// <summary>
        /// the universe id 
        /// </summary>
        [JsonPropertyName("universeId")]
        public ulong UniverseId
        {
            get => base._id ?? throw new NotRequestedException(nameof(UniverseId));
            init => base._id = value;
        }

        /// <summary>
        /// the universe name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; init; }

        /// <summary>
        /// The description of the universe.
        /// </summary>
        [JsonPropertyName("rootPlaceId")]
        public ulong RootPlaceId { get; init; }

        /// <summary>
        /// Deep Clones the instance of <see cref="Game"/>
        /// </summary>
        /// <returns></returns>
        public Game Clone() => new Game
        {
            UniverseId = this.UniverseId,
            Name = this.Name,
            RootPlaceId = this.RootPlaceId
        };
    }
}
