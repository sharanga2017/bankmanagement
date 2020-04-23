using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class SQLPrimaryAccountRepository : IPrimaryAccountRepository
    {
        public AppDbContext _context { get; }
        public ILogger<SQLPrimaryAccountRepository> _logger { get; }

        public SQLPrimaryAccountRepository(AppDbContext context,
                                    ILogger<SQLPrimaryAccountRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        

        public PrimaryAccount Add(PrimaryAccount primaryAccount)
        {
            _context.PrimaryAccounts.Add(primaryAccount);
            _context.SaveChanges();
            return primaryAccount;
        }

        public PrimaryAccount Delete(int id)
        {
            PrimaryAccount primaryAccount = _context.PrimaryAccounts.Find(id);
            if (primaryAccount != null)
            {
                _context.PrimaryAccounts.Remove(primaryAccount);
                _context.SaveChanges();
            }
            return primaryAccount;
        }

        public IEnumerable<PrimaryAccount> GetAllPrimaryAccount()
        {
            return _context.PrimaryAccounts;
        }

        public PrimaryAccount GetPrimaryAccount(int Id)
        {
           
            return _context.PrimaryAccounts.Find(Id);
        }

       

        public PrimaryAccount Update(PrimaryAccount primaryAccountChanges)
        {
            var primaryAccount = _context.PrimaryAccounts.Attach(primaryAccountChanges);
            primaryAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return primaryAccountChanges;
        }

        public PrimaryAccount GetPrimaryAccountByUser(string id)
        {
            return _context.PrimaryAccounts.FirstOrDefault(e => e.UserRef == id);
        }

        public PrimaryAccount GetByUser(ApplicationUser user)
        {
            return _context.PrimaryAccounts.FirstOrDefault(e => e.User == user);
        }
    }
}
