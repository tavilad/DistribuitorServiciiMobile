using DataMapper.Interfaces;
using DomainModel.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    public class PlataController
    {
        private IPlataRepository plataRepository;


        public PlataController(IPlataRepository repository)
        {
            this.plataRepository = repository;
        }


        public async Task<IEnumerable<Plata>> GetAllPlata()
        {
            return await this.plataRepository.Get(plata => plata != null, null, string.Empty);
        }

        public async Task AddPlata(Plata plata)
        {
            await this.plataRepository.Insert(plata);
        }

        public async Task DeletePlata(Plata plata)
        {
            await this.plataRepository.Delete(plata);
        }

        public async Task DeletePlataByID(int id)
        {
            await this.plataRepository.Delete(id);
        }

        public async Task UpdatePlata(Plata plata)
        {
            await this.plataRepository.Update(plata);
        }

        public async Task<Plata> GetById(object id)
        {
            return await this.plataRepository.GetById(id);
        }
    }
}
