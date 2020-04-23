using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagement.Models;

namespace BankManagement.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        

        public DbSet<PrimaryAccount> PrimaryAccounts { get; set; }

        public DbSet<SavingsAccount> SavingsAccounts { get; set; }


        public DbSet<PrimaryTransaction> PrimaryTransactions { get; set; }

        public DbSet<SavingsTransaction> SavingsTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
          .HasOne(u => u.PrimaryAccount)
          .WithOne(p => p.User)
          .HasForeignKey<PrimaryAccount>(p => p.UserRef);

            modelBuilder.Entity<ApplicationUser>()
          .HasOne(u => u.SavingsAccount)
          .WithOne(p => p.User)
          .HasForeignKey<SavingsAccount>(p => p.UserRef);



            modelBuilder.Entity<PrimaryAccount>()
        .HasMany(p => p.Transactions)
        .WithOne(t => t.PrimaryAccount);


            modelBuilder.Entity<SavingsAccount>()
       .HasMany(p => p.Transactions)
       .WithOne(t => t.SavingsAccount);



            modelBuilder.Seed();

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        public DbSet<BankManagement.Models.Transaction> Transaction { get; set; }
    }
}
