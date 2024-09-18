using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON
{


    /// <summary>
    /// used for all the page based requests ; requests that can return multiple pages or have a data[] field
    /// </summary>
    /// <typeparam name="T[]"></typeparam> 
    public class Page<T> 
    {
        [JsonPropertyName("previousPageCursor")]
        public string? previousPageCursor { get; init; }

        [JsonPropertyName("nextPageCursor")]
        public string? nextPageCursor { get; init; }

        [JsonPropertyName("data")]
        required public T[] data { get; init; }

        /** webRequest Specific fields */
        [JsonPropertyName("userPresences")]
        public userPresence[]? userPresences { get; init; }

        
        [JsonPropertyName("lastOnlineTimestamps")]
        required public userPresence[] lastOnlineTimestamps { get; init; }

        
    }
}
