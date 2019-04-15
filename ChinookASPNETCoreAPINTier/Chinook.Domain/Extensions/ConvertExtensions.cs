using Chinook.Domain.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Domain.Extensions
{
    public static class ConvertExtensions
    {
        public static IEnumerable<TTarget> ConvertAll<TSource, TTarget>(
            this IEnumerable<IConvertModel<TSource, TTarget>> values) 
            => values.Select(value => value.Convert);
    }
}