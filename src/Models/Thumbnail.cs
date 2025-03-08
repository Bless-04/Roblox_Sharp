using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;
/** example return 
 * 
 {
    "data": [
        {
            "targetId": 0,
            "state": "Error",
            "imageUrl": "string",
            "version": "string"
        }
    ]
}*/

/// <summary>
/// class used to serialize Thumbnail based requests
/// </summary>
public class Thumbnail
{
    [JsonPropertyName("targetId")]
    public ulong TargetId { get; init; }

    [JsonPropertyName("state")]
    required public string State { get; init; }

    /// <summary>
    /// image url of thumbnail 
    /// </summary>
    [JsonPropertyName("imageUrl")]
    required public string ImageUrl { get; init; }

    [JsonPropertyName("version")]
    required public string Version { get; init; }
}
