using System.Text.Json.Serialization;

namespace Roblox_Sharp.JSON_Models;

[JsonSerializable(typeof(Avatar.Emote))]
public partial class Avatar
{
    public class Emote : Avatar.Asset
    {
        /// <summary>
        /// the position the emote is equipped to
        /// </summary>
        public int position { get; init; }
    }
}
