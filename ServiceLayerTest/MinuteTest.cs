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
    public class MinuteTest
    {
        [TestMethod]
        public async Task TestCreateMinute()
        {
            Mock<IMinuteRepository> mock = new Mock<IMinuteRepository>();
            MinuteController controller = new MinuteController(mock.Object);

            Minute minute = new Minute()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Insert(It.IsAny<Minute>())).Verifiable();

            await controller.AddMinute(minute);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteMinute()
        {
            Mock<IMinuteRepository> mock = new Mock<IMinuteRepository>();
            MinuteController controller = new MinuteController(mock.Object);

            Minute minute = new Minute()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Delete(It.IsAny<Minute>())).Verifiable();

            await controller.DeleteMinute(minute);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllMinute()
        {
            Minute[] minute = { new Minute { Id = new Guid() }, new Minute { Id = new Guid() } };

            Mock<IMinuteRepository> mock = new Mock<IMinuteRepository>();
            MinuteController controller = new MinuteController(mock.Object);

            mock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Minute, bool>>>(),
                It.IsAny<Func<IQueryable<Minute>, IOrderedQueryable<Minute>>>(),
                It.IsAny<string>())).ReturnsAsync(minute);

            IEnumerable<Minute> found = await controller.GetAllMinute();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            Mock<IMinuteRepository> mock = new Mock<IMinuteRepository>();
            MinuteController controller = new MinuteController(mock.Object);

            mock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeleteMinuteByID(1);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Mock<IMinuteRepository> mock = new Mock<IMinuteRepository>();
            MinuteController controller = new MinuteController(mock.Object);

            Minute minute = new Minute()
            {
                Id = new Guid()
            };

            minute.NumarMinute = 100;

            mock.Setup(t => t.Update(It.IsAny<Minute>())).Verifiable();

            await controller.UpdateMinute(minute);

            mock.VerifyAll();
        }
    }
}
