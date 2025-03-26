namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// generalized template for any roblox object that has a unique <paramref name="CreationId"/>
    /// </summary>
    public interface ICreation
    {
        /// <summary>
        /// The unique id of the creation; Null if not requested
        /// </summary>
        ulong? CreationId { get; }
    }
}
