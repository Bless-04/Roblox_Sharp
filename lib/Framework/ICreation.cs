using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// Defines a generalized template for any roblox user generated <see cref="ICreation{T}"/> based object
    /// </summary>
    public interface ICreation : ICloneable;
    
    /// <summary>
    /// <inheritdoc cref="ICreation"/>
    /// </summary>
    /// <typeparam name="T">Type for specific Id comparisons</typeparam>
    public abstract class ICreation<T>  : 
        ICreation,
        IComparable<ICreation<T>>,
        IEquatable<ICreation<T>>
        where T : ICreation
    {


        /// <summary>
        /// The unique id of the creation
        /// </summary>
        [JsonInclude]
        protected ulong id { get; init; }

        /// <summary>
        /// a creation is <b> less than </b> another if it is newer. newer creations have larger ids than older ones
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>bool</returns>
        public static bool operator <(ICreation<T> left, ICreation<T> right) => left.id > right.id;

        /// <summary>
        /// a creation is <b>greater than</b> another if it is older. Older creations have smaller ids than newer creations.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>bool</returns>
        public static bool operator >(ICreation<T> left, ICreation<T> right) => left.id < right.id;

        /// <summary>
        /// Convert a creation to a ulong
        /// </summary>
        /// <param name="creation"></param>
        public static explicit operator ulong(ICreation<T> creation) => creation.id;

        /// <summary>
        /// a creation is greater than another if it is older. Older creations have smaller ids than newer users.
        /// <br></br>
        /// example: creation 1 is the oldest creation
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareTo(ICreation<T>? other)
        {
            if (other is null) return 1;

            //if this is older than other
            if (id < other.id) return 1;

            //if this is younger than other
            if (id > other.id) return -1;

            return 0;
        }

        /// <summary>
        /// equal if and only if the ids are the same
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([NotNullWhen(true)] ICreation<T>? other) =>
            other != null &&
            other.id == this.id;

        /// <summary>
        /// equal if and only if the ids are the same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals([NotNullWhen(true)] object? obj) =>
            (obj is ICreation<T> creation)
                ? id == creation.id //equal if ids are the same 
                : false;

        /// <summary>
        /// hashcode of the unique id
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => id.GetHashCode();

        /// <summary>
        /// returns a deep copy of the creation
        /// </summary>
        /// <returns></returns>
        abstract public object Clone();
    }
}
