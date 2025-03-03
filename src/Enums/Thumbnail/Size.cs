#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member ; the names are self explanatory
using System;

namespace Roblox_Sharp.Enums.Thumbnail
{
    /// <summary>
    /// Thumbnail sizes
    /// </summary>
    public enum Size : ushort
    {
        x30 = 30,
        x48 = 48,
        x50 = 50,
        x60 = 60,
        x75 = 75,
        x100 = 100,
        x110 = 110,
        x150 = 150,
        x180 = 180,
        x352 = 352,
        x420 = 420,
        x720 = 720
    }

    /// <summary>
    /// bitwise mappings for <see cref="Size"/> <br/>
    /// variables names must match the ones in <see cref="Size"/>
    /// </summary>
    [Flags]
    public enum Size_Flags : ushort
    {
        x30 = 1 << 0,
        x48 = 1 << 1,
        x50 = 1 << 2,
        x60 = 1 << 3,
        x75 = 1 << 4,
        x100 = 1 << 5,
        x110 = 1 << 6,
        x150 = 1 << 7,
        x180 = 1 << 8,
        x352 = 1 << 9,
        x420 = 1 << 10,
        x720 = 1 << 11,

        All = ushort.MaxValue
    }
}
