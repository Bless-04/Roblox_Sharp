using Roblox_Sharp.Framework;
namespace Roblox_Sharp.Models
{
    //TODO: finish
    /// <summary>
    /// Represents a game
    /// </summary>
    public partial class Game : ICreation , ICloneable<Game>
    {
        /// <summary>
        /// the universe id 
        /// </summary>
        public ulong universeId { get; init; }

        ulong ICreation.id => universeId;

        /// <summary>
        /// the universe  name
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
