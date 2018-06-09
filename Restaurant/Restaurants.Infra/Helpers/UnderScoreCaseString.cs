using System.Linq;

namespace Restaurants.Infra.Helpers
{
    public static class UnderScoreCaseString
    {
        public static string ToUnderscoreCase(this string source)
        {
            return string.Concat(source.Select((left, right) => 
                    right > 0 && char.IsUpper(left) 
                        ? "_" + left.ToString() 
                        : left.ToString())).ToLower();
        }
    }
}
