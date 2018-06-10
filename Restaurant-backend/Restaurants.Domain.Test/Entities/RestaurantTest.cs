using System;
using NUnit.Framework;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Specification.Restaurant;
using Restaurants.Domain.Test.Helpers;

namespace Restaurants.Domain.Test.Entities
{
    [TestFixture]
    public class RestaurantTest
    {
        private static readonly string _validName = "Teste case";
        private static readonly string _avaibleName = "Avaible name";
        private static Restaurant CreateValidRestaurants() => new Restaurant(_validName);

        [Test]
        public void Should_Create_Restaurant()
        {
            Assert.IsInstanceOf<Restaurant>(CreateValidRestaurants());
        }

        [Test]
        public void Should_Not_Create_With_Null_Name()
        {
            Assert.Throws<Exception>(() => new Restaurant(null));
        }

        [Test]
        public void Should_Not_Create_With_Empty_Name()
        {
            Assert.Throws<Exception>(() => new Restaurant(string.Empty));
        }

        [Test]
        public void Should_Not_Create_With_Long_Name()
        {
            Assert.Throws<Exception>(() => new Restaurant(_validName.ToLongName(Restaurant.NameLength)));
        }
        
        [Test]
        public void Should_Validate_Restaurants_With_Taken_Name()
        {
            var spec = new RestaurantNameTakenSpecification(CreateValidRestaurants());
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidRestaurants()), true);
        }

        [Test]
        public void Should_Validate_Restaurants_With_Taken_Name_Lower_Case()
        {
            var spec = new RestaurantNameTakenSpecification(new Restaurant(_validName.ToLower()));
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidRestaurants()), true);
        }

        [Test]
        public void Should_Validate_Restaurants_With_Taken_Name_Upper_Case()
        {
            var spec = new RestaurantNameTakenSpecification(new Restaurant(_validName.ToUpper()));
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidRestaurants()), true);
        }

        [Test]
        public void Should_Not_Validate_Restaurants_With_Avaible_Name()
        {
            var spec = new RestaurantNameTakenSpecification(new Restaurant(_avaibleName.ReverseString()));
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidRestaurants()), false);
        }

        [Test]
        public void Should_Validade_Restaurants_With_Same_Id()
        {
            var spec = new RestaurantIdEqualsToSpecification(1);
            Assert.AreEqual(spec.IsSatisfiedBy(new Restaurant { Id = 1 }), true);
        }

        [Test]
        public void Should_Not_Validade_Restaurants_With_Diff_Id()
        {
            var spec = new RestaurantIdEqualsToSpecification(2);
            Assert.AreEqual(spec.IsSatisfiedBy(new Restaurant { Id = 1 }), false);
        }
    }
}
