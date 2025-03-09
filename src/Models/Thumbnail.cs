using Roblox_Sharp.Framework;
using Roblox_Sharp.Models.Internal.JsonConverters;
using System.Text.Json.Serialization;
using Roblox_Sharp.Enums.Thumbnail;

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

    ulong? ICreation.CreationId => TargetId;

    [JsonConverter(typeof(Thumbnail_State_Converter))]
    [JsonPropertyName("state")]
    required public State State { get; init; }

    /// <summary>
    /// image url of thumbnail 
    /// </summary>
    [JsonPropertyName("imageUrl")]
    required public string ImageUrl { get; init; }

    [JsonPropertyName("version")]
    required public string Version { get; init; }


}
