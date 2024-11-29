using System.Text.Json.Serialization;
using Roblox_Sharp.Templates;

namespace Roblox_Sharp.JSON
{

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
    /// class used to serialize Avatar based requests
    /// </summary>

    public sealed class Avatar : IUser
    {

        [JsonPropertyName("targetId")]
        public ulong targetId 
        { 
            get => base.id; 
            init => base.id = targetId; 
        }

        [JsonPropertyName("state")]
        required public string state { get; init; }

        /// <summary>
        /// image url of avatar based request
        /// </summary>
        [JsonPropertyName("imageUrl")] 
        required public string imageUrl {  get; init; }

        [JsonPropertyName("version")] 
        required public string version { get; init; }
    }
}
