using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class AbonamentRepository : BaseRepository<Abonament>, IAbonamentRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public AbonamentRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
