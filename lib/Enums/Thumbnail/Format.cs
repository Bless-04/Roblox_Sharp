#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member ; the names are self explanatory
using System;

namespace Roblox_Sharp.Enums.Thumbnail
{
    [Flags]
    public enum Format : byte
    {
        Png = 1 << 0,
        Jpeg = 1 << 1,
        Webp = 1 << 2,
        All = byte.MaxValue
    }
}