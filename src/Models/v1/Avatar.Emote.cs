using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.v1;

public partial record Avatar
{
    /*{
      ""assetId"": 10214406616,
      ""assetName"": ""Frosty Flair - Tommy Hilfiger"",
      ""position"": 1
    },*/
    /// <summary>
    /// a roblox emote
    /// </summary>
    public class Emote : Abstractions.Asset
    {
        /// <summary>
        /// the position the emote is equipped to
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; init; }
    }
}
