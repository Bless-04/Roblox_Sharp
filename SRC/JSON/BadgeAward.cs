using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace Roblox_Sharp.JSON
{
    
    public record BadgeAward 
    {
        /// <summary>
        /// unique badge id
        /// </summary>
        [JsonProperty("badgeId")]
        public ulong badgeId { get; init; }

        /// <summary>
        /// date badge was awarded
        /// </summary>
        [JsonProperty("awardedDate")]
        public DateTime awardedDate { get; init; }
    }
}
