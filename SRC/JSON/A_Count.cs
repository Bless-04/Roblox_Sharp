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
    public readonly struct A_Count
    {
        [JsonProperty("count")]
        public ulong count { get; init; }
    }
}