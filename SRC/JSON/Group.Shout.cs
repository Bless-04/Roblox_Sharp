using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON;

public partial class Group
{
    /// <summary>
    /// Group Shout Serializer
    /// </summary>
    public class Shout
    {
        /// <summary>
        /// group shoutouts message body
        /// </summary>
        [JsonPropertyName("body")]
        required public string body { get; init; }

        /// <summary>
        /// group shoutouts user of Poster
        /// </summary>
        [JsonPropertyName("poster")]
        required public User poster { get; init; }

        /// <summary>
        /// group creation date 
        /// </summary>
        [JsonPropertyName("created")]
        public DateTime created { get; init; }

        /// <summary>
        /// The date of the last Group Shout 
        /// </summary>
        [JsonPropertyName("updated")]
        public DateTime updated { get; init; }
    }

}
