#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member ; the names are self explanatory
namespace Roblox_Sharp.Models;

public partial class Avatar
{
    /// <summary>
    /// Holds the scaling of the avatar
    /// </summary>
    public readonly struct Scales
    {
        public double height { get; init; }
        public double width { get; init; }
        public double head { get; init; }
        public double depth { get; init; }
        public double proportion { get; init; }
        public double bodyType { get; init; }
    }
}
