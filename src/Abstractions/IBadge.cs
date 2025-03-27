namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// Represents a badge
    /// </summary>
    public interface IBadge 
    {   
        /// <summary>
        /// The unique id of the <see cref="IBadge"/>
        /// </summary>
        ulong BadgeId { get; }
    }
}
