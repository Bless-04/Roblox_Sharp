using Roblox_Sharp.Models.v1;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// used for response of userPresence requests
    /// </summary>
    /// since arrays are a reference type, its not worth making this a struct
    internal sealed class Presence_Response
    {
        [JsonPropertyName("userPresences")]
        public required IReadOnlyList<User.Presence> UserPresences { get; init; }
    }
}
