using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class SavingsTransaction :Transaction
    {

        

        public SavingsAccount SavingsAccount { get; set; }
    }
}
