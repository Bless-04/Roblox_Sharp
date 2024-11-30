using System.Text.Json.Serialization;
namespace Roblox_Sharp.JSON;

public partial class Group
{
    /// <summary>
    /// unique to role requests
    /// </summary>
    [JsonPropertyName("roles")]
    public Role[] roles { get; init; }
    /// <summary>
    /// Group Role Serializer Class
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Group Role ID
        /// </summary>
        [JsonPropertyName("id")]
        public ulong id { get; init; }

        /// <summary>
        /// Group Role Name
        /// </summary>
        [JsonPropertyName("name")]
        required public string name { get; init; }

        /// <summary>
        /// Group role rank (255 is the owner)
        /// </summary>
        [JsonPropertyName("rank")]
        public byte rank { get; init; }

        /// <summary>
        /// Number of members in the role
        /// </summary>
        [JsonPropertyName("memberCount")]
        public ulong memberCount { get; init; }
    }
}
