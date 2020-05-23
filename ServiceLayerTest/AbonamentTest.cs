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
        public async Task TestGetById()
        {
            Mock<IAbonamentRepository> repositoryMock = new Mock<IAbonamentRepository>();
            AbonamentController abonamentController = new AbonamentController(repositoryMock.Object);

            repositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new Abonament());

            Abonament abonament = await abonamentController.GetById(Guid.NewGuid());

            Assert.IsNotNull(abonament);
        }
    }
}
