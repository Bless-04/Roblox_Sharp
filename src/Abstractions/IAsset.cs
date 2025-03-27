namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// Represents an asset
    /// </summary>
    public interface IAsset
    {
        /// <summary>
        /// The unique id of the <see cref="IAsset"/>
        /// </summary>
        ulong AssetId { get; }
    }
}
