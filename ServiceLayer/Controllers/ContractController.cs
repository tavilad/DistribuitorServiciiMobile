namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using DomainModel.Models;
    using FluentValidation.Results;

    /// <summary>Service layer controller for the Contract entity</summary>
    public class ContractController
    {
        /// <summary>The contract repository</summary>
        private IContractRepository contractRepository;

        private ClientController clientController;

        private IPlataRepository plataRepository;

        /// <summary>Initializes a new instance of the <see cref="ContractController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public ContractController(IContractRepository repository, ClientController clientController, IPlataRepository plataRepository)
        {
            this.contractRepository = repository;
            this.clientController = clientController;
            this.plataRepository = plataRepository;
        }

        /// <summary>Gets all contract.</summary>
        /// <returns>A list of Contract entity</returns>
        public async Task<IEnumerable<Contract>> GetAllContract()
        {
            return await this.contractRepository.Get(contract => contract != null, null, string.Empty);
        }

        /// <summary>Adds the contract.</summary>
        /// <param name="contract">The contract.</param>
        /// <returns>Awaitable task</returns>
        public async Task AddContract(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException(nameof(contract));
            }

            this.Validate(contract);

            DateTime clientDOB = this.clientController.GetClientDOB(contract.Client);
            int age = DateTime.Today.Year - clientDOB.Year;

            if (age < 18)
            {
                throw new ArgumentException("Varsta clientului este sub 18 ani");
            }

            if (!await this.clientController.CheckClientPaymentsOnTime(contract.Client))
            {
                throw new ArgumentException("Clientul nu este bun platnic");
            }

            await this.contractRepository.Insert(contract);
        }

        /// <summary>Deletes the contract.</summary>
        /// <param name="contract">The contract.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteContract(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException(nameof(contract));
            }

            await this.contractRepository.Delete(contract);
        }

        public async Task DeleteContractByID(int id)
        {
            await this.contractRepository.Delete(id);
        }

        public async Task UpdateContract(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException(nameof(contract));
            }

            await this.contractRepository.Update(contract);
        }

        public async Task<Contract> GetById(object id)
        {
            return await this.contractRepository.GetById(id);
        }

        public async Task<Pret> InchidereContract()
        {
            throw new NotImplementedException();
        }

        public async Task<Contract> AplicaBonus(Bonus bonus)
        {
            Contract contract = bonus.Contract;

            contract.Abonament.AbonamentDate.Where(date => date.TipDate == bonus.TipBonus).FirstOrDefault().NumarDate 
                = (int)contract.Abonament.AbonamentDate.Where(date => date.TipDate == bonus.TipBonus).Sum(date => date.NumarDate + bonus.DateBonus);
            contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == bonus.TipBonus).FirstOrDefault().NumarMinute = 
                (int)contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == bonus.TipBonus).Sum(minute => minute.NumarMinute + bonus.MinuteBonus);
            contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == bonus.TipBonus).FirstOrDefault().NumarSms =
                (int)contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == bonus.TipBonus).Sum(sms => sms.NumarSms + bonus.SmsBonus);

            await this.contractRepository.Update(contract);

            return contract;

        }

        public double GetCost(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException("contractul este null");
            }
            if (contract.Abonament == null)
            {
                throw new ArgumentNullException("Abonamentul asociat contractului trebuie sa fie valid, diferit de null");
            }

            #region Minute
            double minuteReteaConsumate = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").Sum(minute => minute.MinuteConsumate);
            double minuteNationaleConsumate = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "National").Sum(minute => minute.MinuteConsumate);
            double minuteRoamingConsumate = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").Sum(minute => minute.MinuteConsumate);

            double minuteReteaTotale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").Sum(minute => minute.NumarMinute);
            double minuteNationaleTotale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "National").Sum(minute => minute.NumarMinute);
            double minuteRoamingTotale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").Sum(minute => minute.NumarMinute);

            double nrMinuteReteaExtra = minuteReteaConsumate > minuteReteaTotale
               ? minuteReteaConsumate - minuteReteaTotale
               : 0;

            double nrMinuteNationaleExtra = minuteNationaleConsumate > minuteNationaleTotale
               ? minuteNationaleConsumate - minuteNationaleTotale
               : 0;

            double nrMinuteInternationaleExtra = minuteRoamingConsumate > minuteRoamingTotale
               ? minuteRoamingConsumate - minuteRoamingTotale
               : 0;

            double pretMinuteRetea = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").FirstOrDefault().PretMinute.Suma;
            double pretMinuteNationale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Nationale").FirstOrDefault().PretMinute.Suma;
            double pretMinuteInternationale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").FirstOrDefault().PretMinute.Suma;
            #endregion

            #region Date
            double dateReteaConsumate = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").Sum(date => date.DateConsumate);
            double dateRoamingConsumate = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").Sum(date => date.DateConsumate);

            double dateReteaTotale = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").Sum(date => date.NumarDate);
            double dateRoamingTotale = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").Sum(date => date.NumarDate);

            double nrDateReteaExtra = dateReteaConsumate > dateReteaTotale
               ? dateReteaConsumate - dateReteaTotale
               : 0;

            double nrDateInternationaleExtra = dateRoamingConsumate > dateRoamingTotale
               ? dateRoamingConsumate - dateRoamingTotale
               : 0;

            double pretDateRetea = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").FirstOrDefault().PretData.Suma;
            double pretDateInternationale = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").FirstOrDefault().PretData.Suma;
            #endregion

            #region SMS
            double smsReteaConsumate = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").Sum(sms => sms.SmsConsumate);
            double smsNationaleConsumate = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").Sum(sms => sms.SmsConsumate);
            double smsRoamingConsumate = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").Sum(sms => sms.SmsConsumate);

            double smsReteaTotale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").Sum(sms => sms.NumarSms);
            double smsNationaleTotale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").Sum(sms => sms.NumarSms);
            double smsRoamingTotale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").Sum(sms => sms.NumarSms);

            double nrSmsReteaExtra = smsReteaConsumate > smsReteaTotale
               ? smsReteaConsumate - smsReteaTotale
               : 0;

            double nrSmsNationaleExtra = smsNationaleConsumate > smsNationaleTotale
               ? smsNationaleConsumate - smsNationaleTotale
               : 0;

            double nrSmsInternationaleExtra = smsRoamingConsumate > smsRoamingTotale
               ? smsRoamingConsumate - smsRoamingTotale
               : 0;

            double pretSmsRetea = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").FirstOrDefault().PretSms.Suma;
            double pretSmsNationale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").FirstOrDefault().PretSms.Suma;
            double pretSmsRoaming = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").FirstOrDefault().PretSms.Suma;
            #endregion

            return contract.Abonament.Pret
               + nrMinuteReteaExtra * pretMinuteRetea
               + nrMinuteNationaleExtra * pretMinuteNationale
               + nrMinuteInternationaleExtra * pretMinuteInternationale
               + nrDateReteaExtra * pretDateRetea
               + nrDateInternationaleExtra * pretDateInternationale
               + nrSmsReteaExtra * pretSmsRetea
               + nrSmsNationaleExtra * pretSmsNationale
               + nrSmsInternationaleExtra * pretSmsRoaming;
        }

        public async Task IncheieLunaSiReporteazaMinute(Contract contract)
        {

        }

        public async Task<Plata> GenereazaPlata(Contract contract)
        {
            if (contract == null)
            {
                throw new InvalidOperationException($"Nu a fost gasit niciun contract cu id-ul {contract.Id}");
            }

            if (!contract.Valabil)
            {
                throw new InvalidOperationException($"Nu poate fi emisa factura pentru un contract incheiat");
            }

            if (!contract.Abonament.Expirat)
            {
                throw new InvalidOperationException($"Contract invalid. Abonamentul este expirat");
            }

            double costTotal = this.GetCost(contract);

            Plata plata = new Plata
            {
                TotalDePlata = new Pret { Id = new Guid(), Suma = costTotal, Valuta = "RON" },
                Contract = contract,
                DataScadenta = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day),
                SumaPlatita = new Pret { Id = new Guid(), Suma = 0, Valuta = "RON"}
            };

            await this.plataRepository.Insert(plata);

            return plata;
        }

        private void Validate(Contract contract)
        {
            var context = new ValidationContext(contract);
            Validator.ValidateObject(contract, context, true);
        }
    }
}
