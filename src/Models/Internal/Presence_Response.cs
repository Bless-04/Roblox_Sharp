using System.Collections.Generic;

namespace Roblox_Sharp.Models.Internal
{
    /// <summary>
    /// used for response of userPresence requests
    /// </summary>
    /// since arrays are a reference type, its not worth making this a struct
    internal sealed class Presence_Response
    {
        public required IReadOnlyList<User.Presence> userPresences { get; init; }
    }
}
