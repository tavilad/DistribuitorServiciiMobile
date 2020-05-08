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
    public class SmsTest
    {
        [TestMethod]
        public async Task TestCreateSms()
        {
            Mock<ISmsRepository> mock = new Mock<ISmsRepository>();
            SmsController controller = new SmsController(mock.Object);

            SMS sms = new SMS()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Insert(It.IsAny<SMS>())).Verifiable();

            await controller.AddSms(sms);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteSms()
        {
            Mock<ISmsRepository> mock = new Mock<ISmsRepository>();
            SmsController controller = new SmsController(mock.Object);

            SMS sms = new SMS()
            {
                Id = new Guid()
            };

            mock.Setup(t => t.Delete(It.IsAny<SMS>())).Verifiable();

            await controller.DeleteSms(sms);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllSms()
        {
            SMS[] sms = { new SMS { Id = new Guid() }, new SMS { Id = new Guid() } };

            Mock<ISmsRepository> mock = new Mock<ISmsRepository>();
            SmsController controller = new SmsController(mock.Object);

            mock.Setup(t => t.Get(
                It.IsAny<Expression<Func<SMS, bool>>>(),
                It.IsAny<Func<IQueryable<SMS>, IOrderedQueryable<SMS>>>(),
                It.IsAny<string>())).ReturnsAsync(sms);

            IEnumerable<SMS> found = await controller.GetAllSms();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            Mock<ISmsRepository> mock = new Mock<ISmsRepository>();
            SmsController controller = new SmsController(mock.Object);

            mock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeleteSMSByID(1);

            mock.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Mock<ISmsRepository> mock = new Mock<ISmsRepository>();
            SmsController controller = new SmsController(mock.Object);

            SMS sms = new SMS()
            {
                Id = new Guid()
            };

            sms.NumarSms = 100;

            mock.Setup(t => t.Update(It.IsAny<SMS>())).Verifiable();

            await controller.UpdateSms(sms);

            mock.VerifyAll();
        }
    }
}
