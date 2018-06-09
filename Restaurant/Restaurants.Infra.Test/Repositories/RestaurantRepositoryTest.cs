using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Specification.Restaurant;
using Restaurants.Infra.Repositories.Common;


namespace Restaurants.Infra.Test.Repositories
{
    public class RestaurantRepositoryTest
    {
        private readonly IRepository<Restaurant> _repository;

        public RestaurantRepositoryTest()
        {
            var mock = new Mock<IRepository<Restaurant>>();
            var lista = FakeRestaurants().ToList();

            mock.Setup(t => t.Add(It.IsAny<Restaurant>())).Verifiable();
            mock.Setup(t => t.Update(It.IsAny<Restaurant>())).Verifiable();
            mock.Setup(t => t.Delete(It.IsAny<Restaurant>())).Verifiable();
            mock.Setup(t => t.GetAll()).Returns(lista);
            mock.Setup(t => t.Get(It.IsAny<RestaurantIdEqualsToSpecification>()))
                .Returns((RestaurantIdEqualsToSpecification spec) => lista.FirstOrDefault(spec.ToExpression().Compile()));
            mock.Setup(t => t.Find(It.IsAny<RestaurantIdEqualsToSpecification>()))
                .Returns((RestaurantIdEqualsToSpecification spec) => lista.Where(spec.ToExpression().Compile()).ToList());

            _repository = mock.Object;

        }


        [Test]
        public void Should_Add_Restaurant()
        {
            Assert.DoesNotThrow(() => _repository.Add(CreateFakeRestaurant()));
        }


        [Test]
        public void Should_Edit_Restaurant()
        {
            Assert.DoesNotThrow(() => _repository.Update(CreateFakeRestaurant()));
        }

        [Test]
        public void Should_Remove_Restaurant()
        {
            Assert.DoesNotThrow(() => _repository.Delete(CreateFakeRestaurant()));
        }

        [Test]
        public void Should_Get_Restaurant()
        {
            var restaurant = CreateFakeRestaurant();
            restaurant.Id = 1;
            var findById = new RestaurantIdEqualsToSpecification(restaurant.Id);

            Assert.AreEqual(_repository.Get(findById)?.Id, restaurant.Id);
        }

        [Test]
        public void Should_Find_Restaurant()
        {
            var restaurant = CreateFakeRestaurant();
            restaurant.Id = 2;
            var findById = new RestaurantIdEqualsToSpecification(restaurant.Id);
            Assert.AreEqual(_repository.Find(findById).FirstOrDefault()?.Id, restaurant.Id);
        }

        [Test]
        public void Should_Get_All_Restaurant()
        {
            Assert.AreEqual(_repository.GetAll().Count, FakeRestaurants().Count());
        }

        private Restaurant CreateFakeRestaurant() => new Restaurant("Fake");


        private IEnumerable<Restaurant> FakeRestaurants() => new List<Restaurant>
            {
                new Restaurant("Fake1"){Id = 1},
                new Restaurant("Fake2"){Id = 2},
                new Restaurant("Fake3"){Id = 3},
            };
        
    }
}
