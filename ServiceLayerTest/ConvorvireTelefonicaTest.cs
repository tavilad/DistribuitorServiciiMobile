using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
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
    public class ConvorvireTelefonicaTest
    {
        [TestMethod]
        public async Task TestCreateConvorbire()
        {
            Mock<IConvorbireTelefonicaRepository> mock = new Mock<IConvorbireTelefonicaRepository>();
            ConvorbireTelefonicaController controller = new ConvorbireTelefonicaController(mock.Object);

            ConvorbireTelefonica convorbire = new ConvorbireTelefonica()
            {
                Id = new Guid(),
                Initiator = new Client(),
                Receptor = new Client(),
                DurataConvorbire = 10,
                TipConvorbire = "Retea"
            };

            mock.Setup(t => t.Insert(It.IsAny<ConvorbireTelefonica>())).Verifiable();

            await controller.AddConvorbire(convorbire);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteConvorbire()
        {
            Mock<IConvorbireTelefonicaRepository> mock = new Mock<IConvorbireTelefonicaRepository>();
            ConvorbireTelefonicaController controller = new ConvorbireTelefonicaController(mock.Object);

            ConvorbireTelefonica convorbire = new ConvorbireTelefonica()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Delete(It.IsAny<ConvorbireTelefonica>())).Verifiable();

            await controller.DeleteConvorbire(convorbire);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllConvorbire()
        {
            ConvorbireTelefonica[] convorbiri = { new ConvorbireTelefonica { Id = new Guid() }, new ConvorbireTelefonica { Id = new Guid() } };

            Mock<IConvorbireTelefonicaRepository> mock = new Mock<IConvorbireTelefonicaRepository>();
            ConvorbireTelefonicaController controller = new ConvorbireTelefonicaController(mock.Object);

            mock.Setup(t => t.Get(
                It.IsAny<Expression<Func<ConvorbireTelefonica, bool>>>(),
                It.IsAny<Func<IQueryable<ConvorbireTelefonica>, IOrderedQueryable<ConvorbireTelefonica>>>(),
                It.IsAny<string>())).ReturnsAsync(convorbiri);

            IEnumerable<ConvorbireTelefonica> found = await controller.GetAllConvorbire();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            Mock<IConvorbireTelefonicaRepository> mock = new Mock<IConvorbireTelefonicaRepository>();
            ConvorbireTelefonicaController controller = new ConvorbireTelefonicaController(mock.Object);

            mock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeleteConvorbireByID(1);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Mock<IConvorbireTelefonicaRepository> mock = new Mock<IConvorbireTelefonicaRepository>();
            ConvorbireTelefonicaController controller = new ConvorbireTelefonicaController(mock.Object);

            ConvorbireTelefonica convorbire = new ConvorbireTelefonica()
            {
                Id = new Guid()
            };

            convorbire.DurataConvorbire = 100;

            mock.Setup(t => t.Update(It.IsAny<ConvorbireTelefonica>())).Verifiable();

            await controller.UpdateConvorbire(convorbire);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetById()
        {
            Mock<IConvorbireTelefonicaRepository> mock = new Mock<IConvorbireTelefonicaRepository>();
            ConvorbireTelefonicaController controller = new ConvorbireTelefonicaController(mock.Object);

            mock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new ConvorbireTelefonica());

            ConvorbireTelefonica convorbire = await controller.GetById(Guid.NewGuid());

            Assert.IsNotNull(convorbire);
        }
    }
}
