using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        Id = "fsdfsdfsdfsdf",
                        UserName="serguei",
                        Email = "serguei1@gmail.com",
                        PasswordHash = "fsdhfjkqhldjfhsldfjksdhlq",
                        EmailConfirmed= true,
                        City ="Paris",
                    }
                   
                );

            modelBuilder.Entity<PrimaryAccount>().HasData(
                   new PrimaryAccount
                   {
                       Id = 1,
                       Balance = new decimal(787987),
                       UserRef= "fsdfsdfsdfsdf",
                       CreatedOn = DateTime.Now,
                       Name="PAccount Serguei"
                   }
                 
               );

            modelBuilder.Entity<SavingsAccount>().HasData(
                   new SavingsAccount
                   {
                       Id = 1,
                       Balance = new decimal(7987),
                       UserRef = "fsdfsdfsdfsdf",
                       CreatedOn= DateTime.Now,
                       Name = "SAccount Serguei"
                   }

               );
        }
    }
}
