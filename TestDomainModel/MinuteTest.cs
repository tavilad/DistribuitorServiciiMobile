using DistribuitorServiciiMobile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        [TestMethod]
        public void TestTipMinuteNull()
        {
            Minute minute = new Minute();
            ValidationContext context = new ValidationContext(minute, null, null) { MemberName = "TipMinute" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(minute.TipMinute, context); });
        }

        [TestMethod]
        public void TestNumarMinuteNegativ()
        {
            Minute minute = new Minute();
            minute.NumarMinute = -2;
            ValidationContext context = new ValidationContext(minute, null, null) { MemberName = "NumarMinute" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(minute.NumarMinute, context); });
        }

        [TestMethod]
        public void TestTipMinuteScurt()
        {
            Minute minute = new Minute();
            minute.TipMinute = "a";
            ValidationContext context = new ValidationContext(minute, null, null) { MemberName = "TipMinute" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(minute.TipMinute, context); });
        }

        [TestMethod]
        public void TestTipMinuteLung()
        {
            Minute minute = new Minute();
            string nume = Enumerable.Repeat("a", 51).Aggregate((a, b) => a + b);
            minute.TipMinute = nume;
            ValidationContext context = new ValidationContext(minute, null, null) { MemberName = "TipMinute" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(minute.TipMinute, context); });
        }
    }
}
