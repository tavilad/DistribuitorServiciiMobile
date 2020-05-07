using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    public class PlataRepository : BaseRepository<Plata>, IPlataRepository
    {
        /// <summary>The context</summary>
        private readonly DistribuitorServiciiMobileContext context;

        /// <summary>Initializes a new instance of the <see cref="AbonamentRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public PlataRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
