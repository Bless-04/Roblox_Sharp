using System.Collections.Generic;

namespace xUnitTests
{
    public static class User_Constants
    {
       
        public const byte ROBLOX = 1;
        public const byte BUILDERMAN = 156;
        public const ushort SHEDLETSKY = 261; 
        
        public const byte DOEST_EXIST = 0;

        public const ulong TERMINATED = 50770459;
        public const string TERMINATED_USERNAME = "c00lkidd";

        public static IEnumerable<object[]> Unsafe_Users
        {
            get 
            {
                yield return new object[] { TERMINATED, TERMINATED_USERNAME };
                yield return new object[] { DOEST_EXIST,string.Empty };
                yield return new object[] { };
            }
        }
        public static IEnumerable<object[]> Safe_Users
        {
            get
            {
                yield return new object[] { ROBLOX, "Roblox" };
                yield return new object[] { BUILDERMAN, "builderman" };
                yield return new object[] { SHEDLETSKY, "Shedletsky" };
            }
        }
    }
}
