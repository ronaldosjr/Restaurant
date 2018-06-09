using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Restaurants.WebApi.Helpers
{
    public static class ModelStateErrorInlineHelper
    {
        public static string ToInlineError(this ModelStateDictionary.ValueEnumerable source)
        {
            return string.Join(" | ", source.SelectMany(v => v.Errors).Select(v => v.ErrorMessage));
        }
    }
}
