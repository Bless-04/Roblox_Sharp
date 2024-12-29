using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models
{
    /// <summary>
    /// class used to serialize Group based requests
    /// </summary>
    public partial class Group
    {
       
        /// <summary>
        /// the groups id
        /// </summary>
        public ulong groupId { get; init; }

        /// <summary>
        /// ambiguous with groupId
        /// </summary>
        [JsonInclude]
        protected ulong id { init => groupId = value; }

        /// <summary>
        /// group name
        /// </summary>
        public string? name { get; init; }

        /// <summary>
        /// group description
        /// </summary>
        public string? description { get; init; }

        /// <summary>
        /// group owner
        /// </summary>
        public User owner { get; init; }

        /// <summary>
        /// most recent group shout
        /// </summary>
        public Shout shout { get; init; }

        /// <summary>
        /// group member count
        /// </summary>
        public ulong memberCount { get; init; }

        /// <summary>
        /// true if group is buildersclub only, false otherwise 
        /// </summary>
        public bool isBuildersClubOnly { get; init; }

        /// <summary>
        /// true if group is public, false otherwise
        /// </summary>
        public bool publicEntryAllowed { get; init; }

        public bool isLocked { get; init; }

        /// <summary>
        /// true if group has a verified badge, false otherwise
        /// </summary>
        public bool hasVerifiedBadge { get; init; }

       }    
}
