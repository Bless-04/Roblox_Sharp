using Roblox_Sharp.Exceptions;

namespace xUnitTests
{
    /// <summary>
    /// Skips a test if it throws a <see cref="RateLimitException"/>
    /// </summary>
    public class RateLimitedTheoryAttribute : SkippableTheoryAttribute
    {
        public RateLimitedTheoryAttribute() : base(typeof(RateLimitException)) { }
    }
}
