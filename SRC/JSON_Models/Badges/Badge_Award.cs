using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models.Badges
{
    [JsonSerializable(typeof(Badge_Award))]
    public class Badge_Award : Badge
    {
        /// <summary>
        /// date badge was awarded
        /// </summary>
        public DateTime awardedDate { get; init; }
    }
}
