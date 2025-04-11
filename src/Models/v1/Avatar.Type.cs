namespace Roblox_Sharp.Models.v1;

public partial record Avatar
{
    /// <summary>
    /// Represents the avatars animation type
    /// </summary>
    public enum Type : byte
    {
        /// <remarks>
        /// The classic simple avatar with 6 limbs. <br/> 
        /// This avatar type provides a retro feel but is limited in animations and additional customization. <br/> 
        /// Changes to the body scale property do not affect <see cref="Avatar.Type.R6"/> characters.
        /// </remarks>
        R6 = 1,

        /// <summary>
        /// The modern avatar with 15 limbs. <br/>
        /// This avatar has more limbs than <see cref="Avatar.Type.R6"/> allowing for more flexible customization, accessory options, and animations.
        /// </summary>
        R15 = 3
    }
}
