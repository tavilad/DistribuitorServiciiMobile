namespace DataMapper
{
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;

    /// <summary>Repository class for the DateMobile entity</summary>
    public class DateRepository : BaseRepository<DateMobile>, IDateRepository
    {
        /// <summary>The context</summary>
        private readonly DistribuitorServiciiMobileContext context;

        /// <summary>Initializes a new instance of the <see cref="DateRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public DateRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
