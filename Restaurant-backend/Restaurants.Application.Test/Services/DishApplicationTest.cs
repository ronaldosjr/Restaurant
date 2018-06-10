using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Restaurants.Application.Dtos;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Application.Test.Helpers;

namespace Restaurants.Application.Test.Services
{
    [TestFixture]
    public class DishApplicationTest
    {
        private readonly IDishApplication _application;

        public DishApplicationTest() => _application = ObjectInitiliazer.CreateDishApplication();

        private DishDto CreateValidDish(string name) => new DishDto { Name = name, Price = 20, Restaurant = new RestaurantDto { Name = "Restaurant" } };

        [Test]
        public void Should_Add_Dish()
        {
            var dish = CreateValidDish("prato insert");
            var saved = _application.Add(dish);
            Assert.IsTrue(saved.Id > 0);
        }

        [Test]
        public void Should_Update_Dish()
        {
            var added = _application.Add(CreateValidDish("prato update"));
            added.Name = "New Name";
            var update = _application.Update(added);
            Assert.IsTrue(update.Name.Equals(added.Name));
        }

        [Test]
        public void Should_Delete_Dish()
        {
            var added = _application.Add(CreateValidDish("prato delete"));
            Assert.DoesNotThrow(() => _application.Delete(added.Id));
        }

        [Test]
        public void Should_Get_All()
        {
            var dishList = new List<DishDto>
            {
                CreateValidDish("pratolist 1"),
                CreateValidDish("pratolist 2"),
                CreateValidDish("pratolist 3"),
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
            var added = _application.Add(CreateValidDish("prato taken"));
            return _application.IsNameTaken(added);
        }
        
        [Test]
        public void Should_Get_By_Id()
        {
            var added = _application.Add(CreateValidDish("dish by id"));
            Assert.IsNotNull(_application.GetById(added.Id));
        }
    }
}
