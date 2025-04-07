using System;
using Xunit.Sdk;

namespace Tests
{
    /// <summary>
    /// For normal web integration Tests
    /// </summary>
    [TraitDiscoverer("Xunit.Sdk.TraitDiscoverer", "xunit.core")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed partial class IntegrationTrait(string name = nameof(Roblox_Sharp.Endpoints), string value = nameof(Integration)) : Attribute, ITraitAttribute;
    
       
    
}
