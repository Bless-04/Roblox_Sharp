using Roblox_Sharp.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace xUnitTests
{
    public static class TestHelper
    {
        public static readonly string[] Errors =
        {
            @"{
  ""errors"": [
    {
      ""code"": 3,
      ""message"": ""The user id is invalid.""
    }
  ]
}",
        };

        public static string isFailing(string variable_name) => $"{variable_name} is failing";


        public static bool HelperTests<T>(T obj)
        {
            Assert.True(RoundTrip(obj),isFailing(nameof(RoundTrip)));

            //Assert.True(ErrorTest(obj as ICreation),isFailing(nameof(ErrorTest)));

            return true;
        }

        public static bool RoundTrip<T>(T obj)
        {
            string json1 = JsonSerializer.Serialize<T>(obj);

            T? deobj = JsonSerializer.Deserialize<T>(json1);

            Assert.NotNull(deobj);
            Assert.NotNull(obj);

            Assert.Equal(deobj, obj);
            Assert.Equal(deobj.GetHashCode(), obj.GetHashCode());

            string json2 = JsonSerializer.Serialize<T>(deobj);

            return true;
        }        
    }
}
