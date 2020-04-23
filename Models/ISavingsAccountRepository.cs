using System.Collections.Generic;

namespace BankManagement.Models
{
    public interface ISavingsAccountRepository
    {
         SavingsAccount GetSavingsAccount(int Id);

        IEnumerable<SavingsAccount> GetAllSavingsAccount();
        SavingsAccount Add(SavingsAccount savingsAccount);
        SavingsAccount Update(SavingsAccount savingsAccountChanges);
        SavingsAccount Delete(int id);
        SavingsAccount GetByUserId(string id);
        SavingsAccount GetByUser(ApplicationUser user);

    }
}