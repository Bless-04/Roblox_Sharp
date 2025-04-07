using System;
using System.Reflection;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Tests;
public partial class IntegrationTrait
{
    /// <summary>
    /// Exists for tests that are easiliy rate limited
    /// </summary>
    [TraitDiscoverer("Xunit.Sdk.TraitDiscoverer", "xunit.core")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public partial class RateLimitted(string name = nameof(Roblox_Sharp.Endpoints), string value = nameof(RateLimitted)) : BeforeAfterTestAttribute,
        ITraitAttribute
    {
        /// <summary>
        /// Default Delay in MS
        /// </summary>
        public const ushort Delay = 61000;

        public override void Before(MethodInfo methodUnderTest) => Task.Delay(Delay).Wait();
    }
}
