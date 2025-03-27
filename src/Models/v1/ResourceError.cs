using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// <see href="https://create.roblox.com/docs/cloud/reference/errors">Errors Documentation</see>
    /// </summary>
    public partial class ResourceError
    {
        [JsonPropertyName("error")]
        public ResourceError.Code Error { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }
    }
}
