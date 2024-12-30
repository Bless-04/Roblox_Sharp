using System;

namespace Roblox_Sharp.Models;

public partial class Group
{
    //Unique to this request

    /// <summary>
    /// The date the Group Shout was created. 
    /// </summary>
    public DateTime created { get; init; }

    /// <summary>
    /// Group Shout Serializer
    /// </summary>
    public class Shout
    {
        /// <summary>
        /// group shoutouts message body
        /// </summary>
        required public string body { get; init; }

        /// <summary>
        /// user information of the Group Shouts poster
        /// </summary>
        required public User poster { get; init; }

        /// <summary>
        /// The shouts created date 
        /// </summary>
        public DateTime created { get; init; }

        /// <summary>
        /// The date of the last Group Shout 
        /// </summary>
        public DateTime updated { get; init; }
    }

}
