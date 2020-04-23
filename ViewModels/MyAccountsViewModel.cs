using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.ViewModels
{
    public class MyAccountsViewModel
    {
        public string NamePrimary { get; set; }
        public string NameSavings { get; set; }

        public string PrimaryBalance { get; set; }
        public string SavingsBalance { get; set; }

        public string FullName { get; set; }
    }
}
