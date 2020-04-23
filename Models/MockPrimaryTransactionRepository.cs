using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class MockPrimaryTransactionRepository : IPrimaryTransactionRepository
    {
        List<PrimaryTransaction> _transactionsList { get; set; }

        public MockPrimaryTransactionRepository()
        {
            _transactionsList = new List<PrimaryTransaction>();
            _transactionsList.Add( new PrimaryTransaction() {
            });





        }
        public PrimaryTransaction Add(PrimaryTransaction primaryTransaction)
        {
            primaryTransaction.Id = _transactionsList.Max(e => e.Id) + 1;
            _transactionsList.Add(primaryTransaction);
            return primaryTransaction;
        }

        public PrimaryTransaction Delete(int id)
        {
            PrimaryTransaction primaryTransaction = _transactionsList.FirstOrDefault(e => e.Id == id);
            if (primaryTransaction != null)
            {
                _transactionsList.Remove(primaryTransaction);
            }
            return primaryTransaction;
        }

        public IEnumerable<PrimaryTransaction> GetAllPrimaryTransaction()
        {
            return _transactionsList;
        }

        public PrimaryTransaction GetPrimaryTransaction(int Id)
        {
            return _transactionsList.FirstOrDefault(e => e.Id == Id);
        }


        public IEnumerable<PrimaryTransaction> GetPrimaryTransactionsByUser(ApplicationUser user)
        {
            return _transactionsList;
        }

        public List<PrimaryTransaction> GetPrimaryTransactionsByUserId(string user)
        {
            return _transactionsList;
        }  




        

      

      
    }
}
