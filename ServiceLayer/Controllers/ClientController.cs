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
    public class ClientController
    {
        private IClientRepository _clientRepository;
        private ClientValidation _clientValidation;

        public ClientController(IClientRepository repository)
        {
            this._clientRepository = repository;
        }

        public async Task<IEnumerable<Client>> GetAllClient()
        {
            return await _clientRepository.Get(client => client != null, null, "");
        }

        public async Task AddClient(Client client)
        {
            this._clientValidation = new ClientValidation();
            ValidationResult results = _clientValidation.Validate(client);
            if (results.Errors.Count == 0)
                await _clientRepository.Insert(client);

        }

        public async Task DeleteClient(Client client)
        {
            await _clientRepository.Delete(client);
        }
    }
}
