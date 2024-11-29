using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON
{
    public class BadgeAward 
    {
        /// <summary>
        /// unique badge id
        /// </summary>
        [JsonPropertyName("badgeId")]
        public ulong badgeId { get; init; }

        /// <summary>
        /// date badge was awarded
        /// </summary>
        [JsonPropertyName("awardedDate")]
        public DateTime awardedDate { get; init; }
    }
}
