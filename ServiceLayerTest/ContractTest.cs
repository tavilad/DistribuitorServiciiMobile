using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using DomainModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTest
{
    [TestClass]
    public class ContractTest
    {
        Mock<IClientRepository> clientRepositoryMock;
        ContractController controller;
        Mock<IPlataRepository> plataRepositoryMock;
        Mock<IContractRepository> contractRepository;
        ClientController clientController;
        Mock<IAbonamentRepository> abonamentRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            this.clientRepositoryMock = new Mock<IClientRepository>();
            this.plataRepositoryMock = new Mock<IPlataRepository>();
            this.contractRepository = new Mock<IContractRepository>();
            this.abonamentRepositoryMock = new Mock<IAbonamentRepository>();
            this.clientController = new ClientController(this.clientRepositoryMock.Object, this.plataRepositoryMock.Object,
                new Mock<IConvorbireTelefonicaRepository>().Object, new Mock<IAbonamentRepository>().Object);
            this.controller = new ContractController(this.contractRepository.Object, this.clientController, this.plataRepositoryMock.Object, this.abonamentRepositoryMock.Object);
        }

        [TestMethod]
        public async Task TestCreateContract()
        {
            Contract contract = new Contract()
            {
                Id = new Guid(),
                Client = new Client(),
                Abonament = new Abonament()
            };

            contract.Client.CodNumericPersonal = "1960914080014";

            this.plataRepositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Plata, bool>>>(),
                It.IsAny<Func<IQueryable<Plata>, IOrderedQueryable<Plata>>>(),
                It.IsAny<string>())).ReturnsAsync(new List<Plata>());

            //this.clientControllerMock.Setup(t => t.CheckClientPaymentsOnTime(It.IsAny<Client>())).ReturnsAsync(true);

            this.contractRepository.Setup(t => t.Insert(It.IsAny<Contract>())).Verifiable();

            await controller.AddContract(contract);

            this.contractRepository.VerifyAll();
        }

        [TestMethod]
        public async Task TestCreateContractNull()
        {
            Contract contract = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.AddContract(contract));

            Assert.AreEqual(exception.ParamName, nameof(contract));
        }

        [TestMethod]
        public async Task TestCreateContractClientAgeFail()
        {
            Contract contract = new Contract()
            {
                Id = new Guid(),
                Client = new Client(),
                Abonament = new Abonament()
            };

            contract.Client.CodNumericPersonal = "5040914080014";

            ArgumentException exception = await Assert.ThrowsExceptionAsync<ArgumentException>(() => controller.AddContract(contract));

            Assert.AreEqual(exception.Message, "Varsta clientului este sub 18 ani");
        }

        [TestMethod]
        public async Task TestCreateContractFailRauPlatnic()
        {
            Contract contract = new Contract()
            {
                Id = new Guid(),
                Client = new Client(),
                Abonament = new Abonament()
            };

            contract.Client.CodNumericPersonal = "1960914080014";

            Pret sumaPlatita = new Pret()
            {
                Suma = 0,
                Valuta = "RON"
            };

            Pret totalDePlata = new Pret()
            {
                Suma = 100,
                Valuta = "RON"
            };

            Plata[] plati = {
                new Plata()
                {
                    Client = contract.Client,
                    Contract = contract,
                    DataScadenta = DateTime.Today,
                    DataPlata = new DateTime(2019,1,1),
                    TotalDePlata = totalDePlata,
                    SumaPlatita = sumaPlatita
                }
            };

            this.plataRepositoryMock.Setup(t => t.Get(
                It.IsAny<Expression<Func<Plata, bool>>>(),
                It.IsAny<Func<IQueryable<Plata>, IOrderedQueryable<Plata>>>(),
                It.IsAny<string>())).ReturnsAsync(plati);

            ArgumentException exception = await Assert.ThrowsExceptionAsync<ArgumentException>(() => controller.AddContract(contract));

            Assert.AreEqual(exception.Message, "Clientul nu este bun platnic");
        }

        [TestMethod]
        public async Task TestDeleteContractObject()
        {
            Contract contract = new Contract()
            {
                Id = new Guid()
            };

            this.contractRepository.Setup(t => t.Delete(It.IsAny<Contract>())).Verifiable();

            await controller.DeleteContract(contract);

            this.contractRepository.VerifyAll();
        }

        [TestMethod]
        public async Task TestDeleteContractNull()
        {
            Contract contract = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.DeleteContract(contract));

            Assert.AreEqual(exception.ParamName, nameof(contract));
        }

        [TestMethod]
        public async Task TestGetAllContract()
        {
            Contract[] contracte = { new Contract { Id = new Guid() }, new Contract { Id = new Guid() } };

            this.contractRepository.Setup(t => t.Get(
                It.IsAny<Expression<Func<Contract, bool>>>(),
                It.IsAny<Func<IQueryable<Contract>, IOrderedQueryable<Contract>>>(),
                It.IsAny<string>())).ReturnsAsync(contracte);

            IEnumerable<Contract> found = await controller.GetAllContract();

            Assert.AreEqual(2, found.Count());
        }

        [TestMethod]
        public async Task TestDeleteById()
        {
            this.contractRepository.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();

            await controller.DeleteContractByID(1);

            this.contractRepository.VerifyAll();
        }

        [TestMethod]
        public async Task TestUpdateContractNull()
        {
            Contract contract = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.UpdateContract(contract));

            Assert.AreEqual(exception.ParamName, nameof(contract));
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Contract contract = new Contract()
            {
                Id = new Guid()
            };

            contract.Id = new Guid();

            this.contractRepository.Setup(t => t.Update(It.IsAny<Contract>())).Verifiable();

            await controller.UpdateContract(contract);

            this.contractRepository.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetById()
        {
            this.contractRepository.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(new Contract());

            Contract contract = await controller.GetById(Guid.NewGuid());

            Assert.IsNotNull(contract);
        }

        [TestMethod]
        public void TestGetCostContract()
        {
            Contract contract = new Contract
            {
                Id = Guid.NewGuid(),
                Client = new Client(),
                Abonament = new Abonament
                {

                },
                Valabil = true,
                Convorbiri = new List<ConvorbireTelefonica>()
            };
        }

        [TestMethod]
        public async Task TestAplicaBonusNull()
        {
            Bonus bonus = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.AplicaBonus(bonus));

            Assert.AreEqual(exception.ParamName, "Bonusul este null");
        }

        [TestMethod]
        public async Task TestAplicaBonusContractNull()
        {
            Bonus bonus = new Bonus()
            {
                MinuteBonus = 100,
                SmsBonus = 20,
                DateBonus = 10,
                Contract = null,
                TipBonus = "National"
            };

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.AplicaBonus(bonus));

            Assert.AreEqual(exception.ParamName, "Contractul este null");
        }

        [TestMethod]
        public async Task TestAplicaBonusMinute()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            Minute[] minute = {
                new Minute()
                {
                    TipMinute = "Retea",
                    NumarMinute = 100,
                    MinuteConsumate = 0
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentMinute = minute
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament,
            };

            Bonus bonus = new Bonus()
            {
                MinuteBonus = 100,
                SmsBonus = 20,
                DateBonus = 10,
                Contract = contract,
                TipBonus = "Retea"
            };

            this.contractRepository.Setup(t => t.Insert(It.IsAny<Contract>()));

            Contract result = await this.controller.AplicaBonus(bonus);

            Assert.AreEqual(200, result.Abonament.AbonamentMinute.FirstOrDefault().NumarMinute);
        }

        [TestMethod]
        public async Task TestAplicaBonusDate()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            DateMobile[] date = {
                new DateMobile()
                {
                    TipDate = "Retea",
                    NumarDate = 100,
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentDate = date
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament,
            };

            Bonus bonus = new Bonus()
            {
                MinuteBonus = 100,
                SmsBonus = 20,
                DateBonus = 10,
                Contract = contract,
                TipBonus = "Retea"
            };

            this.contractRepository.Setup(t => t.Insert(It.IsAny<Contract>()));

            Contract result = await this.controller.AplicaBonus(bonus);

            Assert.AreEqual(110, result.Abonament.AbonamentDate.FirstOrDefault().NumarDate);
        }

        [TestMethod]
        public async Task TestAplicaBonusSms()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            SMS[] sms = {
                new SMS()
                {
                    TipSms = "Retea",
                    NumarSms = 100,
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentSms = sms
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament,
            };

            Bonus bonus = new Bonus()
            {
                MinuteBonus = 100,
                SmsBonus = 20,
                DateBonus = 10,
                Contract = contract,
                TipBonus = "Retea"
            };

            this.contractRepository.Setup(t => t.Insert(It.IsAny<Contract>()));

            Contract result = await this.controller.AplicaBonus(bonus);

            Assert.AreEqual(120, result.Abonament.AbonamentSms.FirstOrDefault().NumarSms);
        }

        [TestMethod]
        public async Task TestGenereazaPlataContractNull()
        {
            Contract contract = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.GenereazaPlata(contract));

            Assert.AreEqual("Contractul este null", exception.ParamName);
        }

        [TestMethod]
        public async Task TestGenereazaPlataContractIncheiat()
        {
            Contract contract = new Contract()
            {
                Client = new Client(),
                Valabil = false,
                Abonament = new Abonament(),
            };

            ArgumentException exception = await Assert.ThrowsExceptionAsync<ArgumentException>(() => controller.GenereazaPlata(contract));

            Assert.AreEqual("Nu poate fi emisa factura pentru un contract incheiat", exception.Message);
        }

        [TestMethod]
        public async Task TestGenereazaPlataAbonamentExpirat()
        {
            Contract contract = new Contract()
            {
                Client = new Client(),
                Valabil = true,
                Abonament = new Abonament()
                {
                    Expirat = true
                },
            };

            ArgumentException exception = await Assert.ThrowsExceptionAsync<ArgumentException>(() => controller.GenereazaPlata(contract));

            Assert.AreEqual("Contract invalid. Abonamentul este expirat", exception.Message);
        }

        [TestMethod]
        public async Task TestGenereazaPlata()
        {
            Contract contract = new Contract()
            {
                Client = new Client(),
                Valabil = true,
                Abonament = new Abonament()
                {
                    Expirat = false,
                    Pret = 100
                },
            };

            this.plataRepositoryMock.Setup(mock => mock.Update(It.IsAny<Plata>()));

            Plata result = await this.controller.GenereazaPlata(contract);

            Assert.AreEqual(100, result.TotalDePlata.Suma);
        }

        [TestMethod]
        public void TestGetCostContractNull()
        {
            Contract contract = null;

            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => controller.GetCost(contract));

            Assert.AreEqual("contractul este null", exception.ParamName);
        }

        [TestMethod]
        public void TestGetCostAbonamentNull()
        {
            Contract contract = new Contract()
            {
                Abonament = null
            };

            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => controller.GetCost(contract));

            Assert.AreEqual("Abonamentul este null", exception.ParamName);
        }

        [TestMethod]
        public void TestGetCost()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            Minute[] minute = {
                new Minute()
                {
                    TipMinute = "Retea",
                    NumarMinute = 100,
                    PretMinute = new Pret()
                    {
                        Suma = 3,
                        Valuta = "RON"
                    }
                }
            };

            DateMobile[] date = {
                new DateMobile()
                {
                    TipDate = "Retea",
                    NumarDate = 100,
                    PretData = new Pret()
                    {
                        Suma = 1,
                        Valuta = "RON"
                    }
                }
            };

            SMS[] sms = {
                new SMS()
                {
                    TipSms = "Retea",
                    NumarSms = 5,
                    PretSms = new Pret()
                    {
                        Valuta = "RON",
                        Suma = 2
                    }
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentSms = sms,
                AbonamentDate = date,
                AbonamentMinute = minute
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament,
            };

            double result = this.controller.GetCost(contract);

            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void TestGetCost2()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            Minute[] minute = {
                new Minute()
                {
                    TipMinute = "Nationale",
                    NumarMinute = 100,
                    PretMinute = new Pret()
                    {
                        Suma = 3,
                        Valuta = "RON"
                    }
                }
            };

            DateMobile[] date = {
                new DateMobile()
                {
                    TipDate = "Retea",
                    NumarDate = 100,
                    PretData = new Pret()
                    {
                        Suma = 1,
                        Valuta = "RON"
                    }
                }
            };

            SMS[] sms = {
                new SMS()
                {
                    TipSms = "Nationale",
                    NumarSms = 5,
                    PretSms = new Pret()
                    {
                        Valuta = "RON",
                        Suma = 2
                    }
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentSms = sms,
                AbonamentDate = date,
                AbonamentMinute = minute
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament,
            };

            double result = this.controller.GetCost(contract);

            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void TestGetCost3()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            Minute[] minute = {
                new Minute()
                {
                    TipMinute = "Roaming",
                    NumarMinute = 100,
                    PretMinute = new Pret()
                    {
                        Suma = 3,
                        Valuta = "RON"
                    }
                }
            };

            DateMobile[] date = {
                new DateMobile()
                {
                    TipDate = "Retea",
                    NumarDate = 100,
                    PretData = new Pret()
                    {
                        Suma = 1,
                        Valuta = "RON"
                    }
                }
            };

            SMS[] sms = {
                new SMS()
                {
                    TipSms = "Roaming",
                    NumarSms = 5,
                    PretSms = new Pret()
                    {
                        Valuta = "RON",
                        Suma = 2
                    }
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentSms = sms,
                AbonamentDate = date,
                AbonamentMinute = minute
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament,
            };

            double result = this.controller.GetCost(contract);

            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public async Task TestIncheieLunaContractNull()
        {
            Contract contract = null;

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.IncheieLunaSiReporteaza(contract));

            Assert.AreEqual("Contractul este null", exception.ParamName);
        }

        [TestMethod]
        public async Task TestIncheieLuna()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            Minute[] minute = {
                new Minute()
                {
                    TipMinute = "Retea",
                    NumarMinute = 100,
                    MinuteConsumate = 90,
                    PretMinute = new Pret()
                    {
                        Suma = 3,
                        Valuta = "RON"
                    }
                }
            };

            DateMobile[] date = {
                new DateMobile()
                {
                    TipDate = "Retea",
                    NumarDate = 100,
                    DateConsumate = 95,
                    PretData = new Pret()
                    {
                        Suma = 1,
                        Valuta = "RON"
                    }
                }
            };

            SMS[] sms = {
                new SMS()
                {
                    TipSms = "Retea",
                    NumarSms = 5,
                    SmsConsumate = 5,
                    PretSms = new Pret()
                    {
                        Valuta = "RON",
                        Suma = 2
                    }
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentSms = sms,
                AbonamentDate = date,
                AbonamentMinute = minute
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament,
            };

            this.plataRepositoryMock.Setup(mock => mock.Update(It.IsAny<Plata>()));
            this.abonamentRepositoryMock.Setup(mock => mock.Update(It.IsAny<Abonament>()));

            Contract result = await this.controller.IncheieLunaSiReporteaza(contract);

            Assert.AreEqual(110, result.Abonament.AbonamentMinute.FirstOrDefault().NumarMinute);
            Assert.AreEqual(105, result.Abonament.AbonamentDate.FirstOrDefault().NumarDate);
            Assert.AreEqual(5, result.Abonament.AbonamentSms.FirstOrDefault().NumarSms);
        }

        [TestMethod]
        public async Task TestIncheieLuna2()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            Minute[] minute = {
                new Minute()
                {
                    TipMinute = "Nationale",
                    NumarMinute = 100,
                    MinuteConsumate = 90,
                    PretMinute = new Pret()
                    {
                        Suma = 3,
                        Valuta = "RON"
                    }
                }
            };

            DateMobile[] date = {
                new DateMobile()
                {
                    TipDate = "Retea",
                    NumarDate = 100,
                    DateConsumate = 95,
                    PretData = new Pret()
                    {
                        Suma = 1,
                        Valuta = "RON"
                    }
                }
            };

            SMS[] sms = {
                new SMS()
                {
                    TipSms = "Nationale",
                    NumarSms = 5,
                    SmsConsumate = 5,
                    PretSms = new Pret()
                    {
                        Valuta = "RON",
                        Suma = 2
                    }
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentSms = sms,
                AbonamentDate = date,
                AbonamentMinute = minute
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament,
            };

            this.plataRepositoryMock.Setup(mock => mock.Update(It.IsAny<Plata>()));
            this.abonamentRepositoryMock.Setup(mock => mock.Update(It.IsAny<Abonament>()));

            Contract result = await this.controller.IncheieLunaSiReporteaza(contract);

            Assert.AreEqual(110, result.Abonament.AbonamentMinute.FirstOrDefault().NumarMinute);
            Assert.AreEqual(105, result.Abonament.AbonamentDate.FirstOrDefault().NumarDate);
            Assert.AreEqual(5, result.Abonament.AbonamentSms.FirstOrDefault().NumarSms);
        }

        [TestMethod]
        public async Task TestIncheieLuna3()
        {
            Client client = new Client()
            {
                FirstName = "Octavian",
                LastName = "Pintiliciuc",
                CodNumericPersonal = "1960914080014"
            };

            Minute[] minute = {
                new Minute()
                {
                    TipMinute = "Roaming",
                    NumarMinute = 100,
                    MinuteConsumate = 90,
                    PretMinute = new Pret()
                    {
                        Suma = 3,
                        Valuta = "RON"
                    }
                }
            };

            DateMobile[] date = {
                new DateMobile()
                {
                    TipDate = "Roaming",
                    NumarDate = 100,
                    DateConsumate = 95,
                    PretData = new Pret()
                    {
                        Suma = 1,
                        Valuta = "RON"
                    }
                }
            };

            SMS[] sms = {
                new SMS()
                {
                    TipSms = "Roaming",
                    NumarSms = 5,
                    SmsConsumate = 5,
                    PretSms = new Pret()
                    {
                        Valuta = "RON",
                        Suma = 2
                    }
                }
            };

            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now.AddDays(1),
                DataSfarsit = new DateTime(2020, 9, 14),
                NumeAbonament = "Abonament Digi",
                AbonamentSms = sms,
                AbonamentDate = date,
                AbonamentMinute = minute
            };

            Contract contract = new Contract()
            {
                Client = client,
                Valabil = true,
                Abonament = abonament,
            };

            this.plataRepositoryMock.Setup(mock => mock.Update(It.IsAny<Plata>()));
            this.abonamentRepositoryMock.Setup(mock => mock.Update(It.IsAny<Abonament>()));

            Contract result = await this.controller.IncheieLunaSiReporteaza(contract);

            Assert.AreEqual(110, result.Abonament.AbonamentMinute.FirstOrDefault().NumarMinute);
            Assert.AreEqual(105, result.Abonament.AbonamentDate.FirstOrDefault().NumarDate);
            Assert.AreEqual(5, result.Abonament.AbonamentSms.FirstOrDefault().NumarSms);
        }
    }
}
