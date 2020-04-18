using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class AbonamentDateRepository : BaseRepository<AbonamentDate>, IAbonamentDateRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public AbonamentDateRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
