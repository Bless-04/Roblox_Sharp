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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ToString(Limit LIMIT) => (LIMIT) switch
        {
            Limit.Ten => "10",
            Limit.TwentyFive => "25",
            Limit.Fifty => "50",
            Limit.OneHundred => "100",
            _ => throw new ArgumentOutOfRangeException("Limit out of range")
        };

        /// <summary>
        /// converts a string to an avatar type if possible
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">When the avatar type is not programmed in</exception>
        public static Avatar_Type ToAvatar_Type(string text)
        {
            try
            {
                return (Avatar_Type)byte.Parse(text);
            }
            catch (FormatException)
            {
                switch (text)
                {
                    case string R6 when (text.Equals(Avatar_Type.R6.ToString(), StringComparison.OrdinalIgnoreCase)):
                        return Avatar_Type.R6;
                    case string R15 when (text.Equals(Avatar_Type.R15.ToString(), StringComparison.OrdinalIgnoreCase)):
                        return Avatar_Type.R15;
                }
                throw new NotImplementedException($"{text} Avatar_Type is not supported");
            }
        }
    }
}
