using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models.Internal
{
    internal class assetIds_Response
    {
        required public IReadOnlyList<ulong> assetIds { get; init; }
    }
}
