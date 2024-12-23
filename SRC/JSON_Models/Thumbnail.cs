using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models.Users
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

    [JsonSerializable(typeof(Thumbnail))]
    /// <summary>
    /// class used to serialize Thumbnail based requests
    /// </summary>
    public class Thumbnail
    {
        public ulong targetId { get; init; }

        required public string state { get; init; }

        /// <summary>
        /// image url of thumbnail 
        /// </summary>
        required public string imageUrl { get; init; }

        required public string version { get; init; }
    }
}
