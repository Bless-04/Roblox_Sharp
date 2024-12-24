using System.Text.Json.Serialization;
namespace Roblox_Sharp.JSON_Models;

[JsonSerializable(typeof(Avatar.BodyColors))]
public partial class Avatar
{
    /// <summary>
    /// body color of the avatar using brickcolorid
    /// </summary>
    public readonly struct BodyColors
    {
        public int headColorId { get; init; }
        public int torsoColorId { get; init; }
        public int rightArmColorId { get; init; }
        public int leftArmColorId { get; init; }
        public int rightLegColorId { get; init; }
        public int leftLegColorId { get; init; }
    }
}
