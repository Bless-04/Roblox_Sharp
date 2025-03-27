namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// generalized template for any roblox object that has a unique <see cref="ICreation.Id"/>
    /// </summary>
    public interface ICreation
    {
        /// <summary>
        /// The unique id of the creation
        /// </summary>
        ulong Id { get; }
    }
}
