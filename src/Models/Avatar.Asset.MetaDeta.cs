using System.Numerics;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class Avatar
{
    public partial class Asset
    {
        /// <summary>
        /// metadata of the asset
        /// </summary>
        public record Metadata
        {
            /// <summary>
            /// (x, y , z) position of the asset
            /// </summary>
            [JsonPropertyName("position")]
            public Vector3 Position { get; init; }

            /// <summary>
            /// (x, y, z) rotation of the asset
            /// </summary>
            [JsonPropertyName("rotation")]
            public Vector3 Rotation { get; init; }

            /// <summary>
            /// (x, y, z) scale of the asset
            /// </summary>
            [JsonPropertyName("scale")]
            public Vector3 Scale { get; init; }

            /// <summary>
            /// Client-authoritative meta model format version
            /// <code>the default is always 1</code>
            /// </summary>
            [JsonPropertyName("version")]
            public ulong Version { get; init; }

            /// <summary>
            /// layered clothing puffiness
            /// </summary>
            [JsonPropertyName("puffiness")]
            public float Puffiness { get; init; }

            /// <summary>
            /// layered clothing order
            /// </summary>
            [JsonPropertyName("order")]
            public int Order { get; init; }
        }
    }
}
