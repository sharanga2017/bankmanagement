using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class MockSavingsAccountRepository : ISavingsAccountRepository
    {
        private List<SavingsAccount> _accountsList;

        private static int UniqueId = 11223145;


        private int accountGen()
        {
            return ++UniqueId;
        }
        public MockSavingsAccountRepository()
        {
            _accountsList = new List<SavingsAccount>()
            {
                new SavingsAccount() { Id = 1, Name = "Serguei", Balance = new decimal(0.0), UniqueId = accountGen(), CreatedOn = DateTime.Now},
                new SavingsAccount() {Id = 1, Name = "Philippes", Balance = new decimal(0.0), UniqueId = accountGen(), CreatedOn = DateTime.Now},
                new SavingsAccount() { Id = 1, Name = "Cedric", Balance = new decimal(0.0), UniqueId = accountGen(), CreatedOn = DateTime.Now},
            };
        }



        public SavingsAccount Add(SavingsAccount account)
        {
            account.Id = _accountsList.Max(e => e.Id) + 1;
            _accountsList.Add(account);
            return account;
        }






        public SavingsAccount Delete(int id)
        {
            SavingsAccount account = _accountsList.FirstOrDefault(e => e.Id == id);
            if (account != null)
            {
                _accountsList.Remove(account);
            }
            return account;
        }



       

        public SavingsAccount GetSavingsAccount(int Id)
        {
            return _accountsList.FirstOrDefault(e => e.Id == Id);
        }


        //public SavingsAccount GetSavingsAccountByUser(int Id)
        //{
        //    return _accountsList.FirstOrDefault(e => e.UserId == Id.ToString());
        //}



        public SavingsAccount Update(SavingsAccount accountChanges)
        {
            SavingsAccount Newaccount = accountChanges;
            SavingsAccount account = _accountsList.FirstOrDefault(e => e.Id == accountChanges.Id);
            if (account != null)
            {               
                account.Balance = accountChanges.Balance;
                account.Name = accountChanges.Name;
                account.CreatedOn = accountChanges.CreatedOn;
                
            }
            return account;
        }

      

        public IEnumerable<SavingsAccount> GetAllSavingsAccount()
        {
            return _accountsList;
        }

        public SavingsAccount GetByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public SavingsAccount GetByUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
