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
    public class ContractTest
    {
        Mock<IClientRepository> clientRepositoryMock;
        ContractController controller;
        Mock<IPlataRepository> plataRepositoryMock;
        Mock<IContractRepository> contractRepository;
        ClientController clientController;

        [TestInitialize]
        public void Initialize()
        {
            this.clientRepositoryMock = new Mock<IClientRepository>();
            this.plataRepositoryMock = new Mock<IPlataRepository>();
            this.contractRepository = new Mock<IContractRepository>();
            this.clientController = new ClientController(this.clientRepositoryMock.Object, this.plataRepositoryMock.Object);
            this.controller = new ContractController(this.contractRepository.Object, this.clientRepositoryMock.Object, this.plataRepositoryMock.Object, this.clientController);
        }

        [TestMethod]
        public async Task TestCreateContract()
        {
            Contract contract = new Contract()
            {
                Id = new Guid(),
                Client = new Client(),
                Abonament = new Abonament()
            };

            contract.Client.CodNumericPersonal = "1960914080014";

            this.plataRepositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Plata, bool>>>(),
                It.IsAny<Func<IQueryable<Plata>, IOrderedQueryable<Plata>>>(),
                It.IsAny<string>())).ReturnsAsync(new List<Plata>());

            //this.clientControllerMock.Setup(t => t.CheckClientPaymentsOnTime(It.IsAny<Client>())).ReturnsAsync(true);

            this.contractRepository.Setup(t => t.Insert(It.IsAny<Contract>())).Verifiable();

            await controller.AddContract(contract);

            this.contractRepository.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteContractObject()
        {
            Contract contract = new Contract()
            {
                Id = new Guid()
            };

            this.contractRepository.Setup(t => t.Delete(It.IsAny<Contract>())).Verifiable();

            await controller.DeleteContract(contract);

            this.contractRepository.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllContract()
        {
            Contract[] contracte = { new Contract { Id = new Guid() }, new Contract { Id = new Guid() } };

            this.contractRepository.Setup(t => t.Get(
                It.IsAny<Expression<Func<Contract, bool>>>(),
                It.IsAny<Func<IQueryable<Contract>, IOrderedQueryable<Contract>>>(),
                It.IsAny<string>())).ReturnsAsync(contracte);

            IEnumerable<Contract> found = await controller.GetAllContract();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            this.contractRepository.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeleteContractByID(1);

            this.contractRepository.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Contract contract = new Contract()
            {
                Id = new Guid()
            };

            contract.Id = new Guid();

            this.contractRepository.Setup(t => t.Update(It.IsAny<Contract>())).Verifiable();

            await controller.UpdateContract(contract);

            this.contractRepository.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetById()
        {
            this.contractRepository.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new Contract());

            Contract contract = await controller.GetById(Guid.NewGuid());

            Assert.IsNotNull(contract);
        }
    }
}
