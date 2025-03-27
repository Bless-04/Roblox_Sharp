using System.Text.Json;

namespace xUnitTests
{
    public static class TestHelper
    {
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
