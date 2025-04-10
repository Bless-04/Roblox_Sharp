using System.Text.Json.Serialization;

namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// Represents a abstraction for a roblox badge
    /// </summary>
    public interface IBadge
    {
        /// <summary>
        /// The unique id of the <see cref="IBadge"/>
        /// </summary>
        ulong BadgeId { get; }
    }

    /// <summary>
    /// Represents a base implementation for a complete roblox badge
    /// </summary>
    public abstract class Badge : Creation<IBadge>, IBadge
    {
        /// <summary>
        /// The unique id of the <see cref="Badge"/>
        /// </summary>
        [JsonPropertyName("badgeId")]
        public virtual ulong BadgeId { get; init; }

        /// <summary>
        /// The name of the <see cref="Badge"/>
        /// </summary>
        [JsonPropertyName("badgeName")]
        public required virtual string BadgeName { get; init; }
    }

}
