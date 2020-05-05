using Microsoft.EntityFrameworkCore;

namespace DistribuitorServiciiMobile.Models
{
    public partial class DistribuitorServiciiMobileContext : DbContext
    {
        public DistribuitorServiciiMobileContext()
        {
        }

        public DistribuitorServiciiMobileContext(DbContextOptions<DistribuitorServiciiMobileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonament> Abonament { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Minute> Minute { get; set; }
        public virtual DbSet<DateMobile> DateMobile { get; set; }
        public virtual DbSet<SMS> Sms { get; set;}
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Bonus> Bonus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DistribuitorServiciiMobile;Trusted_Connection=True;");
            }
        }
    }
}
