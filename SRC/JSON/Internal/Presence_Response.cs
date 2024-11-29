using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON.Internal
{
    /// <summary>
    /// used for response of userPresence requests
    /// </summary>
    /// since arrays are a reference type, its not worth making this a struct
    internal sealed class Presence_Response
    {
        [JsonPropertyName("userPresences")]
        required public User_Presence[] userPresences { get; init; }
    }
}
