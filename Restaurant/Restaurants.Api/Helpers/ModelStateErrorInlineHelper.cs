using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Restaurants.Api.Helpers
{
    public static class ModelStateErrorInlineHelper
    {
        public static string ToInlineError(this ModelStateDictionary.ValueEnumerable source)
        {
            return string.Join(" | ", source.SelectMany(v => v.Errors).Select(v => v.ErrorMessage));
        }
    }
}
