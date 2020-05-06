using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using FluentValidation.Results;
using ServiceLayer.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    public class ContractController
    {
        private IContractRepository _contractRepository;
        private ContractValidation _contractValidation;

        public ContractController(IContractRepository repository)
        {
            this._contractRepository = repository;
        }

        public async Task<IEnumerable<Contract>> GetAllContract()
        {
            return await _contractRepository.Get(contract => contract != null, null, "");
        }

        public async Task AddContract(Contract contract)
        {
            this._contractValidation = new ContractValidation();
            ValidationResult results = _contractValidation.Validate(contract);
            if (results.Errors.Count == 0)
                await _contractRepository.Insert(contract);

        }

        public async Task DeleteContract(Contract contract)
        {
            await _contractRepository.Delete(contract);
        }
    }
}
