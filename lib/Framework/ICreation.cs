using System;
using System.Diagnostics.CodeAnalysis;

namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// Defines a generalized template for any roblox user generated <paramref name="Creation"></paramref> based object
    /// </summary>
    public abstract class ICreation : IComparable<ICreation>
    {
        /// <summary>
        /// the id of the creation
        /// </summary>
        protected ulong id { get; init; }

        /// <summary>
        /// a creation is <b> less than </b> another if it is newer. newer creations have larger ids than older ones
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>bool</returns>
        public static bool operator <(ICreation left, ICreation right) => left.id > right.id;

        /// <summary>
        /// a creation is <b>greater than</b> another if it is older. Older creations have smaller ids than newer creations.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>bool</returns>
        public static bool operator >(ICreation left, ICreation right) => left.id < right.id;
        public override int GetHashCode() => id.GetHashCode();

        /// <summary>
        /// equal if and only if the ids are the same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals([NotNullWhen(true)] object? obj) =>
            (obj is ICreation creation)
                ? id == creation.id //equal if ids are the same 
                : false;


        /// <summary>
        /// a creation is greater than another if it is older. Older creations have smaller ids than newer users.
        /// <br></br>
        /// example: creation 1 is the oldest creation
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareTo(ICreation? other)
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
