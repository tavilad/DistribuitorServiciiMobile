namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using FluentValidation.Results;

    /// <summary>Service layer controller for the Client entity</summary>
    public class ClientController
    {
        /// <summary>The client repository</summary>
        private IClientRepository clientRepository;

        /// <summary>Initializes a new instance of the <see cref="ClientController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public ClientController(IClientRepository repository)
        {
            this.clientRepository = repository;
        }

        /// <summary>Gets all client.</summary>
        /// <returns>A list on Client entity</returns>
        public async Task<IEnumerable<Client>> GetAllClient()
        {
            return await this.clientRepository.Get(client => client != null, null, string.Empty);
        }

        /// <summary>Adds the client.</summary>
        /// <param name="client">The client.</param>
        /// <returns>Awaitable task</returns>
        public async Task AddClient(Client client)
        {
            await this.clientRepository.Insert(client);
        }

        /// <summary>Deletes the client.</summary>
        /// <param name="client">The client.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteClient(Client client)
        {
            await this.clientRepository.Delete(client);
        }

        public async Task DeleteClientByID(int id)
        {
            await this.clientRepository.Delete(id);
        }

        public async Task UpdateClient(Client client)
        {
            await this.clientRepository.Update(client);
        }
    }
}
