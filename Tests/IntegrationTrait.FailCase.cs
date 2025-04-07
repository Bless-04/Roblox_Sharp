using System;
using Xunit.Sdk;

namespace Tests;
public partial class IntegrationTrait
{
    [TraitDiscoverer("Xunit.Sdk.TraitDiscoverer", "xunit.core")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class FailCase(string name = nameof(Roblox_Sharp.Endpoints), string value = nameof(FailCase)) :
        Attribute,
        ITraitAttribute;
}