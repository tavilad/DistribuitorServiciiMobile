namespace DataMapper
{
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;

    /// <summary>Repository class for Abonament entity</summary>
    public class AbonamentRepository : BaseRepository<Abonament>, IAbonamentRepository
    {
        /// <summary>The context</summary>
        private readonly DistribuitorServiciiMobileContext context;

        /// <summary>Initializes a new instance of the <see cref="AbonamentRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public AbonamentRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
