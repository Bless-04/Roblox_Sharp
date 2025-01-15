using Roblox_Sharp.Framework;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class Avatar
{
    public partial class Asset : ICreation<Asset>
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
        /// <inheritdoc cref="assetName"/>
        /// </summary>
        [JsonInclude]
        protected string name { init => assetName = value; }

        /// <summary>
        /// <inheritdoc cref="Asset_Type"/>
        /// </summary>
        public Asset_Type assetType { get; init; }

        public ulong currentVersionId { get; init; }

        /// <summary>
        /// <inheritdoc cref="Metadata"/>
        /// </summary>
        public Metadata meta { get; init; }

        /// <summary>
        /// Deep Clones the instance of <see cref="Avatar.Asset"/>
        /// </summary>
        /// <returns></returns>
        public override Avatar.Asset Clone() =>
            new Asset()
            {
                assetId = base.id,
                assetName = assetName,
                assetType = assetType,
                currentVersionId = currentVersionId,
                meta = meta
            };       
    }
}
