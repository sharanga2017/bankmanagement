using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.ViewModels
{
    public class PrimaryAccountDetailsViewModel
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
    }
}
