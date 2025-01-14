using System;
using System.Reflection;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace xUnitTests;
public partial class IntegrationTrait
{
    /// <summary>
    /// Exists for tests that are easiliy rate limited
    /// Also Marks Test with Long Integration Trait
    /// </summary>
    
    [TraitDiscoverer("Xunit.Sdk.TraitDiscoverer", "xunit.core")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class Long_Integration : BeforeAfterTestAttribute,
        ITraitAttribute
    {

        public Long_Integration(string name = "Tests", string value = "Long Integration"){}
        

        public override void Before(MethodInfo methodUnderTest) => Task.Delay(61000).Wait();

        

        
    }
}
