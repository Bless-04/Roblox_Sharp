using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Enums.Thumbnail;

namespace Roblox_SharpTests.Integration;

public partial class WebAPI_Test
{
    //These tests need extensive testing and take longer
    [TestClass]
    [TestCategory("Avatar Requests")]
    public class Thumbnail
    {
        [ClassInitialize]
        public static async Task Initialize(TestContext testContext) => await WebAPI_Test.Initialize(testContext);

        [TestMethod]
        public void Headshots()
        {
            ulong[] id = [1];

            //error checking to loop through every possible Size and Format enum

            Size[] s_BLACKLIST = [Size.x30];
            bool isCircular = false;
            foreach (Size s in Enum.GetValues(typeof(Size)))
            {
                if (s_BLACKLIST.Contains(s))
                {
                    Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => Thumbnails_v1.Get_AvatarHeadshotsAsync(id, s, Format.Png, isCircular));
                    continue;
                }
                foreach (Format f in Enum.GetValues(typeof(Format)))
                {
                    isCircular = !isCircular;

                    Assert.IsNotNull(Thumbnails_v1.Get_AvatarHeadshotsAsync(id, s, f, isCircular).Result[0].imageUrl);
                }
            }
        }

        [TestMethod]
        public void FullAvatar()
        {
            ulong[] id = [1];


            Size[] s_BLACKLIST = [Size.x50];
            //Format[] f_BLACKLIST = [Format.Jpeg];


            bool isCircular = false;
            foreach (Size s in Enum.GetValues(typeof(Size)))
            {
                if (s_BLACKLIST.Contains(s))
                {
                    Assert.ThrowsExceptionAsync<ArgumentException>(() => Thumbnails_v1.Get_AvatarsAsync(id, s, Format.Png, isCircular));
                    continue;
                }
                foreach (Format f in Enum.GetValues(typeof(Format)))
                {
                    isCircular = !isCircular;

                    Assert.IsNotNull(Thumbnails_v1.Get_AvatarsAsync(id, s, f, isCircular).Result[0].imageUrl);
                }
            }
        }

        [TestMethod]
        public void Busts()
        {
            ulong[] id = [1];


            Size[] s_BLACKLIST = [Size.x30, Size.x110, Size.x720];
            Format[] f_BLACKLIST = [Format.Jpeg];


            bool isCircular = false;
            foreach (Size s in Enum.GetValues(typeof(Size)))
            {
                if (s_BLACKLIST.Contains(s))
                {
                    Assert.ThrowsExceptionAsync<ArgumentException>(() => Thumbnails_v1.Get_AvatarBustsAsync(id, s, Format.Png, isCircular));
                    continue;
                }
                foreach (Format f in Enum.GetValues(typeof(Format)))
                {
                    if (f_BLACKLIST.Contains(f))
                    {
                        Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => Thumbnails_v1.Get_AvatarBustsAsync(id, s, f, isCircular));
                        continue;
                    }
                    isCircular = !isCircular;

                    Assert.IsNotNull(Thumbnails_v1.Get_AvatarBustsAsync(id, s, f, isCircular).Result[0].imageUrl);
                }
            }
        }
    }
}
