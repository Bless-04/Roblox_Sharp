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
    internal readonly struct A_Count
    {
        /// <summary>
        /// the count
        /// </summary>
        [JsonProperty("count")]
        public ulong count { get; init; }
    }
}