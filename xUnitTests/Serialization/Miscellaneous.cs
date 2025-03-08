using System;
using System.Text.Json;
using Roblox_Sharp.Models;



namespace xUnitTests.Serialization
{
    [Trait(nameof(Roblox_Sharp.Models), nameof(Serialization))]
    public class Miscellaneous
    {   
        public static void RoundTrip<T>(T obj) where T : new()
        {
            string json = JsonSerializer.Serialize<T>(obj);

            T? deobj = JsonSerializer.Deserialize<T>(json);

            Assert.NotNull(deobj);
            Assert.NotNull(obj);

            Assert.Equal(deobj, obj);
            Assert.Equal(deobj.GetHashCode(), obj.GetHashCode());
        }

        [Fact]
        public void User()
        {
            User x = new()
            {
                UserId = 1,
                Username = nameof(Miscellaneous),
                DisplayName = nameof(Miscellaneous),
                Created = DateTime.Now
            };

            Assert.Null(x.DisplayName);

            RoundTrip<User> (x);
        }

        [Fact]
        public void Group() => RoundTrip<Group>(new Group() { GroupId = 1,Name = nameof(Miscellaneous), Created = DateTime.Now});
    }
    

    
}
