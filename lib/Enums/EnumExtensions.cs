using System;
using System.Linq;

namespace Roblox_Sharp.Enums
{
    /// <summary>
    /// used to get string representations of enums that cant use the literal variable name 
    /// and also contains helpful functions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// gives a string representation of a thumbnail size
        /// </summary>
        /// <param name="SIZE"></param>
        /// <returns></returns>
        public static string ToString(Thumbnail.Size SIZE) => $"{(ushort)SIZE}x{(ushort)SIZE}";

        /// <summary>
        /// used to check if an enum is blacklisted
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blacklist"></param>
        /// <returns></returns>
        public static bool IsBlackListed(Enum value, Enum[] blacklist) => blacklist.Contains(value);

        /// <summary>
        /// gives a string representation of a limit
        /// </summary>
        /// <param name="LIMIT"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string ToString(Limit LIMIT) => LIMIT switch
        {
            Limit.Ten => "10",
            Limit.TwentyFive => "25",
            Limit.Fifty => "50",
            Limit.OneHundred => "100",
            _ => throw new NotImplementedException($"'{LIMIT}' Limit is not implemented")
        };

        /// <summary>
        /// converts a string to an avatar type if possible
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">When the avatar type is not programmed in</exception>
        public static Avatar_Type ToAvatar_Type(string text) => byte.TryParse(text, out byte avatar_byte) 
            ? (Avatar_Type)avatar_byte
            : text switch
            {
                string t when t.Equals(nameof(Avatar_Type.R6), StringComparison.OrdinalIgnoreCase) => Avatar_Type.R6,
                string t when t.Equals(nameof(Avatar_Type.R15), StringComparison.OrdinalIgnoreCase) => Avatar_Type.R15,
                _ => throw new NotImplementedException($"'{text}' Avatar type is not implemented")
            };
    }
}
