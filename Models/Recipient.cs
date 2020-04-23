using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class Recipient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string AccountNumber { get; set; }
        private string Description { get; set; }
        public ApplicationUser user { get; set; }

      
    }
}
