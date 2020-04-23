using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.services
{
    public interface ITransactionService
    {        
            IEnumerable<PrimaryTransaction> GetPrimaryTransactionList(ApplicationUser user);

            IEnumerable<SavingsTransaction> GetSavingsTransactionList(ApplicationUser user);

            void AddDepositTransaction(Transaction transaction);

           // void AddDepositTransaction(SavingsTransaction savingsTransaction);



            void AddWithdrawTransaction(Transaction Transaction);

           // void AddSavingsWithdrawTransaction(SavingsTransaction savingsTransaction);

            void AccountsTransfer(AccountType transferFrom, AccountType transferTo, decimal amount, PrimaryAccount primaryAccount, SavingsAccount savingsAccount);

           IEnumerable<Recipient> GetRecipientList(ApplicationUser userCurrent);

             Recipient GetRecipientById(String recipientId);

            void DeleteRecipientById(string recipientName);

           // void toSomeoneElseTransfer(Recipient recipient, AccountType accountType, decimal amount, PrimaryAccount primaryAccount, SavingsAccount savingsAccount);
        }

    }

