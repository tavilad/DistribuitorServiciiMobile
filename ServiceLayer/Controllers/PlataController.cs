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

        private IClientRepository clientRepository;

        private ContractController contractController;

        public PlataController(IPlataRepository repository, IContractRepository contractRepository, IClientRepository clientRepository, ClientController clientController)
        {
            this.plataRepository = repository;
            this.contractRepository = contractRepository;
            this.clientRepository = clientRepository;
            this.contractController = new ContractController(this.contractRepository, this.clientRepository, this.plataRepository, clientController);
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

            //double costTotal = this.contractController.GetCostTotal(idContract);

            Plata plata = new Plata
            {
                //CostTotal = costTotal,
                //IdContract = idContract,
                //DataScadenta = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day),
                //EsteAchitata = false,
            };

            await this.plataRepository.Insert(plata);

            return plata;
        }

        private void Validate(Plata plata)
        {
            var context = new ValidationContext(plata);
            Validator.ValidateObject(plata, context, true);
        }
    }
}
