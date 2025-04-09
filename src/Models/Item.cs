
using Roblox_Sharp.Abstractions;
using Roblox_Sharp.Enums;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// class used to serialize Item based requests
    /// </summary>
    public partial class Item : Asset
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

        /// <summary>
        /// The name of the item
        /// </summary>
        [JsonPropertyName("Name")]
        public required string ItemName
        {
            get => base.AssetName;
            init => base.AssetName = value;
        }

        /// <summary>
        /// The type of the item
        /// </summary>
        public required Item.Type ItemType { get; init; }

        /// <summary>
        /// The instance id of the item if applicable
        /// </summary>
        public required ulong InstanceId { get; init; }
    }
}
