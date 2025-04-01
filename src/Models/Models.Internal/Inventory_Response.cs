using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    internal readonly struct Inventory_Response
    {
        [JsonPropertyName("canView")]
        public required bool CanView { get; init; }
    }
}
