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
    public class PretTest
    {
        [TestMethod]
        public void TestIdProperty()
        {
            Pret Pret = new Pret();
            Guid id = new Guid();
            Pret.Id = id;
            Assert.AreEqual(id, Pret.Id);
        }

        [TestMethod]
        public void TestValutaProperty()
        {
            Pret Pret = new Pret();
            Pret.Valuta = "RON";
            Assert.AreEqual("RON", Pret.Valuta);
        }

        [TestMethod]
        public void TestSumaProperty()
        {
            Pret Pret = new Pret();
            Pret.Suma = 1000;
            Assert.AreEqual(1000, Pret.Suma);
        }

        [TestMethod]
        public void TestTipPretNull()
        {
            Pret Pret = new Pret();
            ValidationContext context = new ValidationContext(Pret, null, null) { MemberName = "Valuta" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(Pret.Valuta, context); });
        }

        [TestMethod]
        public void TestNumarPretNegativ()
        {
            Pret Pret = new Pret();
            Pret.Suma = -2;
            ValidationContext context = new ValidationContext(Pret, null, null) { MemberName = "Suma" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(Pret.Suma, context); });
        }

        [TestMethod]
        public void TestTipPretScurt()
        {
            Pret Pret = new Pret();
            Pret.Valuta = "a";
            ValidationContext context = new ValidationContext(Pret, null, null) { MemberName = "Valuta" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(Pret.Valuta, context); });
        }

        [TestMethod]
        public void TestTipPretLung()
        {
            Pret Pret = new Pret();
            string nume = Enumerable.Repeat("a", 51).Aggregate((a, b) => a + b);
            Pret.Valuta = nume;
            ValidationContext context = new ValidationContext(Pret, null, null) { MemberName = "Valuta" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(Pret.Valuta, context); });
        }
    }
}
