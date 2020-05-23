namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
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

        /// <summary>Initializes a new instance of the <see cref="ContractController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public ContractController(IContractRepository repository)
        {
            this.contractRepository = repository;
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
    }
}
