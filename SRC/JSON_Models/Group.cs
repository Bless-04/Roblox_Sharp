using System;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models
{
    /// <summary>
    /// class used to serialize Group based requests
    /// </summary>
    sealed public partial class Group
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
        public string? name { get; init; }

        /// <summary>
        /// group description
        /// </summary>
        [JsonPropertyName("description")]
        public string? description { get; init; }

        /// <summary>
        /// group owner
        /// </summary>
        [JsonPropertyName("owner")]
        public User owner { get; init; }

        /// <summary>
        /// most recent group shout
        /// </summary>
        [JsonPropertyName("shout")]
        public Shout shout { get; init; }

        
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

        [JsonPropertyName("isLocked")]
        public bool isLocked { get; init; }

        /// <summary>
        /// true if group has a verified badge, false otherwise
        /// </summary>
        [JsonPropertyName("hasVerifiedBadge")]
        public bool hasVerifiedBadge { get; init; }

       }    
}
