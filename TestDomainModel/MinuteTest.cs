using DistribuitorServiciiMobile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDomainModel
{
    [TestClass]
    public class MinuteTest
    {
        [TestMethod]
        public void TestIdProperty()
        {
            Minute minute = new Minute();
            Guid id = new Guid();
            minute.Id = id;
            Assert.AreEqual(id, minute.Id);
        }

        [TestMethod]
        public void TestTipMinuteProperty()
        {
            Minute minute = new Minute();
            minute.TipMinute = "Nationale";
            Assert.AreEqual("Nationale", minute.TipMinute);
        }

        [TestMethod]
        public void TestNumarMinuteProperty()
        {
            Minute minute = new Minute();
            minute.NumarMinute = 100;
            Assert.AreEqual(100, minute.NumarMinute);
        }
    }
}
