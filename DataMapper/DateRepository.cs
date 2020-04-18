using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class DateRepository : BaseRepository<DateMobile>, IDateRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public DateRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
