using System.Linq;

namespace Restaurants.Domain.Test.Helpers
{
    public static class InvertStringExtension
    {
        public static string ReverseString(this string source)
        {
            var array = source.ToCharArray().Reverse();
            return new string(array.ToArray());
        }
    }
}
