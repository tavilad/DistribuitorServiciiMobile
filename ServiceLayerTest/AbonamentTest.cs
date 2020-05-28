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
    public class AbonamentTest
    {

        [TestMethod]
        public async Task TestCreateAbonament()
        {
            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi"
            };

            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            repositoryMock.Setup(t => t.Insert(It.IsAny<Abonament>())).Verifiable();

            await abonamentController.AddAbonament(abonament);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestCreateAbonamentNull()
        {
            Abonament abonament = null;

            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => abonamentController.AddAbonament(abonament));

            Assert.AreEqual(exception.ParamName, nameof(abonament));
        }

        [TestMethod]
        public async Task TestDeleteAbonamentObject()
        {
            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi"
            };

            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            repositoryMock.Setup(t => t.Delete(It.IsAny<Abonament>())).Verifiable();

            await abonamentController.DeleteAbonament(abonament);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteAbonamentNull()
        {
            Abonament abonament = null;

            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => abonamentController.DeleteAbonament(abonament));

            Assert.AreEqual(exception.ParamName, nameof(abonament));
        }

        [TestMethod]
        public async Task TestGetAllAbonament()
        {
            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            Abonament[] abonamente = {
                new Abonament { Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi" },
                new Abonament { Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi" }};

            repositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Abonament, bool>>>(),
                It.IsAny<Func<IQueryable<Abonament>, IOrderedQueryable<Abonament>>>(),
                It.IsAny<string>())).ReturnsAsync(abonamente);
            IEnumerable<Abonament> found = await abonamentController.GetAllAbonament();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            repositoryMock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await abonamentController.DeleteAbonamentByID(1);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi"
            };

            abonament.DataInceput = DateTime.Now.AddDays(2);

            repositoryMock.Setup(t => t.Update(It.IsAny<Abonament>())).Verifiable();

            await abonamentController.UpdateAbonament(abonament);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdateAbonamentNull()
        {
            Abonament abonament = null;

            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => abonamentController.UpdateAbonament(abonament));

            Assert.AreEqual(exception.ParamName, nameof(abonament));

        }

        [TestMethod]
        public async Task TestGetById()
        {
            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            repositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new Abonament());

            Abonament abonament = await abonamentController.GetById(Guid.NewGuid());

            Assert.IsNotNull(abonament);
        }

        [TestMethod]
        public async Task TestPrelungireAbonament()
        {
            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi"
            };

            DateTime dataExpirate = new DateTime(2020, 10, 14);

            repositoryMock.Setup(t => t.Update(It.IsAny<Abonament>())).Verifiable();

            await abonamentController.PrelungireAbonament(abonament, dataExpirate);

            repositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestPrelungireAbonamentNull()
        {
            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            Abonament abonament = null;

            DateTime dataExpirate = new DateTime(2020, 10, 14);

            ArgumentException exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                () => abonamentController.PrelungireAbonament(abonament, dataExpirate));

            Assert.AreEqual(exception.Message, "Contractul este null");
        }

        [TestMethod]
        public async Task TestScurtareAbonament()
        {
            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi"
            };

            DateTime dataExpirate = new DateTime(2019, 10, 14);

            ArgumentException exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
                () => abonamentController.PrelungireAbonament(abonament, dataExpirate));

            Assert.AreEqual(exception.Message, "Abonamentul nu se poate scurta");
        }
    }
}
