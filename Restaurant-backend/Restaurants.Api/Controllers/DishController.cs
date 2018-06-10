using System;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Api.Controllers.Common;
using Restaurants.Application.Dtos;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Domain.Entities;

namespace Restaurants.Api.Controllers
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

        [HttpGet("nameTaken/{name}/{id}")]
        public ActionResult<bool> IsNameTaken([FromRoute] string name, [FromRoute] int id)
        {
            try
            {
                return _dishApplication.IsNameTaken(new DishDto {Name = name, Id = id});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}