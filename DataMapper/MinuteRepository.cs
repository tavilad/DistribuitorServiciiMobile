using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class MinuteRepository : BaseRepository<Minute>, IMinuteRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public MinuteRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
