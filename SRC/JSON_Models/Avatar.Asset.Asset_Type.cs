
using System.Text.Json.Serialization;
namespace Roblox_Sharp.JSON_Models;

[JsonSerializable(typeof(Avatar.Asset.Asset_Type))]
public partial class Avatar
{
    public partial class Asset
    {
        /// <summary>
        /// the type of the asset
        /// </summary>
        public class Asset_Type
        {
            /// <summary>
            /// the id of the Asset_Type
            /// </summary>
            public ulong id { get; init; }

            /// <summary>
            /// The name of the Asset_Type
            /// </summary>
            required public string name { get; init; }

        }
    }
}
