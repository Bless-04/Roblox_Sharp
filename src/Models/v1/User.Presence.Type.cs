#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member ; the names are self explanatory
namespace Roblox_Sharp.Models.v1;


public partial class User
{
    public partial class Presence { 

        /// <summary>
        /// The Type of the <see cref="User.Presence"/>
        /// </summary>
        public enum Type : byte
        {
            Offline = 0,
            Online = 1,
            InGame = 2,
            InStudio = 3,
            Invisible = 4
        }
    }
}
