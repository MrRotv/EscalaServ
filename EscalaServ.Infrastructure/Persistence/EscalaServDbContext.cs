using EscalaServ.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Infrastructure.Persistence
{
    public class EscalaServDbContext : DbContext
    {
        public EscalaServDbContext(DbContextOptions<EscalaServDbContext> options) : base(options)
        {
           
        }
        public DbSet<Military> Military { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TradeRequest> TradeRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Military>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Military>()
                .HasMany(p => p.TradesRequests);


            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
               .HasMany(p => p.TradesRequests)
               .WithOne(p => p.MilitaryUser)
               .HasForeignKey(p => p.MilitaryId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TradeRequest>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<TradeRequest>()
                .HasOne(p => p.MilitaryUser)
                .WithMany(p => p.TradesRequests)
                .HasForeignKey(p => p.UserId)
                .HasForeignKey(p => p.MilitaryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
