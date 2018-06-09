using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.WebApi.Controllers.Common;
using Restaurants.Application.Dtos;
using Restaurants.Application.Services.Common;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Domain.Entities;

namespace Restaurants.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("nameTaken/{name}")]
        public ActionResult<bool> GetById([FromRoute] string name)
        {
            try
            {
                return _restaurantApplication.IsNameTaken(name);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}