namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using FluentValidation.Results;
    using ServiceLayer.Validation;

    /// <summary>Service layer controller for the Contract entity</summary>
    public class ContractController
    {
        /// <summary>The contract repository</summary>
        private IContractRepository contractRepository;

        /// <summary>The contract validation</summary>
        private ContractValidation contractValidation;

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
            this.contractValidation = new ContractValidation();
            ValidationResult results = this.contractValidation.Validate(contract);
            if (results.Errors.Count == 0)
            {
                await this.contractRepository.Insert(contract);
            }
        }

        /// <summary>Deletes the contract.</summary>
        /// <param name="contract">The contract.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteContract(Contract contract)
        {
            await this.contractRepository.Delete(contract);
        }
    }
}
