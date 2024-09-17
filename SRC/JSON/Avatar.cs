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
        public int targetId { get; init; }

        [JsonProperty("state")]
        required public string state { get; init; }

        [JsonProperty("imageUrl")] 
        required public string imageUrl {  get; init; }

        [JsonProperty("version")] 
        required public string version { get; init; }
    }
}
