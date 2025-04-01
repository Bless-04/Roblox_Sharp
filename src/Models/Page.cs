using System;
using System.Collections.Generic;

namespace Roblox_Sharp.Models
{
    /// <inheritdoc cref="Page{T}"/>
    public class Page<T>() : Abstractions.Page<T> 
    {
        public override Abstractions.Page<T> go_Next()
        {
            throw new NotImplementedException();
        }

        public Page<T> go_Prev() => throw new NotImplementedException();

        public override Abstractions.Page<T> go_Previous()
        {
            throw new NotImplementedException();
        }
    }
}
