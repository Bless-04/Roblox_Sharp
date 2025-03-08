using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Enums;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{

    public class CollectibleAsset : Creation<IAsset>, IAsset
    {
        /// <summary>
        /// The user asset id
        /// </summary>
        [JsonPropertyName("userAssetId")]
        public ulong UserAssetId { get; init; }

        /// <summary>
        /// The serial number of the user asset
        /// </summary>
        [JsonPropertyName("serialNumber")]
        public ulong SerialNumber { get; init; }

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
        /// The asset name of the asset
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        /// <summary>
        /// The recent average price of the user asset
        /// </summary>
        [JsonPropertyName("recentAveragePrice")]
        public ulong RecentAveragePrice { get; init; }

        /// <summary>
        /// The original price of the asset
        /// </summary>
        [JsonPropertyName("originalPrice")]
        public ulong OriginalPrice { get; init; }

        [JsonPropertyName("assetStock")]
        public ulong AssetStock { get; init; }

        /// <remarks>
        /// Should only be either <see cref="BuildersClubMembershipType.None"/>, <see cref="BuildersClubMembershipType.RobloxPremium"/> 
        /// </remarks>
        [JsonPropertyName("buildersClubMembershipType")]
        public BuildersClubMembershipType BuildersClubMembershipType { get; init; }

        /// <summary>
        /// Whether the user asset has an active hold
        /// </summary>
        [JsonPropertyName("isOnHold")]
        public bool IsOnHold { get; init; }
    }
}
