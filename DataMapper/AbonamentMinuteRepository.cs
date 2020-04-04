using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class AbonamentMinuteRepository : BaseRepository<AbonamentMinute>, IAbonamentMinuteRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public AbonamentMinuteRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
