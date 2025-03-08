using System.Text.Json.Serialization;
using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;


namespace Roblox_Sharp.Models;

public partial class Avatar
{
    /// <summary>
    /// Assets that a players Avatar can equip
    /// </summary>
    public partial class Asset : Creation<IAsset>, IAsset, ICloneable<Asset>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [JsonPropertyName("assetId")]
        public ulong AssetId
        {
            get => base._id ?? throw new NotRequestedException(nameof(AssetId));
            init => base._id = value;
        }

        /// <summary>
        /// the name of the asset
        /// </summary>
        [JsonPropertyName("assetName")]
        public string? AssetName { get; init; }

        /// <summary>
        /// <inheritdoc cref="AssetName"/>
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("name")]
        private string _name
        {
            init => AssetName = value;
        }

        /// <summary>
        /// <inheritdoc cref="Roblox_Sharp.Enums.AssetType"/>
        /// </summary>
        [JsonPropertyName("assetType")]
        public Avatar.Asset.Type AssetType { get; init; }

        [JsonPropertyName("currentVersionId")]
        public ulong CurrentVersionId { get; init; }

        /// <summary>
        /// <inheritdoc cref="Metadata"/>
        /// </summary>
        [JsonPropertyName("meta")]
        public Metadata Meta { get; init; }

        /// <summary>
        /// Deep Clones the instance of <see cref="Avatar.Asset"/>
        /// </summary>
        /// <returns></returns>
        public Avatar.Asset Clone() =>
            new()
            {
                AssetId = AssetId,
                AssetName = AssetName,
                AssetType = AssetType,
                CurrentVersionId = CurrentVersionId,
                Meta = Meta
            };
    }
}
