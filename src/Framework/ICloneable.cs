using System;

namespace Roblox_Sharp.Framework
{
    ///<inheritdoc cref="ICloneable"/>
    public interface ICloneable<T> 
        where T : new()
    {

        /// <summary>
        /// <inheritdoc cref="ICloneable.Clone"/>
        /// </summary>
        /// <returns>a deep copy of the <typeparamref name="T"/></returns>
        T Clone();
    }
}
