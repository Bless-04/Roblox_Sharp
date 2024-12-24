using System.Text.Json;
using Roblox_Sharp.Js;
using Roblox_Sharp.JSON_Models;

namespace Roblox_SharpTests.Deserialization
{
    [TestCategory("Deserialization Tests (?)")]
    public class __Object
    {
        [TestMethod]
        public void Page()
        {

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
