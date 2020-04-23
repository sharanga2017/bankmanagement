namespace BankManagement.Models
{


    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class SavingsAccount
    {

        public int Id { get; set; }

        [NotMapped]
        public string EncryptedId { get; set; }


        [Required]

        public string Name { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public int UniqueId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string UserRef { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<SavingsTransaction> Transactions { get; set; }
    }
}
