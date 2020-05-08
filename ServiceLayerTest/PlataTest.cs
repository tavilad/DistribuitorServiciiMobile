using DataMapper.Interfaces;
using DomainModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTest
{
    [TestClass]
    public class PlataTest
    {
        [TestMethod]
        public async Task TestCreatePlata()
        {
            Mock<IPlataRepository> mock = new Mock<IPlataRepository>();
            PlataController controller = new PlataController(mock.Object);

            Plata plata = new Plata()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Insert(It.IsAny<Plata>())).Verifiable();

            await controller.AddPlata(plata);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeletPlata()
        {
            Mock<IPlataRepository> mock = new Mock<IPlataRepository>();
            PlataController controller = new PlataController(mock.Object);

            Plata plata = new Plata()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Delete(It.IsAny<Plata>())).Verifiable();

            await controller.DeletePlata(plata);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllPlata()
        {
            Plata[] plata = { new Plata { Id = new Guid() }, new Plata { Id = new Guid() } };

            Mock<IPlataRepository> mock = new Mock<IPlataRepository>();
            PlataController controller = new PlataController(mock.Object);

            mock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Plata, bool>>>(),
                It.IsAny<Func<IQueryable<Plata>, IOrderedQueryable<Plata>>>(),
                It.IsAny<string>())).ReturnsAsync(plata);

            IEnumerable<Plata> found = await controller.GetAllPlata();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            Mock<IPlataRepository> mock = new Mock<IPlataRepository>();
            PlataController controller = new PlataController(mock.Object);

            mock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeletePlataByID(1);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Mock<IPlataRepository> mock = new Mock<IPlataRepository>();
            PlataController controller = new PlataController(mock.Object);

            Plata plata = new Plata()
            {
                Id = new Guid()
            };

            plata.TotalDePlata = 100;

            mock.Setup(t => t.Update(It.IsAny<Plata>())).Verifiable();

            await controller.UpdatePlata(plata);

            mock.VerifyAll();
        }
    }
}
