using Roblox_Sharp.JSON_Models;

using System.Collections.Generic;

namespace xUnitTests.Object_Functionality
{
    /// <summary>
    /// tests explicit logic of objects
    /// </summary>
    public class Logic_Test
    {
        [Fact]
        public void IUser_OperatorTests()
        {
            // x > y > z
            User x = new(1); //roblox



            User y = new(16); //erik.cassel
            User z = new(156); //builderman
            User X = new(1); //roblox

            Assert.False(x.Equals(y));

            Assert.True(x > y);
            Assert.True(y > z);
            Assert.True(x > z);

            Assert.True(z < x);
            Assert.True(z < x);
            Assert.True(y < x);

            Assert.False(x.Equals(y));
            Assert.True(x.Equals(X));
        }


        [Fact]
        public void ImmutableTest()
        {

            IReadOnlyList<User> data = new List<User>()
            {
                new(1),
                new(2)
            };
            
            Page<User> page = new(){data = data};

            User dummy = page.data[0];

            Assert.Equal(dummy, page.data[0]);

            //makes sure its not a shallow copy of the object         
            dummy = page.data[1];

            Assert.NotNull(page.data[0]);
            Assert.NotStrictEqual(dummy, page.data[0]);

            
        }
    }

}