using DataMapper.Interfaces;
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
    public class PlataTest
    {
        Mock<IPlataRepository> plataRepositoryMock;
        PlataController controller;
        Mock<IContractRepository> contractRepositoryMock;


        [TestInitialize]
        public void Initialize()
        {
            this.plataRepositoryMock = new Mock<IPlataRepository>();
            this.contractRepositoryMock = new Mock<IContractRepository>();
            this.controller = new PlataController(this.plataRepositoryMock.Object, this.contractRepositoryMock.Object);
        }

        [TestMethod]
        public async Task TestCreatePlata()
        {
            Plata plata = new Plata()
            {
                Id = new Guid()
            };

            this.plataRepositoryMock.Setup(t => t.Insert(It.IsAny<Plata>())).Verifiable();

            await controller.AddPlata(plata);

            this.plataRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeletPlata()
        {
            Plata plata = new Plata()
            {
                Id = new Guid()
            };

            this.plataRepositoryMock.Setup(t => t.Delete(It.IsAny<Plata>())).Verifiable();

            await controller.DeletePlata(plata);

            this.plataRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllPlata()
        {
            Plata[] plata = { new Plata { Id = new Guid() }, new Plata { Id = new Guid() } };

            this.plataRepositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Plata, bool>>>(),
                It.IsAny<Func<IQueryable<Plata>, IOrderedQueryable<Plata>>>(),
                It.IsAny<string>())).ReturnsAsync(plata);

            IEnumerable<Plata> found = await controller.GetAllPlata();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            this.plataRepositoryMock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeletePlataByID(1);

            this.plataRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Plata plata = new Plata()
            {
                Id = new Guid()
            };

            plata.TotalDePlata = new Pret();

            this.plataRepositoryMock.Setup(t => t.Update(It.IsAny<Plata>())).Verifiable();

            await controller.UpdatePlata(plata);

            this.plataRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetById()
        {
            this.plataRepositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new Plata());

            Plata plata = await controller.GetById(Guid.NewGuid());

            Assert.IsNotNull(plata);
        }
    }
}
