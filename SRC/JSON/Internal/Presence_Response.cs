﻿using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON.Internal
{
    /// <summary>
    /// used for response of userPresence requests
    /// </summary>
    /// since arrays are a reference type, its not worth making this a struct
    internal class Presence_Response
    {
        [JsonPropertyName("userPresences")]
        required public userPresence[] userPresences { get; init; }

    }
}
