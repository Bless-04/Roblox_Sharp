using System;
using System.Text.Json;
using Roblox_Sharp.Enums.Thumbnail;
using Roblox_Sharp.Models;



namespace xUnitTests.Serialization
{
    [Trait(nameof(Roblox_Sharp.Models), nameof(Serialization))]
    public class Miscellaneous
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

        [Fact]
        public void User()
        {
            UserResponse x = new()
            {
                UserId = 1,
                Username = nameof(Miscellaneous),
                DisplayName = nameof(Miscellaneous),
                Created = DateTime.Now
            };

            Assert.Null(x.DisplayName);

            RoundTrip<UserResponse>(x);
        }

        [Fact]
        public void Group() => RoundTrip<Group>(new Group() { GroupId = 1, Name = nameof(Miscellaneous), Created = DateTime.Now });


        [Fact]
        public void Thumbnail_State() 
        {
            foreach (State thumbnail_state in Enum.GetValues<State>())
                RoundTrip<State>(thumbnail_state);
            
        }

        [Fact]
        public void Avatar_Asset() => RoundTrip<Avatar.Asset>(new Avatar.Asset() { AssetId = 1, AssetName= nameof(Miscellaneous) });
    }
    

    
}
