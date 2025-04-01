using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    internal sealed class AssetIds_Response
    {
        [JsonPropertyName("assetIds")]
        public required IReadOnlyList<ulong> AssetIds { get; init; }
    }
}
