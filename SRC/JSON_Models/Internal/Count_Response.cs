using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models.Internal
{
    /// <summary>
    /// used to serialize the responses with a count field 
    /// </summary>
    /// only holds a primivitive ulong count field so the type is struct 
    internal readonly struct Count_Response
    {
        [JsonPropertyName("count")]
        required public ulong count { get; init; }
    }
}
