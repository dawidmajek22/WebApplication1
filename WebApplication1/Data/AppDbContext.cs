using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hodowca> Hodowca { get; set; }
        public DbSet<Hodowla> Hodowla { get; set; }
        public DbSet<HodowcaHodowlaView> HodowcaHodowlaView { get; set; }
        public DbSet<HodowcaHodowlaView> Adres { get; set; }
        public DbSet<HodowcaHodowlaView> HodowlaAdres { get; set; }
        public DbSet<Hod_Rasy> Hod_Rasy { get; set; }
        public DbSet<klasa_lookup> klasa_lookup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<HodowcaHodowlaView>()
                .HasNoKey() // bo widok nie ma klucza głównego
                .ToView("vw_HodowcaHodowla"); // nazwa widoku w SQL

            modelBuilder
                .Entity<Hodowla>()
                .HasOne(h => h.Hodowca)
                .WithMany()
                .HasForeignKey(h => h.IdHodowcy);
        }
    }
        
}
