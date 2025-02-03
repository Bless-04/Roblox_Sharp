using System;
using System.Collections.Generic;
using Roblox_Sharp.Framework;
using Roblox_Sharp.Models;

namespace xUnitTests.Object_Functionality
{
    /// <summary>
    /// tests explicit logic of objects
    /// </summary>
    [Trait(nameof(xUnitTests), nameof(Object_Functionality))]
    public class Logic_Test
    {
        [Fact]
        public void IClonable_Implementation()
        {
            User user = new() { userId = 1 };

            Assert.NotSame(user, user.Clone());
        }

        [Fact]
        public void IUser_Operator()
        {
            // x > y > z
            User x = new User() { userId = 1 }; //roblox
            IUser y = new User() { userId = 16 }; //erik.cassel
            IUser z = new User() { userId = 156 }; //builderman
            IUser X = new User() { userId = 1 }; //roblox

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
        public void User_HashCode()
        {
            Random random = new();

            // Convert the byte array to a ulong
            User user;
            //long longID;
            ulong ID = 56;

           
            for (ushort i = 0; i < ushort.MaxValue; i++, ID = (ulong)random.Next())
            {
                user = new User(ID,string.Empty);
                Assert.Equal(ID.GetHashCode(), user.GetHashCode());
            }
        }
        

        [Fact]
        public void Immutable()
        {

            IReadOnlyList<User> data =
            [
                new(){ userId = 1},
                new(){ userId = 2}
            ];

            Page<User> page = new Page<User>() { data = data };
           
            User dummy = page.data[0];

            Assert.Equal(dummy, page.data[0]);

            //makes sure its not a shallow copy of the object         
            dummy = page.data[1];

            Assert.NotNull(page.data[0]);
            Assert.NotStrictEqual(dummy, page.data[0]);
        }

        [Fact]
        public void Page_Operators()
        {
            Page<bool> page1 = new Page<bool>() { previousPageCursor = string.Empty };
            Page<bool> page2 = new Page<bool>() { nextPageCursor= string.Empty};


            Assert.NotNull(page1.previousPageCursor);
            Assert.NotNull(page2.nextPageCursor);

            Assert.Null(page1.nextPageCursor);
            Assert.Null(page2.previousPageCursor);

            page1++; //go to next page
            page2--; //go to previous page

            Assert.NotNull(page1.nextPageCursor);
            Assert.NotNull(page2.previousPageCursor);
            Assert.Null(page1.previousPageCursor);
            Assert.Null(page2.nextPageCursor);
        }
    }

}