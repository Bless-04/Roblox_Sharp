using System;
using System.Text.Json.Serialization;
using System.Xml;

namespace Roblox_Sharp.JSON;
public partial class Group
{
    //Unique to this request

    /// <summary>
    /// The date the Group Shout was created. 
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime created { get; init; }

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
        /// user information of the Group Shouts poster
        /// </summary>
        [JsonPropertyName("poster")]
        required public User poster { get; init; }

        /// <summary>
        /// The shouts created date 
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
