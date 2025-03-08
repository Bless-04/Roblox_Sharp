#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member ; the names are self explanatory

using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class Avatar
{
    /// <summary>
    /// Holds the scaling of the avatar
    /// </summary>
    public readonly struct Scales
    {
        [JsonPropertyName("height")]
        public double Height { get; init; }

        [JsonPropertyName("width")]
        public double Width { get; init; }

        [JsonPropertyName("head")]
        public double Head { get; init; }

        [JsonPropertyName("depth")]
        public double Depth { get; init; }

        [JsonPropertyName("proportion")]
        public double Proportion { get; init; }

        [JsonPropertyName("bodyType")]
        public double BodyType { get; init; }
    }
}
