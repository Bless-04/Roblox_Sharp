using Roblox_Sharp;
using Roblox_Sharp.Abstractions;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace Tests
{
    public static class TestHelper
    {
        #region Constants 

        public const byte ROBLOX = 1;
        public const byte BUILDERMAN = 156;
        public const ushort SHEDLETSKY = 261;
        public const uint INCEPTIONTIME = 7733466;

        public const byte DOEST_EXIST = 0;
        public const byte DELETED = 5;

        public const uint BANNED = 50770459;
        public const string BANNED_USERNAME = "c00lkidd";
        #endregion
        static TestHelper()
        {
            if (!WebAPI.Set_UserAgent(nameof(Tests))) throw new Exception(nameof(WebAPI.Set_UserAgent));

            WebAPI.OnFailedRequest += (obj, args) => Debug.WriteLine(args.Response);

        }

        /// <returns><paramref name="variable_name"/> is failing</returns>
        public static string isFailing(this string _) => $"{nameof(_)} is failing";

        /// <returns> <see langword="true"/> if <paramref name="obj"/> json roundtrips successfully </returns>
        public static bool RoundTrip<T>(this T obj) where T : ICreation
        {
            string json1 = JsonSerializer.Serialize<T>(obj);

            T? deobj = JsonSerializer.Deserialize<T>(json1);

            Assert.NotNull(deobj);
            Assert.NotNull(obj);

            Assert.Equal(deobj, obj);



            return deobj.GetHashCode() == obj.GetHashCode();
        }

    }
}
