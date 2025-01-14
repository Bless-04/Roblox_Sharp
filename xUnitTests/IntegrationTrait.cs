using System;
using Xunit.Sdk;

namespace xUnitTests
{
    [TraitDiscoverer("Xunit.Sdk.TraitDiscoverer", "xunit.core")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public partial class IntegrationTrait : 
        Attribute, 
        ITraitAttribute
    {
        public IntegrationTrait(string name = "Tests", string value = "Integration") { }
    }
}
