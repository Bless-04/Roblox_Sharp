using System.Text.Json;
using Roblox_Sharp.JSON_Models;

namespace Roblox_SharpTests.Deserialization
{
    [TestCategory("Deserialization Tests (?)")]
    [TestClass]
    public class __Object
    {
        [TestMethod]
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

            Page<User> page = JsonSerializer.Deserialize<Page<User>>(json_response)
                ?? throw new AssertFailedException("Page should not be null here");

            Assert.AreEqual("string", page.previousPageCursor);
            Assert.AreEqual("string", page.nextPageCursor);
            Assert.AreEqual(1, page.data.Count);
            Assert.AreEqual("string", page.data[0].username);


        }

        [TestMethod]
        public void Thumbnail()
        {
            const string json_response = @"  
            {
                ""targetId"": 0,
                ""state"": ""Error"",
                ""imageUrl"": ""string"",
                ""version"": ""string""
            }";

             Thumbnail thumbnail = JsonSerializer.Deserialize<Thumbnail>(json_response)
                ?? throw new AssertFailedException("Thumbnail should not be null here");

            //Assert.AreEqual<ulong>(0, thumbnail.targetId);
            Assert.AreEqual("Error", thumbnail.state);
            Assert.AreEqual("string", thumbnail.imageUrl);
            Assert.AreEqual("string", thumbnail.version);
            
        }
    }
}
