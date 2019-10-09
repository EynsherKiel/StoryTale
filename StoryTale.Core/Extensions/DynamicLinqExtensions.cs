using System;
using System.Linq.Dynamic.Core;

namespace StoryTale.Core.Extensions
{
    public static class DynamicLinqExtensions
    {
        public static Func<TFrom, TTo> ToLambda<TFrom, TTo>(this string expr)
        {
            return DynamicExpressionParser.ParseLambda<TFrom, TTo>(ParsingConfig.Default, false, expr).Compile();
        }
    }
}