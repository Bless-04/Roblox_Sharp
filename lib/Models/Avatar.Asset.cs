using System.Text.Json.Serialization;
using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;


namespace Roblox_Sharp.Models;

public partial class Avatar
{
    /// <summary>
    /// Assets that a players Avatar can equip
    /// </summary>
    public partial class Asset : Creation, IAsset, ICloneable<Asset>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ulong assetId
        {
            get => base.id ?? throw new NotRequestedException(nameof(assetId));
            init => base.id = value;
        }

        /// <summary>
        /// the name of the asset
        /// </summary>
        public string? assetName { get; init; }

        /// <summary>
        /// <inheritdoc cref="assetName"/>
        /// </summary>
        [JsonInclude]
        protected string name { init => assetName = value; }

        /// <summary>
        /// <inheritdoc cref="Roblox_Sharp.Enums.AssetType"/>
        /// </summary>
        public Avatar.Asset.Type assetType { get; init; }

        public ulong currentVersionId { get; init; }

        /// <summary>
        /// <inheritdoc cref="Metadata"/>
        /// </summary>
        public Metadata meta { get; init; }

        /// <summary>
        /// Deep Clones the instance of <see cref="Avatar.Asset"/>
        /// </summary>
        /// <returns></returns>
        public Avatar.Asset Clone() =>
            new Asset()
            {
                assetId = assetId,
                assetName = assetName,
                assetType = assetType,
                currentVersionId = currentVersionId,
                meta = meta
            };
    }
}
