namespace DataMapper
{
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;

    /// <summary>Repository class for the SMS entity</summary>
    public class SmsRepository : BaseRepository<SMS>, ISmsRepository
    {
        /// <summary>The context</summary>
        private readonly DistribuitorServiciiMobileContext context;

        /// <summary>Initializes a new instance of the <see cref="SmsRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public SmsRepository(DistribuitorServiciiMobileContext context) : base(context)
        {
            this.context = context;
        }
    }
}
