using System.ComponentModel.DataAnnotations;
using Restaurants.Application.Dtos.Common;
using Restaurants.Domain.Entities;


namespace Restaurants.Application.Dtos
{
    public class DishDto : BaseCrudDto
    {
        public DishDto()
        {

        }

        [Display(Name= "Nome")]
        [Required(ErrorMessage = "{0} do prato deve ser informado")]
        [StringLength(Dish.NameLength, ErrorMessage = "{0} do prato deve conter no máximo {1}")]
        public string Name { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "{0} do prato deve ser informado")]
        [Range(0.00000001, 999999999, ErrorMessage = "{0} deve ser maior que 0.00")]
        public decimal Price { get; set; }

        [Display(Name = "Restaurante")]
        [Required(ErrorMessage = "{0} deve ser informado")]
        public RestaurantDto Restaurant { get; set; }

        public int RestaurantId { get; set; }
    }
}
