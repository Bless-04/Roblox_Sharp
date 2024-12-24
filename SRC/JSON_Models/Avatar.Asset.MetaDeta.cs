using System.Numerics;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models;

[JsonSerializable(typeof(Avatar.Asset.Metadata))]
public partial class Avatar
{
    public partial class Asset
    {
        /// <summary>
        /// metadata of the asset
        /// </summary>
        public readonly struct Metadata
        {
            /// <summary>
            /// layered clothing order
            /// </summary>
            public int order { get; init; }

            /// <summary>
            /// layered clothing puffiness
            /// </summary>
            public float puffiness { get; init; }

            /// <summary>
            /// (x, y , z) position of the asset
            /// </summary>
            public Vector3 position { get; init; }
            public Vector3 rotation { get; init; }
            public Vector3 scale { get; init; }

            /// <summary>
            /// Client-authoritative meta model format version
            /// <code>the default is always 1</code>
            /// </summary>
            public ulong version { get; init; }
        }
    }
}
