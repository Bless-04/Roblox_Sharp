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
        public int headColorId { get; init; }

        /// <summary>
        /// The BrickColor id for torso color
        /// </summary>
        public int torsoColorId { get; init; }

        /// <summary>
        /// The BrickColor id for right arm color
        /// </summary>
        public int rightArmColorId { get; init; }

        /// <summary>
        /// The BrickColor id for left arm color
        /// </summary>
        public int leftArmColorId { get; init; }

        /// <summary>
        /// The BrickColor id for right leg color
        /// </summary>
        public int rightLegColorId { get; init; }

        /// <summary>
        /// The BrickColor id for left leg color
        /// </summary>
        public int leftLegColorId { get; init; }
    }
}
