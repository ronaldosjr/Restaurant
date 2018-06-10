using System;
using System.Collections.Generic;
using System.Text;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Services.ValidationServices.Common;

namespace Restaurants.Domain.Services.ValidationServices.Interface
{
    public interface IDishValidationBeforePersist : IValidationBeforePersist<Dish>
    {
    }
}
