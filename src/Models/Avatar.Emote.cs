using Roblox_Sharp.Framework;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class Avatar
{
    /// <summary>
    /// a roblox emote
    /// </summary>
    public record Emote : IAsset
    {
        /// <summary>
        /// the position the emote is equipped to
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; init; }

        /// <inheritdoc cref="IAsset.AssetId"/>
        [JsonPropertyName("assetId")]
        public ulong AssetId { get; init; }

        /// <summary>
        /// the name of the emote
        /// </summary>
        [JsonPropertyName("assetName")]
        public required string AssetName { get; init; }
    }
}
