using DataMapper.Interfaces;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    public class PretController
    {
        private IPretRepository pretRepository;

        public PretController(IPretRepository repository)
        {
            this.pretRepository = repository;
        }

        public async Task<IEnumerable<Pret>> GetAllAbonament()
        {
            return await this.pretRepository.Get(pret => pret != null, null, string.Empty);
        }


        public async Task AddPret(Pret pret)
        {
            await this.pretRepository.Insert(pret);
        }

        public async Task DeletePret(Pret pret)
        {
            await this.pretRepository.Delete(pret);
        }

        public async Task DeletePretByID(int id)
        {
            await this.pretRepository.Delete(id);
        }

        public async Task UpdatePret(Pret pret)
        {
            await this.pretRepository.Update(pret);
        }
    }
}
