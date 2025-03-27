using System.Text.Json;
using System.Threading.Tasks;


using Roblox_Sharp.Models.v1;
using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// endpoints for direct Roblox user information. <br></br>
    /// <b><see href="https://users.roblox.com/docs//index.html">Users Documentation v1</see></b>
    /// </summary>
    public static class Users_v1
    {
        #region Display Names
        #endregion

        #region Users

        /// <summary>
        /// Gets detailed user information using the user's <paramref name="ID"/>
        /// </summary>
        /// <param name="ID">The users id</param>
        /// <returns> The deserialized <see cref="User"/> or <see langword="null"/> if there was a problem deserializing</returns>
        public static async Task<User?> Get_UserAsync(ulong ID) => JsonSerializer.Deserialize<User>(await Get_RequestAsync($"https://users.roblox.com/v1/users/{ID}"));
        

        #endregion
    }
      
}
