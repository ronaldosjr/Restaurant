using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.WebApi.Controllers.Common;
using Restaurants.WebApi.Helpers;
using Restaurants.Application.Dtos;
using Restaurants.Application.Services.Common;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Domain.Entities;

namespace Restaurants.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DishController :  BaseCrudController<DishDto, Dish>
    {
        private IDishApplication _dishApplication { get; }

        public DishController(
            IDishApplication application
            ) : base(application)
        {
            _dishApplication = application;
        }

        [HttpGet("{id}")]
        public ActionResult<DishDto> GetById([FromRoute] int id)
        {
            try
            {
                return _dishApplication.GetById(id);
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
                return _dishApplication.IsNameTaken(name);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}