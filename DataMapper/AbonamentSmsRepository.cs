using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class AbonamentSmsRepository : BaseRepository<AbonamentSms>, IAbonamentSmsRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public AbonamentSmsRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
