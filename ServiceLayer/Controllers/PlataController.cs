using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using DomainModel.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    public class PlataController
    {
        private IPlataRepository plataRepository;

        private IContractRepository contractRepository;

        private ContractController contractController;

        private IAbonamentRepository abonamentRepository;

        public PlataController(IPlataRepository repository, IContractRepository contractRepository, ClientController clientController, 
            IAbonamentRepository abonamentRepository)
        {
            this.plataRepository = repository;
            this.contractRepository = contractRepository;
            this.abonamentRepository = abonamentRepository;
            this.contractController = new ContractController(this.contractRepository, clientController, this.plataRepository, this.abonamentRepository);
        }


        public async Task<IEnumerable<Plata>> GetAllPlata()
        {
            return await this.plataRepository.Get(plata => plata != null, null, string.Empty);
        }

        public async Task AddPlata(Plata plata)
        {
            if (plata == null)
            {
                throw new ArgumentNullException(nameof(plata));
            }

            this.Validate(plata);

            await this.plataRepository.Insert(plata);
        }

        public async Task DeletePlata(Plata plata)
        {
            if (plata == null)
            {
                throw new ArgumentNullException(nameof(plata));
            }

            await this.plataRepository.Delete(plata);
        }

        public async Task DeletePlataByID(int id)
        {
            await this.plataRepository.Delete(id);
        }

        public async Task UpdatePlata(Plata plata)
        {
            if (plata == null)
            {
                throw new ArgumentNullException(nameof(plata));
            }

            await this.plataRepository.Update(plata);
        }

        public async Task<Plata> GetById(object id)
        {
            return await this.plataRepository.GetById(id);
        }

        private void Validate(Plata plata)
        {
            var context = new ValidationContext(plata);
            Validator.ValidateObject(plata, context, true);
        }
    }
}
