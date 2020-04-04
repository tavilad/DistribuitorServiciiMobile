using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<AbonamentMinute> AbonamentMinute { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Minute> Minute { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DistribuitorServiciiMobile;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abonament>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Abonament)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<AbonamentMinute>(entity =>
            {
                entity.HasIndex(e => e.AbonamentId);

                entity.HasIndex(e => e.MinuteId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Abonament)
                    .WithMany(p => p.AbonamentMinute)
                    .HasForeignKey(d => d.AbonamentId);

                entity.HasOne(d => d.Minute)
                    .WithMany(p => p.AbonamentMinute)
                    .HasForeignKey(d => d.MinuteId);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Minute>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
