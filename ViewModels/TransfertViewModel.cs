using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.ViewModels
{
    public class TransfertViewModel
    {

        public AccountType AccountTypeFrom { get; set; }

        public AccountType AccountTypeTo { get; set; }

        public decimal Montant { get; set; }



    }
}
