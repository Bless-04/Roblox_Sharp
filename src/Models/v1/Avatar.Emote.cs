using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models.v1;

public partial class Avatar
{
    /// <summary>
    /// a roblox emote
    /// </summary>
    public class Emote : Asset
    {
        /// <summary>
        /// the position the emote is equipped to
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; init; }
    }
}
