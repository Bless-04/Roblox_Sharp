using Roblox_Sharp.Abstractions;
using System.Text.Json.Serialization;


namespace Roblox_Sharp.Models.v1;

public partial class Avatar
{
    /// <summary>
    /// Assets that a players Avatar can equip
    /// </summary>
    public partial class Asset : Abstractions.Asset
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [JsonPropertyName("id")]
        public override ulong AssetId
        {
            get => base.Id;
            init => base.Id = value;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [JsonPropertyName("name")]
        public required override string AssetName { get; init; }


        /// <summary>
        /// <inheritdoc cref="Roblox_Sharp.Enums.AssetType"/>
        /// </summary>
        [JsonPropertyName("assetType")]
        public required Avatar.Asset.Type AssetType { get; init; }

        [JsonPropertyName("currentVersionId")]
        public ulong CurrentVersionId { get; init; }

        /*/// <summary>
        /// <inheritdoc cref="Metadata"/>
        /// </summary>
        [JsonPropertyName("meta")]
        public Metadata? Meta { get; init; }
        */
    }
}