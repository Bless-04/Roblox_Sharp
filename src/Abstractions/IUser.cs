namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// represents any User based request that contains the unique user id
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// the Unique numeric id of the <see cref="IUser"/>.
        /// </summary>
        ulong UserId { get; }
    }
}
