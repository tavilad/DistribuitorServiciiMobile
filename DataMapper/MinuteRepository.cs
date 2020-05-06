namespace DataMapper
{
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;

    /// <summary>Repository class for the Minute entity</summary>
    public class MinuteRepository : BaseRepository<Minute>, IMinuteRepository
    {
        /// <summary>The context</summary>
        private readonly DistribuitorServiciiMobileContext context;

        /// <summary>Initializes a new instance of the <see cref="MinuteRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public MinuteRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
