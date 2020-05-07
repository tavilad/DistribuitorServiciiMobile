using DistribuitorServiciiMobile.Models;
using DomainModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDomainModel
{
    [TestClass]
    public class PlataTest
    {
        [TestMethod]
        public void TestIdProperty()
        {
            Plata plata = new Plata();
            Guid id = new Guid();
            plata.Id = id;
            Assert.AreEqual(id, plata.Id);
        }

        [TestMethod]
        public void TestClientProperty()
        {
            Plata plata = new Plata();
            Client client = new Client();
            plata.Client = client;
            Assert.AreEqual(client, plata.Client);
        }

        [TestMethod]
        public void TestContractProperty()
        {
            Plata plata = new Plata();
            Contract contract = new Contract();
            plata.Contract = contract;
            Assert.AreEqual(contract, plata.Contract);
        }

        [TestMethod]
        public void TestTotalDePlataProperty()
        {
            Plata plata = new Plata();
            plata.TotalDePlata = 1000;
            Assert.AreEqual(1000, plata.TotalDePlata);
        }

        [TestMethod]
        public void TestDataPlataProperty()
        {
            Plata plata = new Plata();
            plata.DataPlata = DateTime.Today;
            Assert.AreEqual(DateTime.Today, plata.DataPlata);
        }
    }
}
