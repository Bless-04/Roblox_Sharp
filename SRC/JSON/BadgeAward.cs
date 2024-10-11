using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Roblox_Sharp.JSON
{
    
    public record BadgeAward 
    {
        [JsonProperty("badgeId")]
        public ulong badgeId { get; init; }

        [JsonProperty("awardedDate")]
        public DateTime awardedDate { get; init; }
    }
}
