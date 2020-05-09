using DistribuitorServiciiMobile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [TestMethod]
        public void TestMinuteBonusNegativ()
        {
            Bonus bonus = new Bonus();
            bonus.MinuteBonus = -2;
            ValidationContext context = new ValidationContext(bonus, null, null) { MemberName = "MinuteBonus" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(bonus.MinuteBonus, context); });
        }

        [TestMethod]
        public void TestSmsBonusNegativ()
        {
            Bonus bonus = new Bonus();
            bonus.SmsBonus = -2;
            ValidationContext context = new ValidationContext(bonus, null, null) { MemberName = "SmsBonus" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(bonus.SmsBonus, context); });
        }

        [TestMethod]
        public void TestDateBonusNegativ()
        {
            Bonus bonus = new Bonus();
            bonus.DateBonus = -2;
            ValidationContext context = new ValidationContext(bonus, null, null) { MemberName = "DateBonus" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(bonus.DateBonus, context); });
        }
    }
}
