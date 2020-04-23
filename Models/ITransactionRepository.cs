using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public interface ITransactionRepository
    { 



    IEnumerable<Transaction> GetAllTransaction();
    Transaction Add(Transaction transaction);

    Transaction GetTransaction(int Id);

    //  SavingsTransaction Update(SavingsTransaction savingsTransaction);
    //  SavingsTransaction Delete(int id);
    //  SavingsTransaction GetSavingsTransactiontByUser(string id);
    IEnumerable<Transaction> GetByUser(ApplicationUser user);
    }
}
