using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON.Internal
{
    internal readonly struct Inventory_Response
    {
        [JsonPropertyName("count")]
        public bool canView { get; init; }
    }
}
