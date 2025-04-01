using System;
using System.Reflection;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace xUnitTests;
public partial class IntegrationTrait
{
    /// <summary>
    /// Exists for tests that are easiliy rate limited
    /// </summary>
    [TraitDiscoverer("Xunit.Sdk.TraitDiscoverer", "xunit.core")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RateLimitted(string name = nameof(Roblox_Sharp.Endpoints), string value = nameof(RateLimitted)) : BeforeAfterTestAttribute,
        ITraitAttribute
    {
        /// <summary>
        /// Default Delay in MS
        /// </summary>
        public const ushort Delay = 61000;

        public override void Before(MethodInfo methodUnderTest) => Task.Delay(Delay).Wait();
        
        /// <summary>
        /// Same as <see cref="FailCase"/> but for tests that are easily rate limited
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public sealed class FailCase2(string name = nameof(Roblox_Sharp.Endpoints), string value =nameof(FailCase2)) : RateLimitted;
    }
}
