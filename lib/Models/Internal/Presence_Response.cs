using Roblox_Sharp.Models.Users;
using System.Collections.Generic;

namespace Roblox_Sharp.Models.Internal
{
    /// <summary>
    /// used for response of userPresence requests
    /// </summary>
    /// since arrays are a reference type, its not worth making this a struct
    internal class Presence_Response
    {
        required public IReadOnlyList<User_Presence> userPresences { get; init; }
    }
}
