namespace DataMapper
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using DomainModel.Models;

    class ConvorbireTelefonicaRepository : BaseRepository<ConvorbireTelefonica>, IConvorbireTelefonicaRepository
    {
        /// <summary>The context</summary>
        private readonly DistribuitorServiciiMobileContext context;

        /// <summary>Initializes a new instance of the <see cref="AbonamentRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public ConvorbireTelefonicaRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
