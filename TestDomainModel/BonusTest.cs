using DistribuitorServiciiMobile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDomainModel
{   
    [TestClass]
    public class BonusTest
    {
        [TestMethod]
        public void TestIdProperty()
        {
            Bonus bonus = new Bonus();
            Guid id = new Guid();
            bonus.Id = id;
            Assert.AreEqual(id, bonus.Id);
        }

        [TestMethod]
        public void TestMinuteBonusProperty()
        {
            Bonus bonus = new Bonus();
            bonus.MinuteBonus = 5;
            Assert.AreEqual(5, bonus.MinuteBonus);
        }

        [TestMethod]
        public void TestSmsBonusProperty()
        {
            Bonus bonus = new Bonus();
            bonus.SmsBonus = 5;
            Assert.AreEqual(5, bonus.SmsBonus);
        }

        [TestMethod]
        public void TestDateBonusProperty()
        {
            Bonus bonus = new Bonus();
            bonus.DateBonus = 5;
            Assert.AreEqual(5, bonus.DateBonus);
        }
    }
}
