using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Specification.Common;
using Restaurants.Domain.Specification.Dish;
using Restaurants.Infra.Repositories.Common;

namespace Restaurants.Infra.Test.Repositories
{
    [TestFixture]
    public class DishRepositoryTest
    {
        private readonly IRepository<Dish> _repository;

        public DishRepositoryTest()
        {
            var mock = new Mock<IRepository<Dish>>();
            var lista = FakeDish().ToList();

            mock.Setup(t => t.Add(It.IsAny<Dish>())).Verifiable();
            mock.Setup(t => t.Update(It.IsAny<Dish>())).Verifiable();
            mock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();
            mock.Setup(t => t.GetAll()).Returns(lista);
            mock.Setup(t => t.Get(It.IsAny<Specification<Dish>>()))
                .Returns((DishIdEqualsToSpecification spec) => lista.FirstOrDefault(spec.ToExpression().Compile()));
            mock.Setup(t => t.Find(It.IsAny<Specification<Dish>>()))
                .Returns((DishIdEqualsToSpecification spec) => lista.Where(spec.ToExpression().Compile()).ToList());

            _repository = mock.Object;

        }

        [Test]
        public void Should_Add_Dish()
        {
            Assert.DoesNotThrow(() => _repository.Add(CreateFakeDish()));
        }


        [Test]
        public void Should_Edit_Dish()
        {
            Assert.DoesNotThrow(() => _repository.Update(CreateFakeDish()));
        }

        [Test]
        public void Should_Remove_Dish()
        {
            Assert.DoesNotThrow(() => _repository.Delete(CreateFakeDish().Id));
        }

        [Test]
        public void Should_Get_Dish()
        {
            var dish = CreateFakeDish();
            dish.Id = 1;
            var findById = new DishIdEqualsToSpecification(dish.Id);
           
            Assert.AreEqual(_repository.Get(findById)?.Id, dish.Id);
        }

        [Test]
        public void Should_Find_Dish()
        {
            var dish = CreateFakeDish();
            dish.Id = 2;
            var findById = new DishIdEqualsToSpecification(dish.Id);
            Assert.AreEqual(_repository.Find(findById).FirstOrDefault()?.Id, dish.Id);
        }

        [Test]
        public void Should_Get_All_Dish()
        {
            Assert.AreEqual(_repository.GetAll().Count, FakeDish().Count());
        }

        private Dish CreateFakeDish()
        {
            return new Dish("dish", 10, new Restaurants.Domain.Entities.Restaurant("restaurant") { Id = 1 });
        }

        private IEnumerable<Dish> FakeDish()
        {
            return new List<Dish>
            {
                new Dish("Fake 1", 11, new Restaurant("Fake"){Id = 1}){Id = 1},
                new Dish("Fake 2", 12, new Restaurant("Fake"){Id = 1}){Id = 2},
                new Dish("Fake 3", 13, new Restaurant("Fake"){Id = 1}){Id = 3},
            };
        }
    }
}
