using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public ClientRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
