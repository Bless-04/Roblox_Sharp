namespace Roblox_Sharp.Enums
{

    /// <summary>
    /// used to get string representations of all enums 
    /// </summary>
    public abstract class EnumExtensions
    {
        public static string ToString(Thumbnail.Format FORMAT)
        {
            return FORMAT switch
            {
                Thumbnail.Format.Png => "Png",
                Thumbnail.Format.Jpeg => "Jpeg",
                Thumbnail.Format.Webp => "Webp",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static string ToString(Thumbnail.Size SIZE) => $"{(ushort)SIZE}x{(ushort)SIZE}";

        public static string ToString(Sort SORT)
        {
            return SORT switch
            {
                Sort.Asc => "Asc",
                Sort.Desc => "Desc",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static string ToString(Limit LIMIT)
        {
            return (LIMIT) switch
            {
                Limit.Ten => "10",
                Limit.EightTeen => "18",
                Limit.TwentyFive => "25",
                Limit.Fifty => "50",
                Limit.OneHundred => "100",
                _ => throw new ArgumentOutOfRangeException()

            };
        }
    }
}
