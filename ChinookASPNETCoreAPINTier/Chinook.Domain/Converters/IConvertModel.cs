using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Domain.Converters
{
    public interface IConvertModel<TSource, TTarget>
    {
        TTarget Convert { get; }
    }
}