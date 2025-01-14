using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
