using Roblox_Sharp.Exceptions;
using System.Threading.Tasks;

namespace Tests
{
    /// <summary>
    /// Skips a test if it throws a <see cref="RateLimitException"/>
    /// </summary>
    public class RateLimitedAttribute : SkippableFactAttribute
    {
        public RateLimitedAttribute() : base(typeof(RateLimitException)) {  }
    }
}
