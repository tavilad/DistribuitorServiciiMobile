using DataMapper.Interfaces;
using DomainModel.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
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
            await this.convorbireRepository.Insert(convorbire);
        }


        public async Task DeleteConvorbire(ConvorbireTelefonica convorbire)
        {
            await this.convorbireRepository.Delete(convorbire);
        }

        public async Task DeleteConvorbireByID(int id)
        {
            await this.convorbireRepository.Delete(id);
        }

        public async Task UpdateConvorbire(ConvorbireTelefonica convorbire)
        {
            await this.convorbireRepository.Update(convorbire);
        }
    }
}
