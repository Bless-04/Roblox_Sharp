using System.Diagnostics.CodeAnalysis;
using System;

namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// Defines a generalized template for any roblox <paramref name="User"></paramref> based object
    /// all users inherit have the fields <paramref name="userId"/>, <paramref name="username"/>, and <paramref name="displayName"/>
    /// </summary>
    public abstract class IUser : 
        IComparable<IUser>
    {
        /// <summary>
        /// the Unique numeric <paramref name="userId"/> of the user.
        /// </summary>
        public ulong userId { get; init; }

        /// <summary>
        /// unique username for the user
        /// </summary>
        public string username { get; init; }

        /// <summary>
        /// display name for the user
        /// </summary>
        public string? displayName { get; init; }

        public IUser() { }

        public IUser(ulong userId) => this.userId = userId;

        public IUser(ulong userId, string username, string? displayName = null)
        {
            this.userId = userId;
            this.username = username;
            this.displayName = displayName;
        }
        /// <summary>
        /// equal if and only if the ids are the same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals([NotNullWhen(true)] object? obj) =>
            (obj is IUser user) 
                ? this.userId == user.userId //equal if ids are the same 
                : false;
        
        public override int GetHashCode() => userId.GetHashCode();

        [Obsolete("this conversion loses information; just call userId instead")]
        /// <summary>
        /// lossy conversion from <see cref="IUser"/> to <see cref="ulong"/> <br></br>
        /// simply returns the users id
        /// </summary>
        /// <param name="user"></param>
        public static explicit operator ulong(IUser user) => user.userId;

        /// <summary>
        /// a user is <b> less than </b> another if it is younger. Younger users have larger ids than older ones
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>bool</returns>
        public static bool operator <(IUser left, IUser right) => left.userId > right.userId;
       
        /// <summary>
        /// a user is <b>greater than</b> another if it is older. Older users have smaller ids than newer users.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>bool</returns>
        public static bool operator >(IUser left, IUser right) => left.userId < right.userId;
        
        /// <summary>
        /// a user is greater than another if it is older. Older users have smaller ids than newer users.
        /// <br></br>
        /// example: userid 1 is the biggest user
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareTo(IUser? other)
        {
            if (other is null) return 1;

            //if this is older than other
            if (this.userId < other.userId) return 1;

            //if this is younger than other
            if (this.userId > other.userId) return -1;

            return 0;
        }

        /// <summary>
        /// string representation of the user <br></br> 
        /// Format: <b> <paramref name="displayName"/> @ <paramref name="username"/> (<paramref name="id"/>) </b>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => 
            ToString(userId, username, displayName);
            

        protected string ToString(ulong userId, string username, string? displayName = null) =>
            (username != null)
            ? $"{displayName}@{username} (ID {userId})"
            : $"(ID {userId})";
    }
}
