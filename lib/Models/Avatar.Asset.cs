using Roblox_Sharp.Framework;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class Avatar
{
    public partial class Asset : ICreation
    {
        /// <summary>
        /// the unique id of the asset
        /// </summary>
        public ulong assetId
        {
            get => base.id;
            init => base.id = value;
        }


        /// <summary>
        /// the name of the asset
        /// </summary>
        public string assetName { get; init; }

        /// <summary>
        /// ambiguous with assetName
        /// </summary>
        [JsonInclude]
        protected string name { init => assetName = value; }

        public Asset_Type assetType { get; init; }

        public ulong currentVersionId { get; init; }

        public Metadata meta { get; init; }
    }
}
