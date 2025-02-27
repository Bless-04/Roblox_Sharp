using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Enums;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// class used to serialize Item based requests
    /// </summary>
    public class Item : Creation, IAsset
    {
        /// <summary>
        /// The ID of the item
        /// </summary>
        public ulong Id
        {
            get => base.id ?? throw new NotRequestedException(nameof(Id));
            init => base.id = value;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ulong assetId => Id;


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
