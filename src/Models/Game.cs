using System.Text.Json.Serialization;

using Roblox_Sharp.Abstractions;
namespace Roblox_Sharp.Models
{
    //TODO: finish
    /// <summary>
    /// Represents a game
    /// </summary>
    public partial class Game : Creation<Game>
    {
        /// <summary>
        /// the universe id 
        /// </summary>
        [JsonPropertyName("universeId")]
        public ulong UniverseId
        {
            get => base.Id;
            init => base.Id = value;
        }

        /// <summary>
        /// the universe name
        /// </summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
        public Game Clone() => new()
        {
            UniverseId = this.UniverseId,
            Name = this.Name,
            RootPlaceId = this.RootPlaceId
        };
    }
}
