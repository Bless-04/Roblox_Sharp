using System.Text.Json.Serialization;

namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// Provides an abstraction of a roblox asset
    /// </summary>
    public interface IAsset
    {
        /// <summary>
        /// The unique id of the <see cref="IAsset"/>
        /// </summary>
        ulong AssetId { get; }
    }

    /// <summary>
    /// Represents a base implementation of a roblox asset
    /// </summary>
    public abstract class Asset : Creation<IAsset>, IAsset
    {
        /// <inheritdoc cref="IAsset.AssetId"/>
        [JsonPropertyName("assetId")]
        public virtual ulong AssetId
        {
            get => base.Id;
            init => base.Id = value;
        }

        /// <summary>
        /// the name of the asset
        /// </summary>
        [JsonPropertyName("assetName")]
        public virtual required string AssetName { get; init; }
    }
}
