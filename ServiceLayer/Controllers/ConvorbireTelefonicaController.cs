using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using DomainModel.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    public class ConvorbireTelefonicaController
    {
        private IConvorbireTelefonicaRepository convorbireRepository;

        private IAbonamentRepository abonamentRepository;

        public ConvorbireTelefonicaController(IConvorbireTelefonicaRepository repository, IAbonamentRepository abonamentRepository)
        {
            this.convorbireRepository = repository;
            this.abonamentRepository = abonamentRepository;
        }


        public async Task<IEnumerable<ConvorbireTelefonica>> GetAllConvorbire()
        {
            return await this.convorbireRepository.Get(convorbire => convorbire != null, null, string.Empty);
        }

        public async Task AddConvorbire(ConvorbireTelefonica convorbire)
        {
            if (convorbire == null)
            {
                throw new ArgumentNullException(nameof(convorbire));
            }

            this.Validate(convorbire);

            await this.convorbireRepository.Insert(convorbire);
        }


        public async Task DeleteConvorbire(ConvorbireTelefonica convorbire)
        {
            if (convorbire == null)
            {
                throw new ArgumentNullException(nameof(convorbire));
            }

            await this.convorbireRepository.Delete(convorbire);
        }

        public async Task DeleteConvorbireByID(int id)
        {
            await this.convorbireRepository.Delete(id);
        }

        public async Task UpdateConvorbire(ConvorbireTelefonica convorbire)
        {
            if (convorbire == null)
            {
                throw new ArgumentNullException(nameof(convorbire));
            }

            await this.convorbireRepository.Update(convorbire);
        }

        public async Task<ConvorbireTelefonica> GetById(object id)
        {
            return await this.convorbireRepository.GetById(id);
        }

        public async Task<Abonament> ExecutaApel(ConvorbireTelefonica convorbireTelefonica, Contract contract)
        {
            await this.convorbireRepository.Insert(convorbireTelefonica);

            Client initiator = convorbireTelefonica.Initiator;

            Abonament abonament = initiator.Contracte.Where(con => con.Id == contract.Id).FirstOrDefault().Abonament;
            abonament.AbonamentMinute.Where(minute => minute.TipMinute == convorbireTelefonica.TipConvorbire).FirstOrDefault().MinuteConsumate +=
                (int)convorbireTelefonica.DurataConvorbire;

            await this.abonamentRepository.Update(abonament);

            return abonament;
        }

        private void Validate(ConvorbireTelefonica convorbire)
        {
            var context = new ValidationContext(convorbire);
            Validator.ValidateObject(convorbire, context, true);
        }
    }
}
