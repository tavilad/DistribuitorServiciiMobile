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

        private IAbonamentRepository abonamentRepository;

        /// <summary>Initializes a new instance of the <see cref="ContractController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public ContractController(IContractRepository repository, ClientController clientController, IPlataRepository plataRepository,
            IAbonamentRepository abonamentRepository)
        {
            this.contractRepository = repository;
            this.clientController = clientController;
            this.plataRepository = plataRepository;
            this.abonamentRepository = abonamentRepository;
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

        public async Task<Contract> AplicaBonus(Bonus bonus)
        {
            if (bonus == null)
            {
                throw new ArgumentNullException("Bonusul este null");
            }

            if (bonus.Contract == null)
            {
                throw new ArgumentNullException("Contractul este null");
            }

            Contract contract = bonus.Contract;

            if (contract.Abonament.AbonamentDate != null)
            {
                contract.Abonament.AbonamentDate.Where(date => date.TipDate == bonus.TipBonus).FirstOrDefault().NumarDate
                    = (int)contract.Abonament.AbonamentDate.Where(date => date.TipDate == bonus.TipBonus).Sum(date => date.NumarDate + bonus.DateBonus);
            }

            if (contract.Abonament.AbonamentMinute != null)
            {
                contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == bonus.TipBonus).FirstOrDefault().NumarMinute =
                    (int)contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == bonus.TipBonus).Sum(minute => minute.NumarMinute + bonus.MinuteBonus);
            }

            if (contract.Abonament.AbonamentSms != null)
            {
                contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == bonus.TipBonus).FirstOrDefault().NumarSms =
                    (int)contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == bonus.TipBonus).Sum(sms => sms.NumarSms + bonus.SmsBonus);
            }

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
                throw new ArgumentNullException("Abonamentul este null");
            }

            #region Minute

            int minuteReteaConsumate = 0;
            int minuteNationaleConsumate = 0;
            int minuteRoamingConsumate = 0;

            int minuteReteaTotale = 0;
            int minuteNationaleTotale = 0;
            int minuteRoamingTotale = 0;

            int nrMinuteReteaExtra = 0;

            int nrMinuteNationaleExtra = 0;

            int nrMinuteInternationaleExtra = 0;

            double pretMinuteRetea = 0;
            double pretMinuteNationale = 0;
            double pretMinuteInternationale = 0;

            if (contract.Abonament.AbonamentMinute != null)
            {
                minuteReteaConsumate = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").Sum(minute => minute.MinuteConsumate);
                minuteNationaleConsumate = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Nationale").Sum(minute => minute.MinuteConsumate);
                minuteRoamingConsumate = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").Sum(minute => minute.MinuteConsumate);

                minuteReteaTotale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").Sum(minute => minute.NumarMinute);
                minuteNationaleTotale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Nationale").Sum(minute => minute.NumarMinute);
                minuteRoamingTotale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").Sum(minute => minute.NumarMinute);

                nrMinuteReteaExtra = minuteReteaConsumate > minuteReteaTotale
                   ? minuteReteaConsumate - minuteReteaTotale
                   : 0;

                nrMinuteNationaleExtra = minuteNationaleConsumate > minuteNationaleTotale
                   ? minuteNationaleConsumate - minuteNationaleTotale
                   : 0;

                nrMinuteInternationaleExtra = minuteRoamingConsumate > minuteRoamingTotale
                   ? minuteRoamingConsumate - minuteRoamingTotale
                   : 0;

                if (contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").FirstOrDefault() != null)
                {
                    pretMinuteRetea = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").FirstOrDefault().PretMinute.Suma;
                }

                if (contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Nationale").FirstOrDefault() != null)
                {
                    pretMinuteNationale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Nationale").FirstOrDefault().PretMinute.Suma;
                }

                if (contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").FirstOrDefault() != null)
                {
                    pretMinuteInternationale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").FirstOrDefault().PretMinute.Suma;
                }

            }
            #endregion

            #region Date

            int dateReteaConsumate = 0;
            int dateRoamingConsumate = 0;

            int dateReteaTotale = 0;
            int dateRoamingTotale = 0;

            int nrDateReteaExtra = 0;

            int nrDateInternationaleExtra = 0;

            double pretDateRetea = 0;
            double pretDateInternationale = 0;

            if (contract.Abonament.AbonamentDate != null)
            {
                dateReteaConsumate = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").Sum(date => date.DateConsumate);
                dateRoamingConsumate = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").Sum(date => date.DateConsumate);

                dateReteaTotale = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").Sum(date => date.NumarDate);
                dateRoamingTotale = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").Sum(date => date.NumarDate);

                nrDateReteaExtra = dateReteaConsumate > dateReteaTotale
                   ? dateReteaConsumate - dateReteaTotale
                   : 0;

                nrDateInternationaleExtra = dateRoamingConsumate > dateRoamingTotale
                   ? dateRoamingConsumate - dateRoamingTotale
                   : 0;

                if(contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").FirstOrDefault()!=null)
                {
                    pretDateRetea = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").FirstOrDefault().PretData.Suma;
                }

                if(contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").FirstOrDefault()!=null)
                {
                    pretDateInternationale = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").FirstOrDefault().PretData.Suma;
                }

            }
            #endregion

            #region SMS
            int smsReteaConsumate = 0;
            int smsNationaleConsumate = 0;
            int smsRoamingConsumate = 0;

            int smsReteaTotale = 0;
            int smsNationaleTotale = 0;
            int smsRoamingTotale = 0;

            int nrSmsReteaExtra = 0;

            int nrSmsNationaleExtra = 0;

            int nrSmsInternationaleExtra = 0;

            double pretSmsRetea = 0;
            double pretSmsNationale = 0;
            double pretSmsRoaming = 0;

            if (contract.Abonament.AbonamentSms != null)
            {
                smsReteaConsumate = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").Sum(sms => sms.SmsConsumate);
                smsNationaleConsumate = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").Sum(sms => sms.SmsConsumate);
                smsRoamingConsumate = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").Sum(sms => sms.SmsConsumate);

                smsReteaTotale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").Sum(sms => sms.NumarSms);
                smsNationaleTotale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").Sum(sms => sms.NumarSms);
                smsRoamingTotale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").Sum(sms => sms.NumarSms);

                nrSmsReteaExtra = smsReteaConsumate > smsReteaTotale
                   ? smsReteaConsumate - smsReteaTotale
                   : 0;

                nrSmsNationaleExtra = smsNationaleConsumate > smsNationaleTotale
                   ? smsNationaleConsumate - smsNationaleTotale
                   : 0;

                nrSmsInternationaleExtra = smsRoamingConsumate > smsRoamingTotale
                   ? smsRoamingConsumate - smsRoamingTotale
                   : 0;

                if(contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").FirstOrDefault()!=null)
                {
                    pretSmsRetea = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").FirstOrDefault().PretSms.Suma;
                }

                if(contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").FirstOrDefault()!=null)
                {
                    pretSmsNationale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").FirstOrDefault().PretSms.Suma;
                }

                if(contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").FirstOrDefault()!=null)
                {
                    pretSmsRoaming = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").FirstOrDefault().PretSms.Suma;
                }

            }
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

        public async Task<Contract> IncheieLunaSiReporteaza(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException("Contractul este null");
            }

            await this.GenereazaPlata(contract);

            #region Minute

            int minuteReteaConsumate = 0;
            int minuteNationaleConsumate = 0;
            int minuteRoamingConsumate = 0;

            int minuteReteaTotale = 0;
            int minuteNationaleTotale = 0;
            int minuteRoamingTotale = 0;

            int nrMinuteReteaRamase = 0;
            int nrMinuteNationaleRamase = 0;
            int nrMinuteInternationaleRamase = 0;

            if (contract.Abonament.AbonamentMinute != null)
            {
                minuteReteaConsumate = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").Sum(minute => minute.MinuteConsumate);
                minuteNationaleConsumate = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Nationale").Sum(minute => minute.MinuteConsumate);
                minuteRoamingConsumate = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").Sum(minute => minute.MinuteConsumate);

                minuteReteaTotale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").Sum(minute => minute.NumarMinute);
                minuteNationaleTotale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Nationale").Sum(minute => minute.NumarMinute);
                minuteRoamingTotale = contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").Sum(minute => minute.NumarMinute);

                nrMinuteReteaRamase = minuteReteaConsumate < minuteReteaTotale
                   ? minuteReteaTotale - minuteReteaConsumate
                   : 0;

                nrMinuteNationaleRamase = minuteNationaleConsumate < minuteNationaleTotale
                   ? minuteNationaleTotale - minuteNationaleConsumate
                   : 0;

                nrMinuteInternationaleRamase = minuteRoamingConsumate < minuteRoamingTotale
                   ? minuteRoamingTotale - minuteRoamingConsumate 
                   : 0;

                if (contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").FirstOrDefault() != null)
                {
                    contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Retea").FirstOrDefault().NumarMinute += nrMinuteReteaRamase;
                }

                if (contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Nationale").FirstOrDefault() != null)
                {
                    contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Nationale").FirstOrDefault().NumarMinute += nrMinuteNationaleRamase;
                }

                if (contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").FirstOrDefault() != null)
                {
                    contract.Abonament.AbonamentMinute.Where(minute => minute.TipMinute == "Roaming").FirstOrDefault().NumarMinute += nrMinuteInternationaleRamase;
                }

            }
            #endregion

            #region Date

            int dateReteaConsumate = 0;
            int dateRoamingConsumate = 0;

            int dateReteaTotale = 0;
            int dateRoamingTotale = 0;

            int nrDateReteaRamase = 0;
            int nrDateInternationaleRamase = 0;

            if (contract.Abonament.AbonamentDate != null)
            {
                dateReteaConsumate = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").Sum(date => date.DateConsumate);
                dateRoamingConsumate = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").Sum(date => date.DateConsumate);

                dateReteaTotale = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").Sum(date => date.NumarDate);
                dateRoamingTotale = contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").Sum(date => date.NumarDate);

                nrDateReteaRamase = dateReteaConsumate < dateReteaTotale
                   ? dateReteaTotale - dateReteaConsumate
                   : 0;

                nrDateInternationaleRamase = dateRoamingConsumate < dateRoamingTotale
                   ? dateRoamingTotale - dateRoamingConsumate
                   : 0;

                if (contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").FirstOrDefault() != null)
                {
                    contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Retea").FirstOrDefault().NumarDate += nrDateReteaRamase;
                }

                if (contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").FirstOrDefault() != null)
                {
                    contract.Abonament.AbonamentDate.Where(date => date.TipDate == "Roaming").FirstOrDefault().NumarDate += nrDateInternationaleRamase;
                }

            }
            #endregion

            #region SMS
            int smsReteaConsumate = 0;
            int smsNationaleConsumate = 0;
            int smsRoamingConsumate = 0;

            int smsReteaTotale = 0;
            int smsNationaleTotale = 0;
            int smsRoamingTotale = 0;

            int nrSmsReteaRamase = 0;
            int nrSmsNationaleRamase = 0;
            int nrSmsInternationaleRamase = 0;

            if (contract.Abonament.AbonamentSms != null)
            {
                smsReteaConsumate = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").Sum(sms => sms.SmsConsumate);
                smsNationaleConsumate = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").Sum(sms => sms.SmsConsumate);
                smsRoamingConsumate = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").Sum(sms => sms.SmsConsumate);

                smsReteaTotale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").Sum(sms => sms.NumarSms);
                smsNationaleTotale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").Sum(sms => sms.NumarSms);
                smsRoamingTotale = contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").Sum(sms => sms.NumarSms);

                nrSmsReteaRamase = smsReteaConsumate < smsReteaTotale
                   ? smsReteaTotale - smsReteaConsumate
                   : 0;

                nrSmsNationaleRamase = smsNationaleConsumate < smsNationaleTotale
                   ? smsNationaleTotale - smsNationaleConsumate
                   : 0;

                nrSmsInternationaleRamase = smsRoamingConsumate < smsRoamingTotale
                   ? smsRoamingTotale - smsRoamingConsumate
                   : 0;

                if (contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").FirstOrDefault() != null)
                {
                    contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Retea").FirstOrDefault().NumarSms += nrSmsReteaRamase;
                }

                if (contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").FirstOrDefault() != null)
                {
                    contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Nationale").FirstOrDefault().NumarSms += nrSmsNationaleRamase;
                }

                if (contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").FirstOrDefault() != null)
                {
                    contract.Abonament.AbonamentSms.Where(sms => sms.TipSms == "Roaming").FirstOrDefault().NumarSms += nrSmsInternationaleRamase;
                }

            }
            #endregion

            await this.abonamentRepository.Update(contract.Abonament);

            return contract;

        }

        public async Task<Plata> GenereazaPlata(Contract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException("Contractul este null");
            }

            if (!contract.Valabil)
            {
                throw new ArgumentException("Nu poate fi emisa factura pentru un contract incheiat");
            }

            if (contract.Abonament.Expirat)
            {
                throw new ArgumentException("Contract invalid. Abonamentul este expirat");
            }

            double costTotal = this.GetCost(contract);

            Plata plata = new Plata
            {
                TotalDePlata = new Pret { Id = new Guid(), Suma = costTotal, Valuta = "RON" },
                Contract = contract,
                DataScadenta = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day),
                SumaPlatita = new Pret { Id = new Guid(), Suma = 0, Valuta = "RON" }
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
