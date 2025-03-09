using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Enums;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// class used to serialize Item based requests
    /// </summary>
    public class Item : Creation<Item>, IAsset
    {
        /// <summary>
        /// The ID of the item
        /// </summary>
        [JsonPropertyName("Id")]
        public ulong ItemId
        {
            get => base.CreationId ?? throw new NotRequestedException(nameof(ItemId));
            init => base.CreationId = value;
        }

        ulong IAsset.AssetId => ItemId;

        /// <summary>
        /// The name of the item
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// The type of the item
        /// </summary>
        public ItemType Type { get; init; }

        /// <summary>
        /// The instance id of the item if applicable
        /// </summary>
        public ulong InstanceId { get; init; }
    }
}
