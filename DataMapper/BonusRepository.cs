using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class BonusRepository : BaseRepository<Bonus>, IBonusRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public BonusRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
