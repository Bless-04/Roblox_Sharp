using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums.Thumbnail;
using System;

using System.Collections.Generic;
using System.Threading.Tasks;
using Roblox_Sharp.Models;

namespace xUnitTests.HTTP
{
    /// <summary>
    /// Tests <see cref="Thumbnails_v1"/> endpoint
    /// </summary>
    [Collection("Endpoints")]
    [Trait("Tests", "Integration")]
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
        [InlineData(Size.x50, true)] //Size.x50 should throw an error
        [InlineData(Size.x60)]
        [InlineData(Size.x75)]
        [InlineData(Size.x100)]
        [InlineData(Size.x110)]
        [InlineData(Size.x150)]
        [InlineData(Size.x180)]
        [InlineData(Size.x352)]
        [InlineData(Size.x420)]
        [InlineData(Size.x720)]
        public async Task Get_Avatars(Size size, bool error_case = false)
        {
            ulong[] id = { 1 };
            const Format format = Format.Png; //shouldnt matter
            const bool isCircular = true;

            if (error_case)
            {
                await Assert.ThrowsAsync<ArgumentException>(() => Thumbnails_v1.Get_AvatarsAsync(id, size, format, isCircular));

                return;
            }

            Assert.True(
                Test(() => Thumbnails_v1.Get_AvatarsAsync(id, size, format, isCircular).Result),
                "nothing should be null here"
            );
        }

        [Theory]
        [InlineData(Size.x30, true)] //size x30 should throw an error
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
        public async Task Get_AvatarHeadShots(Size size, bool error_case = false)
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

        [Theory]
        [InlineData(Size.x30, Format.Png, true)] //Size.x30 should throw an error
        [InlineData(Size.x48, Format.Jpeg, true)] //Format.Jpeg should throw an error
        [InlineData(Size.x48, Format.Png)]
        [InlineData(Size.x50, Format.Png)]
        [InlineData(Size.x60, Format.Png)]
        [InlineData(Size.x75, Format.Png)]
        [InlineData(Size.x100, Format.Png)]
        [InlineData(Size.x110, Format.Png, true)] //size x110 should throw an error
        [InlineData(Size.x150, Format.Png)]
        [InlineData(Size.x180, Format.Png)]
        [InlineData(Size.x352, Format.Png)]
        [InlineData(Size.x420, Format.Png)]
        [InlineData(Size.x720, Format.Png, true)] //size x720 should throw an error
        public async Task Get_AvatarBusts(Size size, Format format, bool error_case = false)
        {
            ulong[] id = [1];
            const bool isCircular = true;

            if (error_case)
            {
                await Assert.ThrowsAsync<ArgumentException>(() => Thumbnails_v1.Get_AvatarBustsAsync(id, size, format, isCircular));
                return;
            }

            Assert.True(
               Test(() => Thumbnails_v1.Get_AvatarBustsAsync(id, size, format, isCircular).Result),
               "nothing should be null here"
            );
        }
    }
}
