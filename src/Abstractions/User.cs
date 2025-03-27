using System;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Roblox_Sharp.Abstractions
{
    /// <summary>
    /// represents any User based request that contains the user id and the username
    /// </summary>
    [DebuggerDisplay("{Username} (ID {UserId})")]
    public abstract class User : Creation<IUser>, IUser , IFormattable
    {
        /// <summary>
        /// The user's unique username
        /// </summary>
        [JsonPropertyName("username")]
        public required string Username { get; init; }

        /// <inheritdoc/>
        [JsonPropertyName("userId")]
        public required ulong UserId
        {
            get => base.Id;
            init => base.Id = value;
        }

        /// <returns>
        /// A string representation of the <see cref="User"/>
        /// </returns>
        public override string ToString() => $"{Username} (ID {UserId})";
      
        /// /// <summary>
        /// Formats the <see cref="User"/> information based on the provided format string.
        /// Supported format strings:
        /// <list type="table">
        ///   <listheader>
        ///     <term>Format</term>
        ///     <description>Output</description>
        ///   </listheader>
        ///   <item>
        ///     <term>"id"</term>
        ///     <description>Returns the <see cref="User.UserId"/></description>
        ///   </item>
        ///   <item>
        ///     <term>"name"</term>
        ///     <description>Returns the <see cref="User.Username"/></description>
        ///   </item>
        /// </list>
        /// </summary>
        /// <returns>
        /// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)"/>
        /// </returns>
        public string ToString(string? format, IFormatProvider? formatProvider) => format == null ? ToString()
            : format switch
            {
                //user id 
                "id" => $"(ID {UserId}) ",
                "name" => "@{username} ",
                _ => throw new FormatException()
            };
    }
}
