using Roblox_Sharp.Models;
using System;
using System.Text.Json;

namespace xUnitTests.Deserialization
{
    [Trait(nameof(xUnitTests), nameof(Deserialization))]
    public class Miscellaneous
    {
        [Fact]
        public void Page()
        {
            const string json_response = @"
            {
              ""previousPageCursor"": ""string"",
              ""nextPageCursor"": ""string"",
              ""data"": [
                {
                  ""name"": ""string""
                }
              ]
            }";

            Page<User>? page = JsonSerializer.Deserialize<Page<User>>(json_response);

            Assert.NotNull(page);

            Assert.Equal("string", page.previousPageCursor);
            Assert.Equal("string", page.nextPageCursor);

            Assert.True(1 == page.data.Count, "Page should have 1 item");

            Assert.Equal("string", page.data[0].username);

        }

        [Fact]
        public void Thumbnail()
        {
            const string json_response = @"  
            {
                ""targetId"": 0,
                ""state"": ""Error"",
                ""imageUrl"": ""string"",
                ""version"": ""string""
            }";

            Thumbnail? thumbnail = JsonSerializer.Deserialize<Thumbnail>(json_response);

            Assert.NotNull(thumbnail);
            //Assert.Equal<ulong>(0, thumbnail.targetId);
            Assert.Equal("Error", thumbnail.state);
            Assert.Equal("string", thumbnail.imageUrl);
            Assert.Equal("string", thumbnail.version);

        }
    }
}
