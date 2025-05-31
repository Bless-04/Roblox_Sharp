using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums.Thumbnail;
using System;
using System.Linq;

namespace Roblox_Sharp.Enums
{
    /// <summary>
    /// used to get string representations of enums that cant use the literal variable name 
    /// and also contains helpful functions
    /// </summary>
    internal static class EnumExtensions
    {
        /// <summary>
        /// used to check if an enum is blacklisted
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blacklist"></param>
        /// <returns>
        /// <see langword="true"/> if the enum is blacklisted
        /// </returns>
        public static bool IsBlackListed(this Enum value, Enum[] blacklist) => blacklist.Contains(value);

        /// <summary>
        /// converts an enum to a flag
        /// </summary>
        /// <typeparam name="T">The enums corresponding flag type</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToFlag<T>(this Enum value) where T : Enum => (T)Enum.Parse(typeof(T), value.ToString(), true);

        /// <summary>
        /// converts a string to an enum in which the string is the name of the enum value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <exception cref="ArgumentException"></exception>
        public static T ToEnum<T>(this string text) where T : Enum => int.TryParse(text, out int value)
            ? (T)Enum.ToObject(typeof(T), value)
            : (T)Enum.Parse(typeof(T), text, ignoreCase: true);


    }
}
