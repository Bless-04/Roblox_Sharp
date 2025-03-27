using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Roblox_Sharp.Models.v1;
public partial class User
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Multi
    {
        /// <summary>
        /// exclude banned users
        /// </summary>
        [JsonPropertyName("excludeBannedUsers")]
        public bool ExcludeBannedUsers { get; init; }        
    }

}
