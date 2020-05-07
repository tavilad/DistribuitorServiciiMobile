using DistribuitorServiciiMobile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDomainModel
{
    [TestClass]
    public class DateMobileTest
    {
        [TestMethod]
        public void TestIdProperty()
        {
            DateMobile date = new DateMobile();
            Guid id = new Guid();
            date.Id = id;
            Assert.AreEqual(id, date.Id);
        }

        [TestMethod]
        public void TestTipDateProperty()
        {
            DateMobile date = new DateMobile();
            date.TipDate = "Nationale";
            Assert.AreEqual("Nationale", date.TipDate);
        }

        [TestMethod]
        public void TestNumarDateProperty()
        {
            DateMobile date = new DateMobile();
            date.NumarDate = 100;
            Assert.AreEqual(100, date.NumarDate);
        }
    }
}
