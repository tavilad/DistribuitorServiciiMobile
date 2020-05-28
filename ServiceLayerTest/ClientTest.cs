using DataMapper;
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
        public async Task TestCreateClientNull()
        {
            Client client = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.AddClient(client));

            Assert.AreEqual(exception.ParamName, nameof(client));
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
        public async Task TestDeleteClientNull()
        {
            Client client = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.DeleteClient(client));

            Assert.AreEqual(exception.ParamName, nameof(client));
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
        public async Task TestUpdateClientNull()
        {
            Client client = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.UpdateClient(client));

            Assert.AreEqual(exception.ParamName, nameof(client));
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

        [TestMethod]
        public void TestAgeFromCNP2()
        {
            Client client = new Client
            {
                CodNumericPersonal = "5060914080014"
            };

            DateTime DOB = this.controller.GetClientDOB(client);

            Assert.AreEqual(DOB, new DateTime(2006, 9, 14));
        }

        [TestMethod]
        public async Task TestClientPaymentsOnTime()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi"
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament
            };

            Pret totalDePlata = new Pret()
            {
                Suma = 100,
                Valuta = "RON"
            };

            Pret sumaPlatita = new Pret()
            {
                Suma = 100,
                Valuta = "RON"
            };

            Plata[] plati = {
                new Plata()
                {
                    Client = client,
                    Contract = contract,
                    DataScadenta = DateTime.Today,
                    DataPlata = new DateTime(2019,1,1),
                    TotalDePlata = totalDePlata,
                    SumaPlatita = sumaPlatita
                }
            };

            this.plataRepositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Plata, bool>>>(),
                It.IsAny<Func<IQueryable<Plata>, IOrderedQueryable<Plata>>>(),
                It.IsAny<string>())).ReturnsAsync(plati);

            bool check = await controller.CheckClientPaymentsOnTime(client);

            Assert.AreEqual(true, check);
        }
    }
}
