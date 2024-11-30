using Roblox_Sharp.JSON.Users;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON.Internal
{
    /// <summary>
    /// used for response of userPresence requests
    /// </summary>
    /// since arrays are a reference type, its not worth making this a struct
    sealed internal class Presence_Response
    {
        [JsonPropertyName("userPresences")]
        required public IReadOnlyList<User_Presence> userPresences { get; init; }
    }
}
