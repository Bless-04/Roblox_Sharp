using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON
{

    
    /// <summary>
    /// class used to serialize Group based requests
    /// </summary>
    public class Group
    {
        /// <summary>
        /// group id
        /// </summary>
        [JsonPropertyName("id")]
        public ulong id { get; init; }

        /// <summary>
        /// group name
        /// </summary>
        [JsonPropertyName("name")]
        required public string name { get; init; }

        /// <summary>
        /// group description
        /// </summary>
        [JsonPropertyName("description")]
        required public string description { get; init; }

        /// <summary>
        /// group owner
        /// </summary>
        [JsonPropertyName("owner")]
        required public User owner { get; init; }

        /// <summary>
        /// most recent group shout
        /// </summary>
        [JsonPropertyName("shout")]
        required public Shout shout { get; init; }

        /// <summary>
        /// group member count
        /// </summary>
        [JsonPropertyName("memberCount")]
        public ulong memberCount { get; init; }

        /// <summary>
        /// true if group is buildersclub only, false otherwise 
        /// </summary>
        [JsonPropertyName("isBuildersClubOnly")]
        public bool isBuildersClubOnly { get; init; }

        /// <summary>
        /// true if group is public, false otherwise
        /// </summary>
        [JsonPropertyName("publicEntryAllowed")]
        public bool publicEntryAllowed { get; init; }

        /// <summary>
        /// true if group has a verified badge, false otherwise
        /// </summary>
        [JsonPropertyName("hasVerifiedBadge")]
        public bool hasVerifiedBadge { get; init; }

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

   


    /// <summary>
    /// Group Role Serializer Class
    /// </summary>
    public class Role
    {
        [JsonPropertyName("id")]
        public ulong id { get; init;  }

        [JsonPropertyName("name")]
        required public string name { get; init; }

        [JsonPropertyName("rank")]
        public byte rank { get; init; }
    }
}
