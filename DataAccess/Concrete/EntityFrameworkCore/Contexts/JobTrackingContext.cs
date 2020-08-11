using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.EntityFrameworkCore.Mappings;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class JobTrackingContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ASUSGL553VD\\ASUSROGSQLEXP;Database=JobTrackDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GorevMap());
            modelBuilder.ApplyConfiguration(new AciliyetMap());
            modelBuilder.ApplyConfiguration(new RaporMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<Aciliyet> Aciliyetler { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<Bildirim> Bildirimler { get; set; }
    }
}
