using Roblox_Sharp.Framework;
using Roblox_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace xUnitTests.Deserialization
{
    [Trait(nameof(Roblox_Sharp.Models),nameof(Deserialization))]
    public class Asset_Models
    {
        [Fact]
        public void Item_Model()
        {
            const string json = "{\r\n      \"Id\": 5,\r\n      \"Name\": \"string\",\r\n      \"Type\": 0,\r\n      \"InstanceId\": 5\r\n    }";


            Item? item = JsonSerializer.Deserialize<Item>(json);
           
            


            Assert.NotNull(item);

            Assert.Equal<ulong>(5,item.ItemId);

            Assert.Equal("string", item.Name);

            IAsset asset = item;
            Assert.Equal(item.ItemId, asset.AssetId);
        }
        
    }
}
