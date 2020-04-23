using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public enum AccountType
    {
        [Display(Name = "Primary Account")]
        PRIMARY,
        [Display(Name = "Savings Account")]
        SAVINGS
    }
}
