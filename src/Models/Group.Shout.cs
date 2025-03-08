using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class Group
{
    //Unique to this request

    /// <summary>
    /// The date the Group Shout was created. 
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; init; }

    /// <summary>
    /// Group Shout Serializer
    /// </summary>
    public class Shout
    {
        /// <summary>
        /// group shoutouts message body
        /// </summary>
        [JsonPropertyName("body")]
        required public string Body { get; init; }

        /// <summary>
        /// user information of the Group Shouts poster
        /// </summary>
        [JsonPropertyName("poster")]
        required public User Poster { get; init; }

        /// <summary>
        /// The shouts created date 
        /// </summary>
        [JsonPropertyName("created")]
        public DateTime Created { get; init; }

        /// <summary>
        /// The date of the last Group Shout 
        /// </summary>
        [JsonPropertyName("updated")]
        public DateTime Updated { get; init; }
    }

}
