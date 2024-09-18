namespace Roblox_Sharp.Enums
{

    /// <summary>
    /// used to get string representations of enums cant use the literal variable name 
    /// </summary>
    public abstract class EnumExtensions
    {
       
        public static string ToString(Thumbnail.Size SIZE) => $"{(ushort)SIZE}x{(ushort)SIZE}";

       

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
