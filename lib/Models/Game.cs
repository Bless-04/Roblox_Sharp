using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    //TODO: finish
    public partial class Game
    {
        [JsonInclude]
        protected ulong id { init => universeId = value; }
        
        /// <summary>
        /// the universe id 
        /// </summary>
        public ulong universeId { get; init; }
        
        /// <summary>
        /// the universe  name
        /// </summary>
        public string? name { get; init; }

        /// <summary>
        /// The description of the universe.
        /// </summary>
        public ulong rootPlaceId { get; init; }
    }
}
