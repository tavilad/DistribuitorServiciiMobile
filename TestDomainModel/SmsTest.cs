using DistribuitorServiciiMobile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDomainModel
{
    [TestClass]
    public class SmsTest
    {
        [TestMethod]
        public void TestIdProperty()
        {
            SMS sms = new SMS();
            Guid id = new Guid();
            sms.Id = id;
            Assert.AreEqual(id, sms.Id);
        }

        [TestMethod]
        public void TestTipSmsProperty()
        {
            SMS sms = new SMS();
            sms.TipSms = "International";
            Assert.AreEqual("International", sms.TipSms);
        }

        [TestMethod]
        public void TestNumarSmsProperty()
        {
            SMS sms = new SMS();
            sms.NumarSms = 1000;
            Assert.AreEqual(1000, sms.NumarSms);
        }
    }
}
