using DistribuitorServiciiMobile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            abonament.DataInceput = DateTime.Today;
            Assert.AreEqual(DateTime.Today, abonament.DataInceput);
        }

        [TestMethod]
        public void TestDataSfarsitProperty()
        {
            Abonament abonament = new Abonament();
            abonament.DataSfarsit = DateTime.Today;
            Assert.AreEqual(DateTime.Today, abonament.DataSfarsit);
        }

        [TestMethod]
        public void TestIdProperty()
        {
            Guid id = new Guid();
            Abonament abonament = new Abonament();
            abonament.Id = id;
            Assert.AreEqual(id, abonament.Id);
        }
    }
}
