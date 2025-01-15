﻿using Roblox_Sharp.Framework;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Roblox_Sharp.Models;

public partial class Group
{
    /// <summary>
    /// unique to role requests
    /// </summary>
    public IReadOnlyList<Role>? roles { get; init; }

    /// <summary>
    /// Group Role Serializer Class
    /// </summary>
    public class Role 
    {
        /// <summary>
        /// ambiguous with roleId
        /// </summary>
        [JsonInclude]
        protected ulong id { init => roleId = value; }

        /// <summary>
        /// Group Role ID
        /// </summary>
        public ulong roleId { get; init; }


        /// <summary>
        /// Group Role Name
        /// </summary>
        required public string name { get; init; }

        /// <summary>
        /// Group role rank (255 is the owner)
        /// </summary>
        public byte rank { get; init; }

        /// <summary>
        /// Number of members in the role
        /// </summary>
        public ulong memberCount { get; init; }

        /// <summary>
        /// description of the Role
        /// </summary>
        public string? description { get; init; }
    }
}
