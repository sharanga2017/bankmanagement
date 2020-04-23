using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
       // public bool enabled { get; set; } = true;
        public string City { get; set; }
        public PrimaryAccount PrimaryAccount { get; set; }
        public SavingsAccount SavingsAccount { get; set; }


    }
}
