using Roblox_Sharp.Exceptions;

namespace xUnitTests
{
    /// <summary>
    /// Skips a test if it throws a <see cref="RateLimitException"/>
    /// </summary>
    public class RateLimitedFactAttribute : SkippableFactAttribute
    {
        public RateLimitedFactAttribute() : base(typeof(RateLimitException)) {  }
    }
}
