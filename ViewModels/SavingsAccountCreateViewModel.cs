using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.ViewModels
{
    public class SavingsAccountCreateViewModel
    {

        public string Name { get; set; }

        [Required]
        public decimal Balance { get; set; }



    }
}
