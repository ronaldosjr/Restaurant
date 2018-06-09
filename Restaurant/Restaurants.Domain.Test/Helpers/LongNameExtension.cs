using System;
using System.Linq;

namespace Restaurants.Domain.Test.Helpers
{
    public static class LongNameExtension
    {
        public static string ToLongName(this string source, int size)
        {
            return new string(Enumerable.Repeat(source, size + 2)
                .Select(i => i[new Random().Next(i.Length)]).ToArray());

        }
    }
}
