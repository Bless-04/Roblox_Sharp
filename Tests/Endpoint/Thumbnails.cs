using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums.Thumbnail;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roblox_Sharp.JSON_Models;

namespace Tests.Endpoint
{
    /// <summary>
    /// Tests <see cref="Roblox_Sharp.Endpoints.Thumbnails_v1"/> endpoint
    /// </summary>
    [Collection("Endpoints")]
    public class Thumbnails
    {
        private bool Test(Func<IReadOnlyList<Thumbnail>> method)
        {
            IReadOnlyList<Thumbnail> thumbnails = method();

            Thumbnail thumbnail = thumbnails[0];

            Assert.NotNull(thumbnail.imageUrl);
            Assert.NotNull(thumbnail.state);
            Assert.NotNull(thumbnail.version);

            return true;
        }

        [Theory]
        [InlineData(Size.x30)]
        [InlineData(Size.x48)] 
        [InlineData(Size.x50,true)] //Size.x50 should throw an error
        [InlineData(Size.x60)]
        [InlineData(Size.x75)]
        [InlineData(Size.x100)]
        [InlineData(Size.x110)]
        [InlineData(Size.x150)]
        [InlineData(Size.x180)]
        [InlineData(Size.x352)]
        [InlineData(Size.x420)]
        [InlineData(Size.x720)]
        public async Task Get_Avatars(Size size,bool error_case = false)
        {
            ulong[] id =  { 1 };
            const Format format = Format.Png; //shouldnt matter
            const bool isCircular = true;

            if (error_case)
            {
                await Assert.ThrowsAsync<ArgumentException>(() => Thumbnails_v1.Get_AvatarsAsync(id, size, format, isCircular));

                return;
            }

            Assert.True(
                Test(() => Thumbnails_v1.Get_AvatarsAsync(id, size, format, isCircular).Result) , 
                "nothing should be null here"
            );
        }

        [Theory]
        [InlineData(Size.x30,true)] //size x30 should throw an error
        [InlineData(Size.x48)]
        [InlineData(Size.x50)]
        [InlineData(Size.x60)]
        [InlineData(Size.x75)]
        [InlineData(Size.x100)]
        [InlineData(Size.x110)]
        [InlineData(Size.x150)]
        [InlineData(Size.x180)]
        [InlineData(Size.x352)]
        [InlineData(Size.x420)]
        [InlineData(Size.x720)]
        public async Task Get_AvatarHeadShots(Size size,bool error_case = false)
        {
            ulong[] id = { 1 };
            const bool isCircular = true;
            const Format format = Format.Png; //shouldnt matter

            if (error_case)
            {
                await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => Thumbnails_v1.Get_AvatarHeadshotsAsync(id, size, format, isCircular));

                return;
            }


            Assert.True(
                Test(() => Thumbnails_v1.Get_AvatarHeadshotsAsync(id, size, format, isCircular).Result),
                "nothing should be null here"
            );

        }

    }
}
