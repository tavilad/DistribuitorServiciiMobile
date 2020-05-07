using DistribuitorServiciiMobile.Models;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDomainModel
{
    [TestClass]
    public class ConvorbireTelefonicaTest
    {
        [TestMethod]
        public void TestIdProperty()
        {
            ConvorbireTelefonica convorbire = new ConvorbireTelefonica();
            Guid id = new Guid();
            convorbire.Id = id;
            Assert.AreEqual(id, convorbire.Id);
        }

        [TestMethod]
        public void TestInitiatorProperty()
        {
            ConvorbireTelefonica convorbire = new ConvorbireTelefonica();
            Client client = new Client();
            convorbire.Initiator = client;
            Assert.AreEqual(client, convorbire.Initiator);
        }

        [TestMethod]
        public void TestReceptorProperty()
        {
            ConvorbireTelefonica convorbire = new ConvorbireTelefonica();
            Client client = new Client();
            convorbire.Receptor = client;
            Assert.AreEqual(client, convorbire.Receptor);
        }

        [TestMethod]
        public void TestDurataConvorbireProperty()
        {
            ConvorbireTelefonica convorbire = new ConvorbireTelefonica();
            convorbire.DurataConvorbire = 10;
            Assert.AreEqual(10, convorbire.DurataConvorbire);
        }

        [TestMethod]
        public void TestDataApelProperty()
        {
            ConvorbireTelefonica convorbire = new ConvorbireTelefonica();
            convorbire.DataApel = DateTime.Today;
            Assert.AreEqual(DateTime.Today, convorbire.DataApel);
        }
    }
}
