using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Roblox_Sharp
{

    /// <summary>
    /// represents data fetched from the roblox api
    /// </summary>
    public readonly struct FetchedData
    {
        /// <summary>
        /// the fetched json data
        /// </summary>
        [StringSyntax(StringSyntaxAttribute.Json)]
        public readonly string Json;

        /// <summary>
        /// whether the fetch was successful
        /// </summary>
        /// <returns>
        /// <inheritdoc cref="System.Net.Http.HttpResponseMessage.IsSuccessStatusCode"/>
        /// </returns>
        public readonly bool Success;

        /// <summary>
        /// constructor to represent data fetched from the roblox api
        /// </summary>
        /// <param name="json"></param>
        /// <param name="success"></param>
        public FetchedData([StringSyntax(StringSyntaxAttribute.Json)] string? json, bool success)
        {
            this.Json = json ?? string.Empty;
            this.Success = !string.IsNullOrEmpty(json) && success;
        }

        /// <summary>
        /// deconstructs the <see cref="FetchedData"/>
        /// </summary>
        /// <param name="json"></param>
        /// <param name="success"></param>
        public void Deconstruct(out string json, out bool success) => (json, success) = (this.Json, this.Success);

        /// <returns> returns the <see cref="Json"/></returns>
        public override string ToString() => Json;

        /// <returns>
        /// the deserialized <typeparamref name="T"/> <br/> 
        /// <see langword="null"/> or <see langword="default"/> if the request is not successful
        /// </returns>
        /// <inheritdoc cref="JsonSerializer.Deserialize{TValue}(string, JsonSerializerOptions?)"/>
        public T? Deserialize<T>() => this.Success
            ? JsonSerializer.Deserialize<T>(this.Json)
            : default;
    }
}
