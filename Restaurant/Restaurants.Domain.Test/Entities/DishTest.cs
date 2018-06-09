using System;
using NUnit.Framework;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Specification.Dish;
using Restaurants.Domain.Test.Helpers;

namespace Restaurants.Domain.Test.Entities
{
    [TestFixture]
    public class DishTest
    {
        private static readonly string _validName = "Test Case";
        private static readonly string _avaibleName = "Avaible";
        private static readonly decimal _validPrice = 1;
        private static readonly decimal _invalidPrice = 0;
        private static readonly Restaurant ValidRestaurant = new Restaurant(_validName);

        private static Dish CreateValidDish() => new Dish(_validName, _validPrice, ValidRestaurant);

        [Test]
        public void Should_Create_Dish(Dish dish)
        {
            Assert.IsInstanceOf<Dish>(CreateValidDish());
        }
        
        [Test]
        public void Should_Not_Create_Dish_With_Null_Name()
        {
            Assert.Throws<Exception>(() => new Dish(null, _validPrice, new Restaurant(_validName)));
        }

        [Test]
        public void Should_Not_Create_Dish_With_Empty_Name()
        {
            Assert.Throws<Exception>(() => new Dish(string.Empty, _validPrice, ValidRestaurant));
        }

        [Test]
        public void Should_Not_Create_Dish_With_Long_Name()
        {
            Assert.Throws<Exception>(() => new Dish(_validName.ToLongName(Dish.NameLength), _validPrice, ValidRestaurant));
        }

        [Test]
        public void Should_Not_Create_Dish_With_Invalid_Price()
        {
            Assert.Throws<Exception>(() => new Dish(_validName, _invalidPrice, ValidRestaurant));
        }

        [Test]
        public void Should_Not_Create_Dish_With_Null_Restaurant()
        {
            Assert.Throws<Exception>(() => new Dish(_validName, _validPrice, null));
        }

        [Test]
        public void Should_Validate_Dish_With_Taken_Name()
        {
            var spec = new DishNameTakenSpecification(CreateValidDish());
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidDish()), true);
        }

        [Test]
        public void Should_Validate_Dish_With_Taken_Name_Lower_Case()
        {
            var spec = new DishNameTakenSpecification(new Dish(_validName.ToLower(), _validPrice, ValidRestaurant));
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidDish()), true);
        }

        [Test]
        public void Should_Validate_Dish_With_Taken_Name_Upper_Case()
        {
            var spec = new DishNameTakenSpecification(new Dish(_validName.ToUpper(), _validPrice, ValidRestaurant));
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidDish()), true);
        }
        
        [Test]
        public void Should_Not_Validate_Dish_With_Avaible_Name()
        {
            var spec = new DishNameTakenSpecification(new Dish(_validName.ReverseString(), _validPrice, ValidRestaurant));
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidDish()), false);
        }

        [Test]
        public void Should_Validade_Dish_With_Same_Id()
        {
            var spec = new DishIdEqualsToSpecification(1);
            Assert.AreEqual(spec.IsSatisfiedBy(new Dish { Id = 1 }), true);
        }

        [Test]
        public void Should_Not_Validade_Dish_With_Diff_Id()
        {
            var spec = new DishIdEqualsToSpecification(2);
            Assert.AreEqual(spec.IsSatisfiedBy(new Dish { Id = 1 }), false);
        }
    }
}
