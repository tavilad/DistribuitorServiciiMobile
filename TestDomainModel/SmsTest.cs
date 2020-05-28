using DistribuitorServiciiMobile.Models;
using DomainModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        [TestMethod]
        public void TestTipSmsNull()
        {
            SMS sms = new SMS();
            ValidationContext context = new ValidationContext(sms, null, null) { MemberName = "TipSms" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(sms.TipSms, context); });
        }

        [TestMethod]
        public void TestNumarSmsNegativ()
        {
            SMS sms = new SMS();
            sms.NumarSms = -2;
            ValidationContext context = new ValidationContext(sms, null, null) { MemberName = "NumarSms" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(sms.NumarSms, context); });
        }

        [TestMethod]
        public void TestTipSmsScurt()
        {
            SMS sms = new SMS();
            sms.TipSms = "a";
            ValidationContext context = new ValidationContext(sms, null, null) { MemberName = "TipSms" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(sms.TipSms, context); });
        }

        [TestMethod]
        public void TestTipSmsLung()
        {
            SMS sms = new SMS();
            string nume = Enumerable.Repeat("a", 51).Aggregate((a, b) => a + b);
            sms.TipSms = nume;
            ValidationContext context = new ValidationContext(sms, null, null) { MemberName = "TipSms" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(sms.TipSms, context); });
        }

        [TestMethod]
        public void TestSmsConsumateProperty()
        {
            SMS sms = new SMS();
            sms.SmsConsumate = 1000;
            Assert.AreEqual(1000, sms.SmsConsumate);
        }

        [TestMethod]
        public void TestSmsConsumateNegativ()
        {
            SMS sms = new SMS();
            sms.SmsConsumate = -2;
            ValidationContext context = new ValidationContext(sms, null, null) { MemberName = "SmsConsumate" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(sms.SmsConsumate, context); });
        }

        [TestMethod]
        public void TestPretProperty()
        {
            SMS sms = new SMS();
            Pret pret = new Pret();
            sms.PretSms = pret;
            Assert.AreEqual(pret, sms.PretSms);
        }
    }
}
