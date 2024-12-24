﻿using Roblox_Sharp.JSON_Models.Users;
using Roblox_Sharp.JSON_Models;

namespace Roblox_SharpTests.Object
{
    [TestCategory("Object Usage Tests")]
    [TestClass]
    /// <summary>
    /// tests functionality of objects
    /// </summary>
    public class Logic_Test
    {
        [TestMethod]
        public void IUser_OperatorTests()
        {
            // x > y > z
            User x = new(1); //roblox



            User y = new(16); //erik.cassel
            User z = new(156); //builderman
            User X = new(1); //roblox

            Assert.AreNotEqual(x, y);

            Assert.IsTrue(x > y);
            Assert.IsTrue(y > z);
            Assert.IsTrue(x > z);

            Assert.IsTrue(z < x);
            Assert.IsTrue(z < x);
            Assert.IsTrue(y < x);

            Assert.IsFalse(x.Equals(y));
            Assert.IsTrue(x.Equals(X));
        }


        [TestMethod]
        public void ImmutableTest()
        {

            IReadOnlyList<User> data = new List<User>()
            {
                new(1),
                new(2)
            };
            
            Page<User> page = new(){data = data};

            User dummy = page.data[0];

            Assert.AreEqual(dummy, page.data[0]);

            //makes sure its not a shallow copy of the object         
            dummy = page.data[1];

            Assert.IsNotNull(page.data[0]);
            Assert.AreNotEqual(dummy, page.data[0]);

            
        }
    }

}