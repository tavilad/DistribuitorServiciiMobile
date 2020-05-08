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
    public class DateMobileTest
    {
        [TestMethod]
        public async Task TestCreateDateMobile()
        {
            Mock<IDateRepository> mock = new Mock<IDateRepository>();
            DateMobileController controller = new DateMobileController(mock.Object);

            DateMobile date = new DateMobile()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Insert(It.IsAny<DateMobile>())).Verifiable();

            await controller.AddDate(date);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteDateMobile()
        {
            Mock<IDateRepository> mock = new Mock<IDateRepository>();
            DateMobileController controller = new DateMobileController(mock.Object);

            DateMobile date = new DateMobile()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Delete(It.IsAny<DateMobile>())).Verifiable();

            await controller.DeleteDate(date);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllDate()
        {
            DateMobile[] date = { new DateMobile { Id = new Guid() }, new DateMobile { Id = new Guid() } };

            Mock<IDateRepository> mock = new Mock<IDateRepository>();
            DateMobileController controller = new DateMobileController(mock.Object); ;

            mock.Setup(t => t.Get(
                It.IsAny<Expression<Func<DateMobile, bool>>>(),
                It.IsAny<Func<IQueryable<DateMobile>, IOrderedQueryable<DateMobile>>>(),
                It.IsAny<string>())).ReturnsAsync(date);

            IEnumerable<DateMobile> found = await controller.GetAllDate();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            Mock<IDateRepository> mock = new Mock<IDateRepository>();
            DateMobileController controller = new DateMobileController(mock.Object);

            mock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeleteDateByID(1);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Mock<IDateRepository> mock = new Mock<IDateRepository>();
            DateMobileController controller = new DateMobileController(mock.Object);

            DateMobile date = new DateMobile()
            {
                Id = new Guid()
            };

            date.NumarDate = 100;

            mock.Setup(t => t.Update(It.IsAny<DateMobile>())).Verifiable();

            await controller.UpdateDate(date);

            mock.VerifyAll();
        }
    }
}
