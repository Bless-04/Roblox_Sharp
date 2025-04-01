using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    internal sealed class UsernameHistory_Response 
    {
        [JsonPropertyName("name")]
        public required string Name { get; init; }
    }
}
