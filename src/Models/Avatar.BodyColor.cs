using System.Text.Json.Serialization;

namespace Roblox_Sharp.Models;

public partial class Avatar
{
    /// <summary>
    /// body color of the avatar using brickcolorid
    /// </summary>
    public record BodyColor
    {
        /// <summary>
        /// The BrickColor id for head color
        /// </summary>
        [JsonPropertyName("headColorId")]
        public required int HeadColorId { get; init; }

        /// <summary>
        /// The BrickColor id for torso color
        /// </summary>
        [JsonPropertyName("torsoColorId")]
        public required int TorsoColorId { get; init; }

        /// <summary>
        /// The BrickColor id for right arm color
        /// </summary>
        [JsonPropertyName("rightArmColorId")]
        public required int RightArmColorId { get; init; }

        /// <summary>
        /// The BrickColor id for left arm color
        /// </summary>
        [JsonPropertyName("leftArmColorId")]
        public required int LeftArmColorId { get; init; }

        /// <summary>
        /// The BrickColor id for right leg color
        /// </summary>
        [JsonPropertyName("rightLegColorId")]
        public required int RightLegColorId { get; init; }

        /// <summary>
        /// The BrickColor id for left leg color
        /// </summary>
        [JsonPropertyName("leftLegColorId")]
        public required int LeftLegColorId { get; init; }
    }
}
