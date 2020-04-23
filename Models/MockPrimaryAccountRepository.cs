using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class MockPrimaryAccountRepository : IPrimaryAccountRepository
    {
        private List<PrimaryAccount> _accountsList;

        private static int UniqueId = 11223145;


        private int accountGen()
        {
            return ++UniqueId;
        }
        public MockPrimaryAccountRepository()
        {
            _accountsList = new List<PrimaryAccount>()
            {
                new PrimaryAccount() { Id = 1, Name = "Serguei", Balance = new decimal(0.0), UniqueId = accountGen(), CreatedOn = DateTime.Now,},
                new PrimaryAccount() {Id = 1, Name = "Philippes", Balance = new decimal(0.0), UniqueId = accountGen(), CreatedOn = DateTime.Now},
                new PrimaryAccount() { Id = 1, Name = "Cedric", Balance = new decimal(0.0), UniqueId = accountGen(), CreatedOn = DateTime.Now,},
            };
        }



        public PrimaryAccount Add(PrimaryAccount account)
        {
            account.Id = _accountsList.Max(e => e.Id) + 1;
            _accountsList.Add(account);
            return account;
        }






        public PrimaryAccount Delete(int id)
        {
            PrimaryAccount account = _accountsList.FirstOrDefault(e => e.Id == id);
            if (account != null)
            {
                _accountsList.Remove(account);
            }
            return account;
        }



        public IEnumerable<PrimaryAccount> GetAllPrimaryAccount()
        {
            return _accountsList;
        }

        public PrimaryAccount GetPrimaryAccount(int Id)
        {
            return _accountsList.FirstOrDefault(e => e.Id == Id);
        }


        //public PrimaryAccount GetPrimaryAccountByUser(int Id)
        //{
        //   // return _accountsList.FirstOrDefault(e => e.UserId == Id.ToString());
        //}



        public PrimaryAccount Update(PrimaryAccount accountChanges)
        {
            PrimaryAccount account = _accountsList.FirstOrDefault(e => e.Id == accountChanges.Id);
            if (account != null)
            {
                
            }
            return account;
        }

        public PrimaryAccount GetPrimaryAccountByUser(int id)
        {
            throw new NotImplementedException();
        }

        public PrimaryAccount GetPrimaryAccountByUser(string id)
        {
            throw new NotImplementedException();
        }

        public PrimaryAccount GetByUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}