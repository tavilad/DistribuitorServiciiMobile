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
using System.Threading.Tasks;

namespace ServiceLayerTest
{
    [TestClass]
    public class ClientTest
    {
        Mock<IClientRepository> clientRepositoryMock;
        ClientController controller;
        Mock<IPlataRepository> plataRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            this.clientRepositoryMock = new Mock<IClientRepository>();
            this.plataRepositoryMock = new Mock<IPlataRepository>();
            this.controller = new ClientController(this.clientRepositoryMock.Object, this.plataRepositoryMock.Object, 
                new Mock<IConvorbireTelefonicaRepository>().Object, new Mock<IAbonamentRepository>().Object);
        }

        [TestMethod]
        public async Task TestCreateClient()
        {
            Client client = new Client()
            {
                FirstName = "Johnny",
                LastName = "Bravo",
            };

            this.clientRepositoryMock.Setup(t => t.Insert(It.IsAny<Client>())).Verifiable();

            await controller.AddClient(client);

            this.clientRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteClient()
        {
            Client client = new Client()
            {
                FirstName = "Johnny",
                LastName = "Bravo",
            };

            this.clientRepositoryMock.Setup(t => t.Delete(It.IsAny<Client>())).Verifiable();

            await controller.DeleteClient(client);

            this.clientRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllClient()
        {
            Client[] clienti = { new Client { Id = new Guid() }, new Client { Id = new Guid() } };

            this.clientRepositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Client, bool>>>(),
                It.IsAny<Func<IQueryable<Client>, IOrderedQueryable<Client>>>(),
                It.IsAny<string>())).ReturnsAsync(clienti);

            IEnumerable<Client> found = await this.controller.GetAllClient();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            this.clientRepositoryMock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await this.controller.DeleteClientByID(1);

            this.clientRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Client client = new Client()
            {
                Id = new Guid()
            };

            client.FirstName = "Gion";

            this.clientRepositoryMock.Setup(t => t.Update(It.IsAny<Client>())).Verifiable();

            await this.controller.UpdateClient(client);

            this.clientRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetById()
        {
            this.clientRepositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new Client());

            Client client = await this.controller.GetById(Guid.NewGuid());

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void TestAgeFromCNP()
        {
            Client client = new Client
            {
                CodNumericPersonal = "1960914080014"
            };

            DateTime DOB = this.controller.GetClientDOB(client);

            Assert.AreEqual(DOB, new DateTime(1996, 9, 14));
        }
    }
}
