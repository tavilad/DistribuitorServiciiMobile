using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class ContractRepository: BaseRepository<Contract>, IContractRepository
    {
        private readonly DistribuitorServiciiMobileContext context;
        public ContractRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
