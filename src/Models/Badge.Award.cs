using Roblox_Sharp.Framework;
using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;
public partial class Badge
{
    /// <summary>
    /// Badge.Award
    /// </summary>
    public class Award : IBadge
    {

        /// <summary>
        /// date badge was awarded
        /// </summary>
        [JsonPropertyName("awardedDate")]
        public DateTime AwardedDate { get; init; }

        /// <inheritdoc/>
        [JsonPropertyName("badgeId")]
        public ulong BadgeId { get; init; }
    }
}
