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
    public class AbonamentTest
    {
        [TestMethod]
        public void TestPretProperty()
        {
            Abonament abonament = new Abonament();
            abonament.Pret = 1000;
            Assert.AreEqual(1000, abonament.Pret);
        }

        [TestMethod]
        public void TestDataInceputProperty()
        {
            Abonament abonament = new Abonament();
            abonament.DataInceput = DateTime.Today.AddDays(1);
            Assert.AreEqual(DateTime.Today.AddDays(1), abonament.DataInceput);
        }

        [TestMethod]
        public void TestDataSfarsitProperty()
        {
            Abonament abonament = new Abonament();
            abonament.DataSfarsit = DateTime.Today.AddDays(1);
            Assert.AreEqual(DateTime.Today.AddDays(1), abonament.DataSfarsit);
        }

        [TestMethod]
        public void TestIdProperty()
        {
            Guid id = new Guid();
            Abonament abonament = new Abonament();
            abonament.Id = id;
            Assert.AreEqual(id, abonament.Id);
        }

        [TestMethod]
        public void TestPretPropertyNegativeFail()
        {
            Abonament abonament = new Abonament();
            abonament.Pret = -2;
            ValidationContext context = new ValidationContext(abonament, null, null) { MemberName = "Pret" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(abonament.Pret, context); });
        }

        [TestMethod]
        public void TestNumeAbonamentNull()
        {
            Abonament abonament = new Abonament();
            ValidationContext context = new ValidationContext(abonament, null, null) { MemberName = "NumeAbonament" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(abonament.NumeAbonament, context); });
        }

        [TestMethod]
        public void TestNumeAbonamentScurt()
        {
            Abonament abonament = new Abonament();
            abonament.NumeAbonament = "A";
            ValidationContext context = new ValidationContext(abonament, null, null) { MemberName = "NumeAbonament" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(abonament.NumeAbonament, context); });
        }

        [TestMethod]
        public void TestNumeAbonamentLung()
        {
            Abonament abonament = new Abonament();
            string nume = Enumerable.Repeat("a", 51).Aggregate((a, b) => a + b);
            abonament.NumeAbonament = nume;
            ValidationContext context = new ValidationContext(abonament, null, null) { MemberName = "NumeAbonament" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(abonament.NumeAbonament, context); });
        }

        [TestMethod]
        public void TestDataSfarsitInTrecut()
        {
            Abonament abonament = new Abonament();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                abonament.DataSfarsit = DateTime.Now.Subtract(TimeSpan.FromDays(1)));
        }

        [TestMethod]
        public void TestDataInceputInTrecut()
        {
            Abonament abonament = new Abonament();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                abonament.DataInceput = DateTime.Now.Subtract(TimeSpan.FromDays(1)));
        }
        
        [TestMethod]
        public void TestDataInceputDupaSfarsit()
        {
            Abonament abonament = new Abonament();
            abonament.DataSfarsit = DateTime.Now.AddDays(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                abonament.DataInceput = DateTime.Now.AddDays(2));
        }

        [TestMethod]
        public void TestExpiratProperty()
        {
            Abonament abonament = new Abonament();
            abonament.Expirat = false;
            Assert.AreEqual(false, abonament.Expirat);
        }
    }
}
