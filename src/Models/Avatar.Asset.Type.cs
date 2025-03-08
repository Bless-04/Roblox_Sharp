using Roblox_Sharp.Enums;
using System.Text.Json.Serialization;
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
            [JsonPropertyName("id")]
            public AssetType Id { get; init; }

            /// <summary>
            /// the name of the Asset_Type
            /// </summary>
            [JsonPropertyName("name")]
            public string? Name { get; init; }
        }
    }
}
