using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public interface IPrimaryAccountRepository
    {
        PrimaryAccount GetPrimaryAccount(int Id);

        IEnumerable<PrimaryAccount> GetAllPrimaryAccount();
        PrimaryAccount Add(PrimaryAccount primaryAccount);
        PrimaryAccount Update(PrimaryAccount primaryAccountChanges);
        PrimaryAccount Delete(int id);
        PrimaryAccount GetPrimaryAccountByUser(string id);
        PrimaryAccount GetByUser(ApplicationUser user);
    }
}
