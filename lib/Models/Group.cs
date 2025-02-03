﻿using Roblox_Sharp.Framework;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// class used to serialize Group based requests
    /// </summary>
    public partial class Group : ICreation , ICloneable<Group>
    {
        ulong ICreation.id => groupId;

        /// <summary>
        /// the unique groups id
        /// </summary>
        public ulong groupId { get; init; }

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
