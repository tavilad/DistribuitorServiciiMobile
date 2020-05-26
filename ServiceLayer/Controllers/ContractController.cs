namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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

        private IClientRepository clientRepository;

        private IPlataRepository plataRepository;

        private ClientController clientController;

        /// <summary>Initializes a new instance of the <see cref="ContractController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public ContractController(IContractRepository repository, ClientController clientController)
        {
            this.contractRepository = repository;
            this.clientController = clientController;
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

            if(age < 18)
            {
                throw new ArgumentException("Varsta clientului este sub 18 ani");
            }

            if(!await this.clientController.CheckClientPaymentsOnTime(contract.Client))
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

        public async Task<Contract> PrelungireContract()
        {
            throw new NotImplementedException();
        }

        public async Task<Pret> CalculPret()
        {
            throw new NotImplementedException();
        }

        private void Validate(Contract contract)
        {
            var context = new ValidationContext(contract);
            Validator.ValidateObject(contract, context, true);
        }
    }
}
