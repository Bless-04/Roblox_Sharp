using Roblox_Sharp.Templates;

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
        public static bool IsBlackListed(Enum value,Enum[] blacklist) => blacklist.Contains(value);
        

        public static string ToString(Limit LIMIT)
        {
            return (LIMIT) switch
            {
                Limit.Ten => "10",
                Limit.TwentyFive => "25",
                Limit.Fifty => "50",
                Limit.OneHundred => "100",
                _ => throw new ArgumentOutOfRangeException()

            };
        }
    }
}
