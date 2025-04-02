namespace xUnitTests;
public partial class IntegrationTrait
{
    public partial class RateLimitted
    {
        /// <summary>
        /// Same as <see cref="FailCase"/> but for tests that are easily rate limited
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public sealed class FailCase2(string name = nameof(Roblox_Sharp.Endpoints), string value = nameof(FailCase2)) : RateLimitted;
    }
}