using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    public partial class Badge
    {
        /// <summary>
        /// Holds the statistics of the badge
        /// </summary>
        public record Statistic
        {
            /// <summary>
            /// the number of times the badge has been awarded in the last day
            /// </summary>
            [JsonPropertyName("pastDayAwardedCount")]
            public required ulong PastDayAwardedCount { get; init; }

            /// <summary>
            /// the total number of times the badge has been awarded
            /// </summary>
            [JsonPropertyName("awardedCount")]
            public required ulong AwardedCount { get; init; }

            /// <summary>
            /// the win rate of the badge
            /// </summary>
            [JsonPropertyName("winRatePercentage")]
            public required double WinRatePercentage { get; init; }
        }
    }
}
