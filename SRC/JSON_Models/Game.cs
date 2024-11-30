using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models
{
    //TODO: finish
    sealed public partial class Game
    {
        /// <summary>
        /// the universe id 
        /// </summary>
        [JsonPropertyName("id")]
        public ulong id { get; init; }
        
        /// <summary>
        /// the universe  name
        /// </summary>
        [JsonPropertyName("name")]
        public string? name { get; init; }

        /// <summary>
        /// The description of the universe.
        /// </summary>
        [JsonPropertyName("rootPlaceId")]
        public ulong rootPlaceId { get; init; }
    }
}
