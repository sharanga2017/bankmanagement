using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BankManagement.Models
{
    public interface ISavingsTransactionRepository
    {

      //  SavingsTransaction GetSavingsTransaction(int Id);
        IEnumerable<SavingsTransaction> GetAllSavingsTransaction();
        SavingsTransaction Add(SavingsTransaction savingsTransaction);
      //  SavingsTransaction Update(SavingsTransaction savingsTransaction);
      //  SavingsTransaction Delete(int id);
      //  SavingsTransaction GetSavingsTransactiontByUser(string id);
        IEnumerable<SavingsTransaction> GetByUser(ApplicationUser user);
    }
}
