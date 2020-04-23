using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class MockSavingsTransactionRepository : ISavingsTransactionRepository
    {
        List<SavingsTransaction> _transactionsList { get; set; }

        public MockSavingsTransactionRepository()
        {
            _transactionsList = new List<SavingsTransaction>();
            _transactionsList.Add(new SavingsTransaction());

        }
        public SavingsTransaction Add(SavingsTransaction savingsTransaction)
        {
            savingsTransaction.Id = _transactionsList.Max(e => e.Id) + 1;
            _transactionsList.Add(savingsTransaction);
            return savingsTransaction;
        }

        public IEnumerable<SavingsTransaction> GetAllSavingsTransaction()
        {
            return _transactionsList;
        }

        public IEnumerable<SavingsTransaction> GetByUser(ApplicationUser user)
        {
            return _transactionsList;
        }

        //public SavingsTransaction GetSavingsTransaction(int Id)
        //{
        //    return _transactionsList;
        //}
    }
}
