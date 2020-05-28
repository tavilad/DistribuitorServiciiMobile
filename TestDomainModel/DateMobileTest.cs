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

        [TestMethod]
        public void TestTipDateNull()
        {
            DateMobile date = new DateMobile();
            ValidationContext context = new ValidationContext(date, null, null) { MemberName = "TipDate" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(date.TipDate, context); });
        }

        [TestMethod]
        public void TestNumarDateNegativ()
        {
            DateMobile date = new DateMobile();
            date.NumarDate = -2;
            ValidationContext context = new ValidationContext(date, null, null) { MemberName = "NumarDate" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(date.NumarDate, context); });
        }

        [TestMethod]
        public void TestTipDateScurt()
        {
            DateMobile date = new DateMobile();
            date.TipDate = "A";
            ValidationContext context = new ValidationContext(date, null, null) { MemberName = "TipDate" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(date.TipDate, context); });
        }

        [TestMethod]
        public void TestTipDateLung()
        {
            DateMobile date = new DateMobile();
            string nume = Enumerable.Repeat("a", 51).Aggregate((a, b) => a + b);
            date.TipDate = nume;
            ValidationContext context = new ValidationContext(date, null, null) { MemberName = "TipDate" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(date.TipDate, context); });
        }

        [TestMethod]
        public void TestDateConsumateProperty()
        {
            DateMobile date = new DateMobile();
            date.DateConsumate = 100;
            Assert.AreEqual(100, date.DateConsumate);
        }

        [TestMethod]
        public void TestDateConsumateNegativ()
        {
            DateMobile date = new DateMobile();
            date.DateConsumate = -2;
            ValidationContext context = new ValidationContext(date, null, null) { MemberName = "DateConsumate" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(date.DateConsumate, context); });
        }

        [TestMethod]
        public void TestPretProperty()
        {
            DateMobile date = new DateMobile();
            Pret pret = new Pret();
            date.PretData = pret;
            Assert.AreEqual(pret, date.PretData);
        }
    }
}
