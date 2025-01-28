using System.Numerics;

namespace Roblox_Sharp.Models;

public partial class Avatar
{
    public partial class Asset
    {
        /// <summary>
        /// metadata of the asset
        /// </summary>
        public class Metadata
        {
            /// <summary>
            /// (x, y , z) position of the asset
            /// </summary>
            public Vector3 position { get; init; }

            /// <summary>
            /// (x, y, z) rotation of the asset
            /// </summary>
            public Vector3 rotation { get; init; }

            /// <summary>
            /// (x, y, z) scale of the asset
            /// </summary>
            public Vector3 scale { get; init; }

            /// <summary>
            /// Client-authoritative meta model format version
            /// <code>the default is always 1</code>
            /// </summary>
            public ulong version { get; init; }

            /// <summary>
            /// layered clothing puffiness
            /// </summary>
            public float puffiness { get; init; }

            /// <summary>
            /// layered clothing order
            /// </summary>
            public int order { get; init; }           
        }
    }
}
