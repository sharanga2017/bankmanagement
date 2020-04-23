using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public TransactionType? TransactionType { get; set; }

        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public decimal AvailableBalance;

        public string Type { get; set; }

        public string Status { get; set; }

        public TransactionAccountType TransactionAccountType { get; set; }
    }
}
