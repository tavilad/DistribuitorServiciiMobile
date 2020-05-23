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
    public class PretTest
    {
        [TestMethod]
        public async Task TestCreatePret()
        {
            Mock<IPretRepository> mock = new Mock<IPretRepository>();
            PretController controller = new PretController(mock.Object);

            Pret pret = new Pret()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Insert(It.IsAny<Pret>())).Verifiable();

            await controller.AddPret(pret);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeletePret()
        {
            Mock<IPretRepository> mock = new Mock<IPretRepository>();
            PretController controller = new PretController(mock.Object);

            Pret pret = new Pret()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Delete(It.IsAny<Pret>())).Verifiable();

            await controller.DeletePret(pret);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllPret()
        {
            Pret[] Pret = { new Pret { Id = new Guid() }, new Pret { Id = new Guid() } };

            Mock<IPretRepository> mock = new Mock<IPretRepository>();
            PretController controller = new PretController(mock.Object);

            mock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Pret, bool>>>(),
                It.IsAny<Func<IQueryable<Pret>, IOrderedQueryable<Pret>>>(),
                It.IsAny<string>())).ReturnsAsync(Pret);

            IEnumerable<Pret> found = await controller.GetAllPret();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            Mock<IPretRepository> mock = new Mock<IPretRepository>();
            PretController controller = new PretController(mock.Object);

            mock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeletePretByID(1);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Mock<IPretRepository> mock = new Mock<IPretRepository>();
            PretController controller = new PretController(mock.Object);

            Pret Pret = new Pret()
            {
                Id = new Guid()
            };

            Pret.Suma = 100;

            mock.Setup(t => t.Update(It.IsAny<Pret>())).Verifiable();

            await controller.UpdatePret(Pret);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetById()
        {
            Mock<IPretRepository> mock = new Mock<IPretRepository>();
            PretController controller = new PretController(mock.Object);

            mock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new Pret());

            Pret Pret = await controller.GetById(Guid.NewGuid());

            Assert.IsNotNull(Pret);
        }
    }
}
