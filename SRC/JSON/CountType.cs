using Newtonsoft.Json;

namespace Roblox_Sharp.JSON
{
    /** example return
        {
            "count": 38280
        }
    */
    /// <summary>
    /// for all count requests
    /// </summary>
    public readonly struct CountType
    {
        [JsonProperty("count")]
        public ulong count { get; init; }
    }
}