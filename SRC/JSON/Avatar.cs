using Newtonsoft.Json;

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

    public record Avatar
    {

        [JsonProperty("targetId")]
        public ulong targetId { get; init; }

        [JsonProperty("state")]
        required public string state { get; init; }

        /// <summary>
        /// image url of avatar based request
        /// </summary>
        [JsonProperty("imageUrl")] 
        required public string imageUrl {  get; init; }

        [JsonProperty("version")] 
        required public string version { get; init; }
    }
}
