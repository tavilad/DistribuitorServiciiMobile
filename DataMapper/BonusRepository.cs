namespace DataMapper
{
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;

    /// <summary>Repository class for the Bonus entity</summary>
    public class BonusRepository : BaseRepository<Bonus>, IBonusRepository
    {
        /// <summary>The context</summary>
        private readonly DistribuitorServiciiMobileContext context;

        /// <summary>Initializes a new instance of the <see cref="BonusRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public BonusRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
