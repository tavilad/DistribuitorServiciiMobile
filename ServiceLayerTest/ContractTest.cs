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
    public class ContractTest
    {
        [TestMethod]
        public async Task TestCreateContract()
        {
            Mock<IContractRepository> mock = new Mock<IContractRepository>();
            ContractController controller = new ContractController(mock.Object);

            Contract contract = new Contract()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Insert(It.IsAny<Contract>())).Verifiable();

            await controller.AddContract(contract);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteContractObject()
        {
            Mock<IContractRepository> mock = new Mock<IContractRepository>();
            ContractController controller = new ContractController(mock.Object);

            Contract contract = new Contract()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Delete(It.IsAny<Contract>())).Verifiable();

            await controller.DeleteContract(contract);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllContract()
        {
            Mock<IContractRepository> mock = new Mock<IContractRepository>();
            ContractController controller = new ContractController(mock.Object);

            Contract[] contracte = { new Contract { Id = new Guid() }, new Contract { Id = new Guid() } };

            mock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Contract, bool>>>(),
                It.IsAny<Func<IQueryable<Contract>, IOrderedQueryable<Contract>>>(),
                It.IsAny<string>())).ReturnsAsync(contracte);

            IEnumerable<Contract> found = await controller.GetAllContract();

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
            Mock<IContractRepository> mock = new Mock<IContractRepository>();
            ContractController controller = new ContractController(mock.Object);

            Contract contract = new Contract()
            {
                Id = new Guid()
            };

            contract.Id = new Guid();

            mock.Setup(t => t.Update(It.IsAny<Contract>())).Verifiable();

            await controller.UpdateContract(contract);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetById()
        {
            Mock<IContractRepository> mock = new Mock<IContractRepository>();
            ContractController controller = new ContractController(mock.Object);

            mock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new Contract());

            Contract contract = await controller.GetById(Guid.NewGuid());

            Assert.IsNotNull(contract);
        }
    }
}
