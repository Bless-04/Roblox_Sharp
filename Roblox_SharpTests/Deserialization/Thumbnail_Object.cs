using Roblox_Sharp.JSON_Models;
using Roblox_Sharp.JSON_Models.Users;

using System.Text.Json;

namespace Roblox_SharpTests.Deserialization
{
    [TestCategory("Deserialization Tests")]
    [TestClass]
    public class Thumbnail_Object
    {
        [TestMethod]
        /// <summary>
        /// bust and headshots are the same json format
        /// </summary>
        public void get_AvatarBusts()
        {
            const string json_response = @"
            {
              ""data"": [
                {
                  ""targetId"": 0,
                  ""state"": ""Error"",
                  ""imageUrl"": ""string"",
                  ""version"": ""string""
                }
              ]
            }";

            Page<Thumbnail> page = JsonSerializer.Deserialize<Page<Thumbnail>>(json_response) 
                ?? throw new AssertFailedException("Page  should not be null here");

            Assert.IsNull(page.nextPageCursor);
            Assert.IsNull(page.previousPageCursor);

            Thumbnail thumbnail = page.data[0];

            //Assert.AreEqual<ulong>(0, thumbnail.targetId);
            Assert.AreEqual("Error", thumbnail.state);
            Assert.AreEqual("string", thumbnail.imageUrl);
            Assert.AreEqual("string", thumbnail.version);


        }

        

        [TestMethod]
        public void get_Avatar()
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
