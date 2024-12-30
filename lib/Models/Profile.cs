using Roblox_Sharp.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roblox_Sharp.Models
{
    /// <summary>
    /// class used for Scraped User Profile
    /// </summary>
    public class Profile : IUser
    {
        public byte friends_count { get; init; }
        public ulong followers_count { get; init; }

        public ulong following_count { get; init; }


        public ulong place_visits { get; init; 
        }
    }
}
