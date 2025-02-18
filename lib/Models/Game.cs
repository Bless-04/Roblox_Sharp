using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;
namespace Roblox_Sharp.Models
{
    //TODO: finish
    /// <summary>
    /// Represents a game
    /// </summary>
    public partial class Game : Creation, ICloneable<Game>
    {
        /// <summary>
        /// the universe id 
        /// </summary>
        public ulong universeId
        {
            get => base.id ?? throw new NotRequestedException(nameof(universeId));
            init => base.id = value;
        }

        /// <summary>
        /// the universe name
        /// </summary>
        public string? name { get; init; }

        /// <summary>
        /// The description of the universe.
        /// </summary>
        public ulong rootPlaceId { get; init; }

        /// <summary>
        /// Deep Clones the instance of <see cref="Game"/>
        /// </summary>
        /// <returns></returns>
        public Game Clone() => new Game()
        {
            universeId = this.universeId,
            name = this.name,
            rootPlaceId = this.rootPlaceId
        };
    }
}
