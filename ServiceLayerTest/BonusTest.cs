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
    public class BonusTest
    {
        Mock<IBonusRepository> repositoryMock;
        BonusController controller;
        ClientController clientController;
        Mock<IPlataRepository> plataRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            this.repositoryMock = new Mock<IBonusRepository>();
            this.plataRepositoryMock = new Mock<IPlataRepository>();
            this.clientController = new ClientController(new Mock<IClientRepository>().Object, this.plataRepositoryMock.Object,
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
        public async Task TestCreateBonusNull()
        {
            Bonus bonus = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.AddBonus(bonus));

            Assert.AreEqual(exception.ParamName, nameof(bonus));
        }

        [TestMethod]
        public async Task TestCreateBonusRauPlatnic()
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

            Bonus bonus = new Bonus()
            {
                MinuteBonus = 100,
                SmsBonus = 20,
                DateBonus = 10,
                Contract = contract,
                TipBonus = "National"
            };

            Plata[] plati = {
                new Plata()
                {
                    Client = client,
                    Contract = contract,
                    DataScadenta = DateTime.Today,
                    DataPlata = DateTime.Today.AddDays(1)
                }
            };

            this.plataRepositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Plata, bool>>>(),
                It.IsAny<Func<IQueryable<Plata>, IOrderedQueryable<Plata>>>(),
                It.IsAny<string>())).ReturnsAsync(plati);

            ArgumentException exception = await Assert.ThrowsExceptionAsync<ArgumentException>(() => controller.AddBonus(bonus));

            Assert.AreEqual(exception.Message, "Clientul nu este bun platnic");
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

        [TestMethod]
        public async Task TestUpdateBonusNull()
        {
            Bonus bonus = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.UpdateBonus(bonus));

            Assert.AreEqual(exception.ParamName, nameof(bonus));
        }

        [TestMethod]
        public async Task TestDeleteBonusNull()
        {
            Bonus bonus = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.DeleteBonus(bonus));

            Assert.AreEqual(exception.ParamName, nameof(bonus));
        }
    }
}
