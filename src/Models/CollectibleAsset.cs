using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Enums;

namespace Roblox_Sharp.Models
{

    public class CollectibleAsset : Creation, IAsset
    {
        /// <summary>
        /// The user asset id
        /// </summary>
        public ulong userAssetId { get; init; }

        /// <summary>
        /// The serial number of the user asset
        /// </summary>
        public ulong serialNumber { get; init; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ulong assetId
        {
            get => base.id ?? throw new NotRequestedException(nameof(assetId));
            init => base.id = value;
        }

        /// <summary>
        /// The asset name of the asset
        /// </summary>
        public required string name { get; init; }

        /// <summary>
        /// The recent average price of the user asset
        /// </summary>
        public ulong recentAveragePrice { get; init; }

        /// <summary>
        /// The original price of the asset
        /// </summary>
        public ulong originalPrice { get; init; }

        public ulong assetStock { get; init; }

        public BuildersClubMembershipType buildersClubMembershipType { get; init; }

        /// <summary>
        /// Whether the user asset has an active hold
        /// </summary>
        public bool isOnHold { get; init; }
    }
}
