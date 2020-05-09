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
            client.CodNumericPersonal = "1234567890123";
            Assert.AreEqual("1234567890123", client.CodNumericPersonal);
        }

        [TestMethod]
        public void TestFirstNamePropertyScurt()
        {
            Client client = new Client();
            client.FirstName = "A";
            ValidationContext context = new ValidationContext(client, null, null) { MemberName = "FirstName" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(client.FirstName, context); });
        }

        [TestMethod]
        public void TestLastNamePropertyScurt()
        {
            Client client = new Client();
            client.LastName = "A";
            ValidationContext context = new ValidationContext(client, null, null) { MemberName = "LastName" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(client.LastName, context); });
        }

        [TestMethod]
        public void TestLastNamePropertyNull()
        {
            Client client = new Client();
            ValidationContext context = new ValidationContext(client, null, null) { MemberName = "LastName" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(client.LastName, context); });
        }

        [TestMethod]
        public void TestFirstNamePropertyNull()
        {
            Client client = new Client();
            ValidationContext context = new ValidationContext(client, null, null) { MemberName = "FirstName" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(client.FirstName, context); });
        }

        [TestMethod]
        public void TestLastNamePropertyLong()
        {
            Client client = new Client();
            string name = Enumerable.Repeat("a", 51).Aggregate((a, b) => a + b);
            client.LastName = name;

            ValidationContext context = new ValidationContext(client, null, null) { MemberName = "LastName" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(client.LastName, context); });
        }

        [TestMethod]
        public void TestFirstNamePropertyLong()
        {
            Client client = new Client();
            string name = Enumerable.Repeat("a", 51).Aggregate((a, b) => a + b);
            client.FirstName = name;

            ValidationContext context = new ValidationContext(client, null, null) { MemberName = "FirstName" };

            Assert.ThrowsException<ValidationException>(() => { Validator.ValidateProperty(client.FirstName, context); });
        }

        [TestMethod]
        public void TestCnpInvalid()
        {
            Client client = new Client();
            
            ValidationContext context = new ValidationContext(client, null, null) { MemberName = "CodNumericPersonal" };

            Assert.ThrowsException<ArgumentException>(() => { client.CodNumericPersonal = "abcdefghijklm"; });
        }
    }
}
