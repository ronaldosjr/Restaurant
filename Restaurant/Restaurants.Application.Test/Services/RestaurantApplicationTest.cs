﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Restaurants.Application.Dtos;
using Restaurants.Application.Dtos.Mappers;
using Restaurants.Application.Services;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Domain.Services.ValidationServices;
using Restaurants.Infra.Context;
using Restaurants.Infra.Repositories;

namespace Restaurants.Application.Test.Services
{
    public class RestaurantApplicationTest
    {
        private readonly IRestaurantApplication _application;

        public RestaurantApplicationTest() => _application = Configuration();

        private IRestaurantApplication Configuration()
        {
            var builder =
                new DbContextOptionsBuilder<RestaurantContext>()
                    .UseInMemoryDatabase("restaurant")
                    .Options;
            var context = new RestaurantContext(builder);
            var connection = new Connection(context);

            var mapperConfig = new MapperConfiguration(map => { map.AddProfile<DtoMapper>(); });
            var mapper = mapperConfig.CreateMapper();
            var repository = new RestaurantRepository(connection);
            var validation = new RestaurantValidationBeforePersist(repository);

            return new RestaurantApplication(connection, mapper, repository, validation);
        }

        private RestaurantDto CreateValidRestaurant(string name) => new RestaurantDto { Name = name };

        [Test]
        public void Should_Add_Restaurant()
        {
            var dish = CreateValidRestaurant("restaurant insert");
            var saved = _application.Add(dish);
            Assert.IsTrue(saved.Id > 0);
        }

        [Test]
        public void Should_Update_Restaurant()
        {
            var added = _application.Add(CreateValidRestaurant("restaurant update"));
            added.Name = "New Name";
            var update = _application.Update(added);
            Assert.IsTrue(update.Name.Equals(added.Name));
        }

        [Test]
        public void Should_Delete_Restaurant()
        {
            var added = _application.Add(CreateValidRestaurant("restaurant delete"));
            Assert.DoesNotThrow(() => _application.Delete(added));
        }

        [Test]
        public void Should_Get_All()
        {
            var dishList = new List<RestaurantDto>
            {
                CreateValidRestaurant("restaurant 1"),
                CreateValidRestaurant("restaurant 2"),
                CreateValidRestaurant("restaurant 3"),
            };

            foreach (var item in dishList)
                _application.Add(item);

            var listAdded = _application.GetAll().ToList();

            foreach (var item in dishList)
                Assert.IsTrue(listAdded.Any(i => i.Name.Equals(item.Name)));

        }

        [Test(ExpectedResult = true)]
        public bool Should_Name_Taken()
        {
            var added = _application.Add(CreateValidRestaurant("restaurant taken"));
            return _application.IsNameTaken(added);
        }

        [Test]
        public void Should_Get_By_Id()
        {
            var added = _application.Add(CreateValidRestaurant("restaurant by id"));
            Assert.IsNotNull(_application.GetById(added.Id));
        }
    }
}
