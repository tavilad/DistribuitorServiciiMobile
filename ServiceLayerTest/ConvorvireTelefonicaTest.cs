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
        Mock<IConvorbireTelefonicaRepository> mock;
        ConvorbireTelefonicaController controller;
        Mock<IAbonamentRepository> abonamentRepository;

        [TestInitialize]
        public void Initialize()
        {
            this.mock = new Mock<IConvorbireTelefonicaRepository>();
            this.abonamentRepository = new Mock<IAbonamentRepository>();
            this.controller = new ConvorbireTelefonicaController(this.mock.Object, this.abonamentRepository.Object);
        }

        [TestMethod]
        public async Task TestCreateConvorbire()
        {
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
        public async Task TestCreateConvorbireNull()
        {
            ConvorbireTelefonica convorbire = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.AddConvorbire(convorbire));

            Assert.AreEqual(exception.ParamName, nameof(convorbire));
        }

        [TestMethod]
        public async Task TestDeleteConvorbire()
        {
            ConvorbireTelefonica convorbire = new ConvorbireTelefonica()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Delete(It.IsAny<ConvorbireTelefonica>())).Verifiable();

            await controller.DeleteConvorbire(convorbire);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteConvorbireNull()
        {
            ConvorbireTelefonica convorbire = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.DeleteConvorbire(convorbire));

            Assert.AreEqual(exception.ParamName, nameof(convorbire));
        }

        [TestMethod]
        public async Task TestGetAllConvorbire()
        {
            ConvorbireTelefonica[] convorbiri = { new ConvorbireTelefonica { Id = new Guid() }, new ConvorbireTelefonica { Id = new Guid() } };

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
            mock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeleteConvorbireByID(1);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
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
        public async Task TestUpdateConvorbireNull()
        {
            ConvorbireTelefonica convorbire = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.UpdateConvorbire(convorbire));

            Assert.AreEqual(exception.ParamName, nameof(convorbire));
        }

        [TestMethod]
        public async Task TestGetById()
        {
            mock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new ConvorbireTelefonica());

            ConvorbireTelefonica convorbire = await controller.GetById(Guid.NewGuid());

            Assert.IsNotNull(convorbire);
        }

        [TestMethod]
        public async Task TestExecutaApel()
        {
            Client initiator = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014",
            };

            Minute[] minute = {
                new Minute()
                {
                    TipMinute = "Retea",
                    NumarMinute = 100,
                    MinuteConsumate = 0
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentMinute = minute
            };

            Contract[] contracte = { 
                new Contract()
                {
                    Client = initiator,
                    Valabil = true,
                    Abonament = abonament
                }
            };

            ConvorbireTelefonica convorbire = new ConvorbireTelefonica()
            {
                Id = new Guid(),
                Initiator = initiator,
                Receptor = new Client(),
                DurataConvorbire = 10,
                TipConvorbire = "Retea"
            };

            initiator.Contracte = contracte;

            Abonament result = await this.controller.ExecutaApel(convorbire, contracte[0]);

            Assert.AreEqual(10, result.AbonamentMinute.FirstOrDefault().MinuteConsumate);
        }
    }
}
