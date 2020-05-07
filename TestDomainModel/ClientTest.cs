using DistribuitorServiciiMobile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDomainModel
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestIdProperty()
        {
            Client client = new Client();
            Guid id = new Guid();
            client.Id = id;
            Assert.AreEqual(id, client.Id);
        }

        [TestMethod]
        public void TestFirstNameProperty()
        {
            Client client = new Client();
            client.FirstName = "Popescu";
            Assert.AreEqual("Popescu", client.FirstName);
        }

        [TestMethod]
        public void TestLastNameProperty()
        {
            Client client = new Client();
            client.LastName = "Popescu";
            Assert.AreEqual("Popescu", client.LastName);
        }

        [TestMethod]
        public void TestCnpProperty()
        {
            Client client = new Client();
            client.CodNumericPersonal = "1234566778990";
            Assert.AreEqual("1234566778990", client.CodNumericPersonal);
        }
    }
}
