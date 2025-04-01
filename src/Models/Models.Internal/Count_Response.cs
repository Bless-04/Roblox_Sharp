using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// used to serialize the responses with a count field 
    /// </summary>
    internal readonly struct Count_Response
    {
        [JsonPropertyName("count")]
        public required ulong Count { get; init; }
    }
}
