using System.Diagnostics.CodeAnalysis;

namespace Roblox_Sharp
{
    /// <summary>
    /// represents data fetched from the roblox api
    /// </summary>
    /// <param name="json"></param>
    /// <param name="success"></param>
    public class FetchedData(in string? json,in bool success)
    {
        /// <summary>
        /// the fetched json data
        /// </summary>
        [StringSyntax(StringSyntaxAttribute.Json)]
        public readonly string Json = json ?? string.Empty;

        /// <summary>
        /// whether the fetch was successful
        /// </summary>
        public readonly bool Success = json is not null && json != string.Empty && success;

        #region lossless convert
        /// <summary>
        /// lossless convert from tuple to FetchedData
        /// </summary>
        /// <param name="tuple"></param>
        public static implicit operator FetchedData(in (string json, bool success) tuple) => new(tuple.json, tuple.success);

        /// <summary>
        /// lossless convert to tuple
        /// </summary>
        /// <param name="data"></param>
        public static implicit operator (string json, bool success)(in FetchedData data) => (data.Json, data.Success);

        #endregion

        /// <summary>
        /// lossy convert to bool
        /// </summary>
        /// <param name="data"></param>
        public static explicit operator bool(FetchedData data) => data.Success;

        /// <summary>
        /// returns the <see cref="Json"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Json;
    }
}
