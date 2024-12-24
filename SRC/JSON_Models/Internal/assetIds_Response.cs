using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models.Internal
{
    [JsonSerializable(typeof(assetIds_Response))]
    internal class assetIds_Response
    {
        required public IReadOnlyList<ulong> assetIds { get; init; }
    }
}
