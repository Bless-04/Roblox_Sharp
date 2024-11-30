using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON.Badges
{
    sealed public class Badge_Award : Badge
    {
        /// <summary>
        /// unique badge id
        /// </summary>
        [JsonPropertyName("badgeId")]
        public ulong badgeId
        {
            get => id;
            init => id = value;
        }

        /// <summary>
        /// date badge was awarded
        /// </summary>
        [JsonPropertyName("awardedDate")]
        public DateTime awardedDate { get; init; }
    }
}
