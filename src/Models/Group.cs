using Roblox_Sharp.Framework;
using Roblox_Sharp.Exceptions;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// class used to serialize Group based requests
    /// </summary>
    public partial class Group : Creation<Group>, ICloneable<Group>
    {
        /// <summary>
        /// the unique groups id
        /// </summary>
        [JsonPropertyName("groupId")]
        public ulong GroupId
        {
            get => base.CreationId ?? throw new NotRequestedException(nameof(GroupId));
            init => base.CreationId = value;
        }

        /// <summary>
        /// group name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; init; }

        /// <summary>
        /// group description
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; init; }

        /// <summary>
        /// group owner <br/>
        /// </summary>
        [JsonPropertyName("owner")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public User? Owner { get; init; }

        /// <summary>
        /// most recent group shout <br/>
        /// </summary>
        [JsonPropertyName("shout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Group.Shout? shout { get; init; }

        /// <summary>
        /// group member count
        /// </summary>
        [JsonPropertyName("memberCount")]
        public ulong MemberCount { get; init; }

        /// <summary>
        /// <see langword="true"/> if group is buildersclub only
        /// </summary>
        [JsonPropertyName("isBuildersClubOnly")]
        public bool IsBuildersClubOnly { get; init; }

        /// <summary>
        /// <see langword="true"/> if group is public
        /// </summary>
        [JsonPropertyName("publicEntryAllowed")]
        public bool PublicEntryAllowed { get; init; }

        /// <summary>
        /// <see langword="true"/> if group is locked
        /// </summary>
        [JsonPropertyName("isLocked")]
        public bool IsLocked { get; init; }

        /// <summary>
        /// <see langword="true"/> if group has a verified badge
        /// </summary>
        [JsonPropertyName("hasVerifiedBadge")]
        public bool HasVerifiedBadge { get; init; }

        /// <summary>
        /// Deep Clones the instance of <see cref="Group"/>
        /// </summary>
        /// <returns></returns>
        public Group Clone() => new()
        {
            GroupId = GroupId,
            Name = Name,
            Description = Description,
            Owner = Owner,
            shout = shout,
            MemberCount = MemberCount,
            IsBuildersClubOnly = IsBuildersClubOnly,
            PublicEntryAllowed = PublicEntryAllowed,
            IsLocked = IsLocked,
            HasVerifiedBadge = HasVerifiedBadge
        };
    }
}
