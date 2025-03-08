using System;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Enums.Thumbnail;
using Roblox_Sharp.Framework;
using Roblox_Sharp.Models;

namespace xUnitTests.Model_Functionality
{
    /// <summary>
    /// tests explicit logic of objects
    /// </summary>
    [Trait(nameof(Roblox_Sharp.Models), nameof(Model_Functionality))]
    public class Logic
    {
        [Fact]
        public void IClonable_Implementation()
        {
            User user = new() { UserId = 1 };

            Assert.NotSame(user, user.Clone());
        }

        [Fact]
        public void Operators()
        {
            // x > y > z
            User x = new User() { UserId = 1 }; //roblox
            User y = new User() { UserId = 16 }; //erik.cassel
            User z = new User() { UserId = 156 }; //builderman
            User X = new User() { UserId = 1 }; //roblox

            Assert.False(x.Equals(y));
            Assert.True(x.Equals(X));

            Assert.True(x > y);
            Assert.True(y > z);
            Assert.True(x > z);

            Assert.True(z < x);
            Assert.True(z < x);
            Assert.True(y < x);
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
                user = new User(ID, string.Empty);
                Assert.Equal(ID.GetHashCode(), user.GetHashCode());
            }
        }


        [Fact]
        public void Immutable()
        {
            Page<User> page = new Page<User>
            {
                Data = [
                    new(){ UserId = 1},
                    new(){ UserId = 2}
                ]
            };

            User dummy = page.Data[0];

            Assert.Equal(dummy, page.Data[0]);

            //makes sure its not a shallow copy of the object         
            dummy = page.Data[1];

            Assert.NotNull(page.Data[0]);
            Assert.NotStrictEqual(dummy, page.Data[0]);
        }

        [Fact]
        public void Page_Operators()
        {
            Page<bool> page1 = new Page<bool>() { PreviousPageCursor = string.Empty };
            Page<bool> page2 = new Page<bool>() { NextPageCursor = string.Empty };


            Assert.NotNull(page1.PreviousPageCursor);
            Assert.NotNull(page2.NextPageCursor);

            Assert.Null(page1.NextPageCursor);
            Assert.Null(page2.PreviousPageCursor);

            page1++; //go to next page
            page2--; //go to previous page

            Assert.NotNull(page1.NextPageCursor);
            Assert.NotNull(page2.PreviousPageCursor);
            Assert.Null(page1.PreviousPageCursor);
            Assert.Null(page2.NextPageCursor);
        }


        [Fact]
        public void Flag_Convert()
        {
            Size_Flags flag, sum = Size_Flags.x720;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                flag = EnumExtensions.ToFlag<Size_Flags>(size);
                sum |= flag; //guarantees everything is base 2

                Assert.StrictEqual(flag, EnumExtensions.ToFlag<Size_Flags>(size)); //checks that toflag returns the correct value
                Assert.StrictEqual(flag, sum & flag);  //checks that the or is working correctly the flags together returns the value
                Assert.NotEqual((Size_Flags)((ushort)flag << 1), sum & flag); //    
            }
        }
    }
}