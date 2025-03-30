
using Roblox_Sharp.Abstractions;
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
        [JsonPropertyName("id")]
        public ulong ItemId
        {
            get => base.Id;
            init => base.Id = value;
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
