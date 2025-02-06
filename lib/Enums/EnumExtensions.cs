using Roblox_Sharp.Enums.Thumbnail;
using System;
using System.Linq;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace Roblox_Sharp.Enums
{
    /// <summary>
    /// used to get string representations of enums that cant use the literal variable name 
    /// and also contains helpful functions
    /// </summary>
    public static class EnumExtensions
    {
       

        /// <summary>
        /// used to check if an enum is blacklisted
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blacklist"></param>
        /// <returns>
        /// <see langword="true"/> if the enum is blacklisted
        /// </returns>
        public static bool IsBlackListed(Enum value,params Enum[] blacklist) => blacklist.Contains(value);

        /// <summary>
        /// <inheritdoc cref="IsBlackListed(Enum, Enum[])"/>
        /// uses the flags of the enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="blacklist"></param>
        /// <returns></returns>
        public static bool SizeBlackListed(Size value, Size_Flags blacklist) => (
            value.ToString() switch
            {
                nameof(Size.x30) => Size_Flags.x30,
                nameof(Size.x48) => Size_Flags.x48,
                nameof(Size.x50) => Size_Flags.x50,
                nameof(Size.x60) => Size_Flags.x60,
                nameof(Size.x75) => Size_Flags.x75,
                nameof(Size.x100) => Size_Flags.x100,
                nameof(Size.x110) => Size_Flags.x110,
                nameof(Size.x150) => Size_Flags.x150,
                nameof(Size.x180) => Size_Flags.x180,
                nameof(Size.x352) => Size_Flags.x352,
                nameof(Size.x420) => Size_Flags.x420,
                nameof(Size.x720) => Size_Flags.x720,
                _ => Size_Flags.All
            } & blacklist) != 0; //enum is not blacklisted if it is in the flags

        /// <summary>
        /// converts an enum to a flag
        /// </summary>
        /// <typeparam name="T">The enums corresponding flag type</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToFlag<T>(Enum value) where T : Enum => (T) Enum.Parse(typeof(T), value.ToString(),true);

        /// <summary>
        /// converts a string to an enum in which the string is the name of the enum value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <exception cref="ArgumentException"></exception>
        public static T ToEnum<T>(string text) where T : Enum => int.TryParse(text, out int value) 
            ? (T)Enum.ToObject(typeof(T), value)
            : (T)Enum.Parse(typeof(T), text,ignoreCase:true);

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
        /// gives a string representation of a thumbnail size
        /// </summary>
        /// <param name="SIZE"></param>
        /// <returns></returns>
        public static string ToString(Thumbnail.Size SIZE) => $"{(ushort)SIZE}x{(ushort)SIZE}";
    }
}
