using Roblox_Sharp.Framework;

namespace Roblox_Sharp.Models
{
    //TODO: finish
    public partial class Game : ICreation
    {
        /// <summary>
        /// the universe id 
        /// </summary>
        public ulong universeId
        {
            get => base.id;
            init => base.id = value;
        }

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
