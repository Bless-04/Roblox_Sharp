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
        public ulong groupId
        {
            get => base._id ?? throw new NotRequestedException(nameof(groupId));
            init => base._id = value;
        }

        /// <summary>
        /// group name
        /// </summary>
        public string? name { get; init; }

        /// <summary>
        /// group description
        /// </summary>
        public string? description { get; init; }

        /// <summary>
        /// group owner <br/>
        /// <see langword="null"/> if data not requested
        /// </summary>
        public User? owner { get; init; }

        /// <summary>
        /// most recent group shout <br/>
        /// <see langword="null"/> if data not requested
        /// </summary>
        public Shout? shout { get; init; }

        /// <summary>
        /// group member count
        /// </summary>
        public ulong memberCount { get; init; }

        /// <summary>
        /// <see langword="true"/> if group is buildersclub only
        /// </summary>
        public bool isBuildersClubOnly { get; init; }

        /// <summary>
        /// <see langword="true"/> if group is public
        /// </summary>
        public bool publicEntryAllowed { get; init; }

        /// <summary>
        /// <see langword="true"/> if group is locked
        /// </summary>
        public bool isLocked { get; init; }

        /// <summary>
        /// <see langword="true"/> if group has a verified badge
        /// </summary>
        public bool hasVerifiedBadge { get; init; }

        /// <summary>
        /// Deep Clones the instance of <see cref="Group"/>
        /// </summary>
        /// <returns></returns>
        public Group Clone() => new Group()
        {
            groupId = groupId,
            name = name,
            description = description,
            owner = owner,
            shout = shout,
            memberCount = memberCount,
            isBuildersClubOnly = isBuildersClubOnly,
            publicEntryAllowed = publicEntryAllowed,
            isLocked = isLocked,
            hasVerifiedBadge = hasVerifiedBadge
        };
    }
}
