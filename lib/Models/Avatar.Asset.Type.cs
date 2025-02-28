using Roblox_Sharp.Enums;
namespace Roblox_Sharp.Models;

public partial class Avatar
{
    public partial class Asset
    {
        /// <summary>
        /// the type of the asset
        /// </summary>
        public class Type
        {
            /// <summary>
            /// the id of the Asset_Type
            /// </summary>
            public AssetType id { get; init; }

            /// <summary>
            /// the name of the Asset_Type
            /// </summary>
            public string name { get; init; }
        }
    }
}
