﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restaurants.WebApi.Helpers;
using Restaurants.Application.Dtos.Common;
using Restaurants.Application.Services.Common;
using Restaurants.Domain.Entities.Common;
using Restaurants.Api.Helpers;

namespace Restaurants.WebApi.Controllers.Common
{

    public abstract class BaseCrudController<TDto,TEntity> : ControllerBase
        where TDto : BaseCrudDto
        where TEntity : BaseEntity
    {
        protected readonly ICrudApplication<TDto, TEntity> Application;

        public BaseCrudController(ICrudApplication<TDto, TEntity> application)
        {
            Application = application;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TDto>> GetAll()
        {
            try
            {
                return new ActionResult<IEnumerable<TDto>>(Application.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<TDto> Add([FromBody] TDto dto)
        {

            try
            {
                return Application.Add(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public ActionResult<TDto> Update([FromBody] TDto dto)
        {
            
            try
            {
                return Application.Update(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public ActionResult<TDto> Delete([FromBody] TDto dto)
        {
            try
            {
                Application.Delete(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
