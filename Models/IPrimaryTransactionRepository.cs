using BankManagement.Models;
using System.Collections.Generic;

namespace BankManagement.Models
{
    public interface IPrimaryTransactionRepository
    {
        PrimaryTransaction GetPrimaryTransaction(int Id);
        IEnumerable<PrimaryTransaction> GetAllPrimaryTransaction();
        PrimaryTransaction Add(PrimaryTransaction primaryTransaction);
       // PrimaryTransaction Update(PrimaryTransaction primaryTransactionChanges);
        PrimaryTransaction Delete(int id);
      //  PrimaryTransaction GetPrimaryTransactionByUser(string id);
        IEnumerable<PrimaryTransaction> GetPrimaryTransactionsByUser(ApplicationUser user);
       // List<PrimaryTransaction> GetPrimaryTransactionsByUserId(string user);

    }
}