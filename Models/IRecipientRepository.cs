using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public interface IRecipientRepository
    {
         Recipient GetRecipient(int Id);
        
        IEnumerable<Recipient> GetAllRecipients();
        Recipient Add(Recipient recipient);
        Recipient Update(Recipient recipient);
        Recipient Delete(int id);
       // Recipient DeleteByName(string name);
        IEnumerable<Recipient> GetRecipientsByUserId(string id);
       // Recipient GetByUser(ApplicationUser user);
    }
}
