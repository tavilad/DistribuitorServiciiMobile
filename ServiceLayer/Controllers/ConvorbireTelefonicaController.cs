using DataMapper.Interfaces;
using DomainModel.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    public class ConvorbireTelefonicaController
    {
        private IConvorbireTelefonicaRepository convorbireRepository;

        public ConvorbireTelefonicaController(IConvorbireTelefonicaRepository repository)
        {
            this.convorbireRepository = repository;
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

        private void Validate(ConvorbireTelefonica convorbire)
        {
            var context = new ValidationContext(convorbire);
            Validator.ValidateObject(convorbire, context, true);
        }
    }
}
