using DistribuitorServiciiMobile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDomainModel
{
    [TestClass]
    public class ContractTest
    {
        [TestMethod]
        public void TestIdProperty()
        {
            Contract contract = new Contract();
            Guid id = new Guid();
            contract.Id = id;
            Assert.AreEqual(id, contract.Id);
        }

        [TestMethod]
        public void TestValabilProperty()
        {
            Contract contract = new Contract();
            contract.Valabil = true;
            Assert.AreEqual(true, contract.Valabil);
        }
    }
}
