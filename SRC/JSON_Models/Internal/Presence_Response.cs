using Roblox_Sharp.JSON_Models.Users;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models.Internal
{
    [JsonSerializable(typeof(IReadOnlyList<User_Presence>))]
    /// <summary>
    /// used for response of userPresence requests
    /// </summary>
    /// since arrays are a reference type, its not worth making this a struct
    internal class Presence_Response
    {
        required public IReadOnlyList<User_Presence> userPresences { get; init; }
    }
}
