using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class SQLSavingsAccountRepository : ISavingsAccountRepository
    {
        public AppDbContext _context { get; }
        public ILogger<SQLSavingsAccountRepository> _logger { get; }

        public SQLSavingsAccountRepository(AppDbContext context,
                                    ILogger<SQLSavingsAccountRepository> logger)
        {
            _context = context;
            _logger = logger;
        }



        public SavingsAccount Add(SavingsAccount savingsAccount)
        {
            _context.SavingsAccounts.Add(savingsAccount);
            _context.SaveChanges();
            return savingsAccount;
        }

        public SavingsAccount Delete(int id)
        {
            SavingsAccount savingsAccount = _context.SavingsAccounts.Find(id);
            if (savingsAccount != null)
            {
                _context.SavingsAccounts.Remove(savingsAccount);
                _context.SaveChanges();
            }
            return savingsAccount;
        }

        public IEnumerable<SavingsAccount> GetAllSavingsAccount()
        {
            return _context.SavingsAccounts;
        }

        public SavingsAccount GetSavingsAccount(int Id)
        {
            return _context.SavingsAccounts.Find(Id);
        }

        //public SavingsAccount GetSavingsAccountByUser(int Id)
        //{
        //    return _context.SavingsAccounts.FirstOrDefault(e => e.UserId == Id.ToString());
        //}

        public SavingsAccount Update(SavingsAccount savingsAccountChanges)
        {
            var primaryAccount = _context.SavingsAccounts.Attach(savingsAccountChanges);
            primaryAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return savingsAccountChanges;
        }

        public SavingsAccount GetByUser(ApplicationUser user)
        {
            return _context.SavingsAccounts.FirstOrDefault(e => e.User == user);
        }

        //public SavingsAccount GetByUser(string id)
        //{
        //    return _context.SavingsAccounts.FirstOrDefault(e => e.UserRef == id);
        //}

        public SavingsAccount GetByUserId(string id)
        {
            return _context.SavingsAccounts.FirstOrDefault(e => e.UserRef == id);
        }
    }
}
