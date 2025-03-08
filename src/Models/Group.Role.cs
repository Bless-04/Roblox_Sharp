using Roblox_Sharp.Framework;
using System.Collections.Generic;
using Roblox_Sharp.Exceptions;
using System.Text.Json.Serialization;
namespace Roblox_Sharp.Models;

public partial class Group
{
    /// <summary>
    /// unique to role requests
    /// </summary>
    [JsonPropertyName("roles")]
    public IReadOnlyList<Role>? Roles { get; init; }

    /// <summary>
    /// Group Role Serializer Class
    /// </summary>
    public class Role : Creation<Role>
    {
        /// <summary>
        /// Group Role ID
        /// </summary>
        [JsonPropertyName("roleId")]
        public ulong RoleId
        {
            get => base._id ?? throw new NotRequestedException(nameof(RoleId));
            init => base._id = value;
        }

        /// <summary>
        /// Group Role Name <br/>
        /// The name of the role
        /// </summary>
        [JsonPropertyName("name")]
        required public string Name { get; init; }

        /// <summary>
        /// Group role rank (255 is the owner)
        /// </summary>
        [JsonPropertyName("rank")]
        public byte Rank { get; init; }

        /// <summary>
        /// Number of members in the role
        /// </summary>
        [JsonPropertyName("memberCount")]
        public ulong MemberCount { get; init; }

        /// <summary>
        /// description of the Role
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; init; }
    }
}
