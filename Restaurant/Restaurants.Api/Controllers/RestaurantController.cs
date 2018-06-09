using System;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Api.Controllers.Common;
using Restaurants.Application.Dtos;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Domain.Entities;

namespace Restaurants.Api.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : BaseCrudController<RestaurantDto, Restaurant>
    {
        private readonly IRestaurantApplication _restaurantApplication;

        public RestaurantController(
            IRestaurantApplication application) : base(application)
        {
            _restaurantApplication = application;
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> GetById([FromRoute] int id)
        {
            try
            {
                return _restaurantApplication.GetById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("nameTaken/{name}/{id}")]
        public ActionResult<bool> IsNameTaken([FromRoute] string name, [FromRoute] int id)
        {
            try
            {
                return _restaurantApplication.IsNameTaken(new RestaurantDto{Name =  name, Id = id});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}