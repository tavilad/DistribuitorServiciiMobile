namespace DistribuitorServiciiMobile.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>Database context class</summary>
    public partial class DistribuitorServiciiMobileContext : DbContext
    {
        /// <summary>Initializes a new instance of the <see cref="DistribuitorServiciiMobileContext" /> class.</summary>
        public DistribuitorServiciiMobileContext()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DistribuitorServiciiMobileContext" /> class.</summary>
        /// <param name="options">The options.</param>
        public DistribuitorServiciiMobileContext(DbContextOptions<DistribuitorServiciiMobileContext> options)
            : base(options)
        {
        }

        /// <summary>Gets or sets the abonament.</summary>
        /// <value>The abonament.</value>
        public virtual DbSet<Abonament> Abonament { get; set; }

        /// <summary>Gets or sets the client.</summary>
        /// <value>The client.</value>
        public virtual DbSet<Client> Client { get; set; }

        /// <summary>Gets or sets the minute.</summary>
        /// <value>The minute.</value>
        public virtual DbSet<Minute> Minute { get; set; }

        /// <summary>Gets or sets the date mobile.</summary>
        /// <value>The date mobile.</value>
        public virtual DbSet<DateMobile> DateMobile { get; set; }

        /// <summary>Gets or sets the SMS.</summary>
        /// <value>The SMS.</value>
        public virtual DbSet<SMS> Sms { get; set; }

        /// <summary>Gets or sets the contract.</summary>
        /// <value>The contract.</value>
        public virtual DbSet<Contract> Contract { get; set; }

        /// <summary>Gets or sets the bonus.</summary>
        /// <value>The bonus.</value>
        public virtual DbSet<Bonus> Bonus { get; set; }

        /// <summary>
        ///   <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        ///   <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions">DbContextOptions</see> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured">IsConfigured</see> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)">OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)</see>.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">
        /// A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DistribuitorServiciiMobile;Trusted_Connection=True;");
            }
        }
    }
}
