using Roblox_Sharp.Framework;
using Roblox_Sharp.Models;
using System.Text.Json;

namespace xUnitTests.Deserialization
{
    [Trait(nameof(Roblox_Sharp.Models), nameof(Deserialization))]
    public class Miscellaneous
    {
        /// <summary>
        /// Serializes the object and then returns the deserialized object 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static void RoundTripTest<T>(T obj) => Assert.Equal(obj, JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(obj)));

        internal static T RoundTrip<T>(T obj) => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(obj))!;
        [Fact]
        public void Page()
        {
            const string json_response = @"
            {
              ""previousPageCursor"": ""string"",
              ""nextPageCursor"": ""string"",
              ""data"": [
                {
              ""Id"": 1,    
                  ""Name"": ""string""
                }
              ]
            }";

            Page<Item>? page = JsonSerializer.Deserialize<Page<Item>>(json_response);

            Assert.NotNull(page);

            Assert.Equal("string", page.PreviousPageCursor);
            Assert.Equal("string", page.NextPageCursor);

            Assert.True(1 == page.Data.Count, "Page should have 1 item");

            Assert.Equal("string", page.Data[0].Name);

        }

        [Fact]
        public void Thumbnail()
        {
            const string json_response = @"  
            {
                ""targetId"": 1,
                ""state"": ""Error"",
                ""imageUrl"": ""string"",
                ""version"": ""string""
            }";

            Thumbnail? thumbnail = JsonSerializer.Deserialize<Thumbnail>(json_response);

            Assert.NotNull(thumbnail);
            Assert.Equal<ulong>(1, thumbnail.TargetId);
            Assert.Equal("Error", thumbnail.State);
            Assert.Equal("string", thumbnail.ImageUrl);
            Assert.Equal("string", thumbnail.Version);

        }

        [Fact]
        public void CollectibleAsset()
        {
            const string json = @"{
              ""userAssetId"": 1,
              ""serialNumber"": 2,
              ""assetId"": 4,
              ""name"": ""string"",
              ""recentAveragePrice"": 4,
              ""originalPrice"": 8,
              ""assetStock"": 16,
              ""buildersClubMembershipType"": 32,
              ""isOnHold"": true
            }";
            CollectibleAsset? test = JsonSerializer.Deserialize<CollectibleAsset>(json);

            Assert.NotNull(test);
            Assert.Equal<byte>(0, (byte)(test.UserAssetId & test.SerialNumber & test.AssetId & test.RecentAveragePrice & test.OriginalPrice & test.AssetStock & (byte)test.BuildersClubMembershipType));

            RoundTripTest(test);
        }

        [Fact]
        public void Item()
        {
            const string json = @"
            {
              ""Id"": 1,
              ""Name"": ""string"",
              ""Type"": 2,
              ""InstanceId"": 4
            }";

            Item? test = JsonSerializer.Deserialize<Item>(json);

            Assert.NotNull(test);
            Assert.Equal(0, (byte)(test.ItemId & (byte)test.Type & test.InstanceId));

            Assert.Equal("string", test.Name);

            RoundTripTest(test);

        }
    }
}
