using DataMapper;
using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
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
    public class ClientTest
    {
        [TestMethod]
        public async Task TestCreateClient()
        {
            Client client = new Client()
            {
                FirstName = "Johnny",
                LastName = "Bravo",
            };

            Mock<IClientRepository> repositoryMock = new Mock<IClientRepository>();
            ClientController controller = new ClientController(repositoryMock.Object);

            repositoryMock.Setup(t => t.Insert(It.IsAny<Client>())).Verifiable();

            await controller.AddClient(client);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteClient()
        {
            Client client = new Client()
            {
                FirstName = "Johnny",
                LastName = "Bravo",
            };

            Mock<IClientRepository> repositoryMock = new Mock<IClientRepository>();
            ClientController controller = new ClientController(repositoryMock.Object);

            repositoryMock.Setup(t => t.Delete(It.IsAny<Client>())).Verifiable();

            await controller.DeleteClient(client);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllClient()
        {
            Mock<IClientRepository> repositoryMock = new Mock<IClientRepository>();
            ClientController controller = new ClientController(repositoryMock.Object);

            Client[] clienti = { new Client { Id = new Guid() }, new Client { Id = new Guid() } };

            repositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Client, bool>>>(),
                It.IsAny<Func<IQueryable<Client>, IOrderedQueryable<Client>>>(),
                It.IsAny<string>())).ReturnsAsync(clienti);

            IEnumerable<Client> found = await controller.GetAllClient();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            Mock<IClientRepository> repositoryMock = new Mock<IClientRepository>();
            ClientController controller = new ClientController(repositoryMock.Object);

            repositoryMock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeleteClientByID(1);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Mock<IClientRepository> repositoryMock = new Mock<IClientRepository>();
            ClientController controller = new ClientController(repositoryMock.Object);

            Client client = new Client()
            {
                Id = new Guid()
            };

            client.FirstName = "Gion";

            repositoryMock.Setup(t => t.Update(It.IsAny<Client>())).Verifiable();

            await controller.UpdateClient(client);

            repositoryMock.VerifyAll();
        }
    }
}
