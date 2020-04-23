using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class MockTransactionRepository : ITransactionRepository
    {
        public List<Transaction> _listTransaction { get; set; }

        public MockTransactionRepository()
        {
            _listTransaction = new List<Transaction>();
        }
        public Transaction Add(Transaction transaction)
        {
            _listTransaction.Add(transaction);
            return transaction;
        }

        public IEnumerable<Transaction> GetAllTransaction()
        {
            return _listTransaction;
        }



        public IEnumerable<Transaction> GetByUser(ApplicationUser user)
        {
            return _listTransaction;
        }

        public Transaction GetTransaction(int Id)
        {
            return _listTransaction.FirstOrDefault(e => e.Id == Id);
        }
    }
}
