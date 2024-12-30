﻿using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System.Threading.Tasks;

using System.Collections.Generic;
namespace xUnitTests.HTTP
{
    /// <summary>
    /// Tests <see cref="Avatars_v1"/> and <see cref="Avatars_v2"/> Endpoints
    /// </summary>
    [Collection("Endpoints")]
    [Trait("Tests", "Integration")]
    public class Avatars : IRateLimited
    {
        [RateLimitedFact]
        public void Get_CurrentlyWearing() => Test(async () =>
        {
            IReadOnlyList<ulong> assets = await Avatars_v1.Get_CurrentlyWearingAsync(1);

            Assert.NotNull(assets);
            Assert.True(assets.Count > 0, "Assets.Count is failing");

        }, "Currently_Wearing()");

        /// <summary>
        /// tests both Avatar_v1 and Avatar_v2 using one another
        /// </summary>
        [Fact]
        public async Task Get_Avatar()
        {
            Avatar v1 = await Avatars_v1.Get_AvatarAsync(1);
            Avatar v2 = await Avatars_v2.Get_AvatarAsync(1);

            Assert.Equal(v1.scales, v2.scales); //should be the same ; can be value checked as it is a struct

            Assert.NotNull(v1.assets);
            Assert.NotNull(v2.assets);

            Assert.Equal(v1.assets[0].meta, v2.assets[0].meta); //can be value checked as it is a struct


            //v1 allows banned users

            await Assert.ThrowsAsync<InvalidIdException>(() => Avatars_v2.Get_AvatarAsync(5)); //the terminated user 
        }


    }
}
