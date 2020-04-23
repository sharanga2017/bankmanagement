using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.services
{
    public interface IAccountService
    {
        PrimaryAccount CreatePrimaryAccount();
        SavingsAccount CreateSavingsAccount();
        void Deposit(AccountType accountType, decimal amount, ApplicationUser user);
        void Withdraw(AccountType accountType, decimal amount, ApplicationUser user);
    }
}
