using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class Avatar
{
    /// <summary>
    /// body color of the avatar using brickcolorid
    /// </summary>
    public readonly struct BodyColors
    {
        /// <summary>
        /// The BrickColor id for head color
        /// </summary>
        [JsonPropertyName("headColorId")]
        public int HeadColorId { get; init; }

        /// <summary>
        /// The BrickColor id for torso color
        /// </summary>
        [JsonPropertyName("torsoColorId")]
        public int TorsoColorId { get; init; }

        /// <summary>
        /// The BrickColor id for right arm color
        /// </summary>
        [JsonPropertyName("rightArmColorId")]
        public int RightArmColorId { get; init; }

        /// <summary>
        /// The BrickColor id for left arm color
        /// </summary>
        [JsonPropertyName("leftArmColorId")]
        public int LeftArmColorId { get; init; }

        /// <summary>
        /// The BrickColor id for right leg color
        /// </summary>
        [JsonPropertyName("rightLegColorId")]
        public int RightLegColorId { get; init; }

        /// <summary>
        /// The BrickColor id for left leg color
        /// </summary>
        [JsonPropertyName("leftLegColorId")]
        public int LeftLegColorId { get; init; }
    }
}
