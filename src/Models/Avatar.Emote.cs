using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class Avatar
{
    /// <summary>
    /// a roblox emote
    /// </summary>
    public class Emote : Avatar.Asset
    {
        /// <summary>
        /// the position the emote is equipped to
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; init; }
    }
}
