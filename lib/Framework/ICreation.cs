using System;

namespace Roblox_Sharp.Framework
{
    
    /// <summary>
    ///  generalized template for any roblox object that has a unique id 
    /// </summary>
    public interface ICreation : IComparable<ICreation>, IEquatable<ICreation>
    {
        /// <summary>
        /// The unique id of the creation
        /// </summary>
        protected ulong id { get; }

        /// <summary>
        /// equal if and only if the ids are the same
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// <see langword="true"/> if ids are the same
        /// </returns>
        bool IEquatable<ICreation>.Equals(ICreation? other) =>
            other != null &&
            id == other.id;

        /// <summary>
        /// a creation is <b> less than </b> another if it is newer. newer creations have larger ids than older ones
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator <(ICreation left, ICreation right) => left.id > right.id;

        /// <summary>
        /// a creation is <b>greater than</b> another if it is older. Older creations have smaller ids than newer creations.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns><inheritdoc/></returns>
        public static bool operator >(ICreation left, ICreation right) => left.id < right.id;

        ///<inheritdoc cref="object.GetHashCode"/>
        ///<remarks>uses the same hashcode function as <see langword="ulong"/></remarks>
        public int GetHashCode() => id.GetHashCode();

        int IComparable<ICreation>.CompareTo(ICreation? other) 
        {
            if (other is null) return 1;

            //if this is older than other
            if (id < other.id) return 1;

            //if this is younger than other
            if (id > other.id) return -1;

            return 0;
        }
    }
}   

