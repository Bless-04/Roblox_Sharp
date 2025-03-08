using System;
using System.Collections;
using System.Collections.Generic;

namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// template for all the page based requests that have a previous and next cursor
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// previous page cursor of the request .<br/> <see langword="null"/> if there are no previous pages or object is the first page
        /// </summary>
        public string? PreviousPageCursor { get; }

        /// <summary>
        /// next page cursor of the request.<br/> <see langword="null"/> if there are no more pages or instance is the last page
        /// </summary>
        public string? NextPageCursor { get; }
    }

    /// <summary>
    /// used for all the page based requests ; requests that can return multiple pages or have a data[] field
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    /// <remarks>indirectly implements <seealso cref="IReadOnlyList{T}"/> </remarks>
    public interface IPage<T> : IPage
    {
        /// <summary>
        /// List of <typeparamref name="T"/> returned by the request
        /// </summary>
        IReadOnlyList<T> Data { get; }

        /// <inheritdoc cref="IReadOnlyCollection{T}.Count"/>
        public int Count => Data.Count;

        /// <inheritdoc cref="IReadOnlyList{T}.this[int]"/>
        public T this[int index] => Data[index];

        /// <summary>
        /// Goes back 1 page <br></br>
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"> if there is no previous page</exception>
        public static IPage<T> operator --(IPage<T> page) => page.Previous();

        /// <inheritdoc cref="operator --(IPage{T})"/>
        public abstract IPage<T> Previous(List<T>? data = null);

        /// <summary>
        /// Goes forward 1 page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">if there is no next page</exception>
        public static IPage<T> operator ++(IPage<T> page) => page.Next();

        /// <inheritdoc cref="operator ++(IPage{T})"/>
        public abstract IPage<T> Next(List<T>? data = null);

        /// <summary>
        /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();
    }
}
