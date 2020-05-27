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
    public class BonusTest
    {
        Mock<IBonusRepository> repositoryMock;
        BonusController controller;
        ClientController clientController;

        [TestInitialize]
        public void Initialize()
        {
            this.repositoryMock = new Mock<IBonusRepository>();
            this.clientController = new ClientController(new Mock<IClientRepository>().Object, new Mock<IPlataRepository>().Object,
                new Mock<IConvorbireTelefonicaRepository>().Object, new Mock<IAbonamentRepository>().Object);
            this.controller = new BonusController(repositoryMock.Object, this.clientController);
        }

        [TestMethod]
        public async Task TestCreateBonus()
        {
            Bonus bonus = new Bonus()
            {
                MinuteBonus = 100,
                SmsBonus = 20,
                DateBonus = 10,
                Contract = new Contract(),
                TipBonus = "National"
            };

            repositoryMock.Setup(t => t.Insert(It.IsAny<Bonus>())).Verifiable();

            await controller.AddBonus(bonus);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteBonusObject()
        {
            Bonus bonus = new Bonus()
            {
                MinuteBonus = 100,
                SmsBonus = 20,
                DateBonus = 10
            };

            repositoryMock.Setup(t => t.Delete(It.IsAny<Bonus>())).Verifiable();

            await controller.DeleteBonus(bonus);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllBonus()
        {
            Bonus[] bonusuri = { new Bonus { Id = new Guid() }, new Bonus { Id = new Guid() } };

            repositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Bonus, bool>>>(),
                It.IsAny<Func<IQueryable<Bonus>, IOrderedQueryable<Bonus>>>(),
                It.IsAny<string>())).ReturnsAsync(bonusuri);

            IEnumerable<Bonus> found = await controller.GetAllBonus();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            repositoryMock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeleteBonusByID(1);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Bonus bonus = new Bonus()
            {
                Id = new Guid()
            };

            bonus.MinuteBonus = 1000;

            repositoryMock.Setup(t => t.Update(It.IsAny<Bonus>())).Verifiable();

            await controller.UpdateBonus(bonus);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetById()
        {
            repositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new Bonus());

            Bonus bonus = await controller.GetById(Guid.NewGuid());

            Assert.IsNotNull(bonus);
        }
    }
}
