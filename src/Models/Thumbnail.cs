using System.Text.Json.Serialization;
using Roblox_Sharp.Enums.Thumbnail;
using Roblox_Sharp.Abstractions;
using Roblox_Sharp.Models.JsonConverters;

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
public class Thumbnail : ICreation
{
    /// <summary>
    /// The thumbnail target id
    /// </summary>
    [JsonPropertyName("targetId")]
    public ulong TargetId { get; init; }

    ulong ICreation.Id => TargetId;

    [JsonConverter(typeof(Thumbnail_State_Converter))]
    [JsonPropertyName("state")]
    required public State State { get; init; }

    /// <summary>
    /// image url of thumbnail 
    /// </summary>
    [JsonPropertyName("imageUrl")]
    public required string ImageUrl { get; init; }

    [JsonPropertyName("version")]
    public required string Version { get; init; }


}
