using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Restaurants.Application.Dtos.Common;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dtos
{
    public class RestaurantDto : BaseCrudDto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} do restaurante deve ser informado")]
        [StringLength(Restaurant.NameLength, ErrorMessage = "{0} do prato deve conter no máximo {1}")]
        public string Name { get; set; }
    }
}
