using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class SmsRepository : BaseRepository<SMS>, ISmsRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public SmsRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
