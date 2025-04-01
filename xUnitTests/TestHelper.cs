using Roblox_Sharp;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace xUnitTests
{
    public class TestHelper
    {
        public TestHelper() 
        {
            if (!WebAPI.Set_UserAgent(nameof(xUnitTests))) throw new Exception(nameof(WebAPI.Set_UserAgent));

            WebAPI.OnFailedRequest += (obj, args) => Debug.WriteLine(args.Response);
            
        }
            


        /// <returns><paramref name="variable_name"/> is failing</returns>
        public static string isFailing(string variable_name) => $"{variable_name} is failing";

        public static bool RoundTrip<T>(T obj)
        {
            string json1 = JsonSerializer.Serialize<T>(obj);

            T? deobj = JsonSerializer.Deserialize<T>(json1);

            Assert.NotNull(deobj);
            Assert.NotNull(obj);

            Assert.Equal(deobj, obj);
            Assert.Equal(deobj.GetHashCode(), obj.GetHashCode());

            

            return true;
        }
    }
}
