using System.ComponentModel.DataAnnotations;

namespace BankManagement.Models
{
    public enum TransactionAccountType
    {
        [Display(Name = "From Primary Account")]
        PrimaryAccount,
        [Display(Name = "From Savings Account")]
        SavingsAccount

    }
}