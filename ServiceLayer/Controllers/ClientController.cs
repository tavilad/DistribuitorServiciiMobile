namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using DomainModel.Models;
    using FluentValidation.Results;

    /// <summary>Service layer controller for the Client entity</summary>
    public class ClientController
    {
        /// <summary>The client repository</summary>
        private IClientRepository clientRepository;

        private IPlataRepository plataRepository;

        /// <summary>Initializes a new instance of the <see cref="ClientController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public ClientController(IClientRepository repository, IPlataRepository plataRepository)
        {
            this.clientRepository = repository;
            this.plataRepository = plataRepository;
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
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            await this.clientRepository.Insert(client);
        }

        /// <summary>Deletes the client.</summary>
        /// <param name="client">The client.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            await this.clientRepository.Delete(client);
        }

        public async Task DeleteClientByID(int id)
        {
            await this.clientRepository.Delete(id);
        }

        public async Task UpdateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            await this.clientRepository.Update(client);
        }

        public async Task<Client> GetById(object id)
        {
            return await this.clientRepository.GetById(id);
        }

        public DateTime GetClientDOB(Client client)
        {
            string year = client.CodNumericPersonal.Substring(1, 2);
            int month = int.Parse(client.CodNumericPersonal.Substring(3, 2));
            int day = int.Parse(client.CodNumericPersonal.Substring(5, 2));
            string yearPrefix = new char[] { '1', '2' }.Contains(client.CodNumericPersonal.ToCharArray()[0]) ? "19" :
                                new char[] { '3', '4' }.Contains(client.CodNumericPersonal.ToCharArray()[0]) ? "18" : "20";

            return new DateTime(int.Parse(yearPrefix + year), month, day);
        }

        public async Task<bool> CheckClientPaymentsOnTime(Client client)
        {
            IEnumerable<Plata> platiContract = await this.plataRepository.Get(plata => plata.DataPlata.Month < DateTime.Today.Month
                                                                                       && plata.Client == client);


            foreach(Plata plata in platiContract)
            {
                if(!plata.EsteAchitat)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
