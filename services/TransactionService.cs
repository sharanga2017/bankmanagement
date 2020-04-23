using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagement.Models;

namespace BankManagement.services
{
    public class TransactionService : ITransactionService
    {
        private ISavingsAccountRepository _savingsAccountRepository;
        private IPrimaryAccountRepository _primaryAccountRepository;

        public TransactionService(ISavingsAccountRepository savingsAccountRepository,
                                //  ISavingsTransactionRepository savingsTransactionRepository,
                                  IPrimaryAccountRepository primaryAccountRepository,
                                  ITransactionRepository transactionRepository,
                                  IRecipientRepository recipientRepository)
        {
            _savingsAccountRepository = savingsAccountRepository;
           // _savingsTransactionRepository = savingsTransactionRepository;
            _primaryAccountRepository = primaryAccountRepository;
            _transactionRepository = transactionRepository;
            _recipientRepository = recipientRepository;
        }

     //   public ISavingsTransactionRepository _savingsTransactionRepository { get; }
        public ITransactionRepository _transactionRepository { get; }
        public IRecipientRepository _recipientRepository { get; }

        public void AccountsTransfer(AccountType transferFrom, AccountType transferTo, decimal amount, PrimaryAccount primaryAccount, SavingsAccount savingsAccount)
        {
            if (transferFrom == AccountType.PRIMARY && transferTo == AccountType.SAVINGS)
            {
                primaryAccount.Balance = primaryAccount.Balance - amount;


                savingsAccount.Balance = savingsAccount.Balance + amount;

                _primaryAccountRepository.Update(primaryAccount);
                _savingsAccountRepository.Update(savingsAccount);

                DateTime date = DateTime.Now;

                Transaction primaryTransaction = new PrimaryTransaction()
                {
                    Date = date,
                    TransactionType = TransactionType.ACCOUNT,
                    Amount = amount,
                    Description= "Transfert from Primary to Savings Account",
                    AvailableBalance = primaryAccount.Balance,
                    Status = "finished",
                    PrimaryAccount = primaryAccount,
                    TransactionAccountType = TransactionAccountType.PrimaryAccount

                };

                _transactionRepository.Add(primaryTransaction);

               // return true;
            }

            else if (transferFrom == AccountType.SAVINGS && transferTo == AccountType.PRIMARY)
                {
                    savingsAccount.Balance = savingsAccount.Balance - amount;


                    primaryAccount.Balance = primaryAccount.Balance + amount;

                    _primaryAccountRepository.Update(primaryAccount);
                    _savingsAccountRepository.Update(savingsAccount);

                    DateTime date = DateTime.Now;

                    SavingsTransaction savingsTransaction = new SavingsTransaction()
                    {
                        Date = date,
                        TransactionType = TransactionType.ACCOUNT,
                        Description= "Transfert from Savings to Primary Account",
                        Amount = amount,
                        AvailableBalance = savingsAccount.Balance,
                        Status = "finished",
                        SavingsAccount = savingsAccount,
                        TransactionAccountType = TransactionAccountType.SavingsAccount

                    };

                    _transactionRepository.Add(savingsTransaction);
               // return true;
                }

            
               // throw new Exception("Invalid Transfer");
           

        }

        public IEnumerable<Transaction> GetPrimaryTransactionList(ApplicationUser user)
        {
            return _transactionRepository.GetByUser(user);
        }



        public Recipient GetRecipientById(int recipientId)
        {
            return _recipientRepository.GetRecipient(recipientId);
        }

        public IEnumerable<Transaction> GetSavingsTransactionList(ApplicationUser user)
        {
            return _transactionRepository.GetByUser(user);
        }

        //public void AddPrimaryDepositTransaction(PrimaryTransaction primaryTransaction)
        //{
        //    _primaryTransactionRepository.Add(primaryTransaction);
        //}

        public void AddWithdrawTransaction(Transaction transaction)
        {
            _transactionRepository.Add(transaction);
        }

        public Recipient AddRecipient(Recipient recipient)
        {
            return _recipientRepository.Add(recipient);

        }

        public void AddDepositTransaction(Transaction transaction)
        {
            _transactionRepository.Add(transaction);
        }

        //public void AddSavingsWithdrawTransaction(SavingsTransaction savingsTransaction)
        //{
        //    _savingsTransactionRepository.Add(savingsTransaction);
        //}

        //public void toSomeoneElseTransfer(Recipient recipient, AccountType accountType, decimal amount, PrimaryAccount primaryAccount, SavingsAccount savingsAccount)
        //{
        //    if (accountType == AccountType.PRIMARY)
        //    {
        //        primaryAccount.Balance = primaryAccount.Balance - amount;
        //        _primaryAccountRepository.Update(primaryAccount);

        //        DateTime date = DateTime.Now;

        //        PrimaryTransaction primaryTransaction = new PrimaryTransaction()
        //        {
        //            Date = DateTime.Now,
        //            Description = "Transfer to recipient " + recipient.Name,
        //            Amount = amount,
        //            AvailableBalance = primaryAccount.Balance,
        //            PrimaryAccount = primaryAccount,

        //        };             
                    
                 
        //        _primaryTransactionRepository.Add(primaryTransaction);
        //    }
        //    else if (accountType == AccountType.SAVINGS)
        //    {
        //        savingsAccount.Balance = savingsAccount.Balance - amount;
        //        _savingsAccountRepository.Update(savingsAccount);

        //        DateTime date = DateTime.Now;

        //        SavingsTransaction savingsTransaction = new SavingsTransaction()
        //        {
        //            Date = DateTime.Now,
        //            Description = "Transfer to recipient " + recipient.Name,
        //            Amount = amount,
        //            AvailableBalance = primaryAccount.Balance,
        //            SavingsAccount = savingsAccount,

        //        };
        //    }
        //}

       

        public IEnumerable<Recipient> GetRecipientList(ApplicationUser userCurrent)
        {
            throw new NotImplementedException();
        }

        public Recipient GetRecipientById(string recipientId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipientById(string recipientName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PrimaryTransaction> ITransactionService.GetPrimaryTransactionList(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        IEnumerable<SavingsTransaction> ITransactionService.GetSavingsTransactionList(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
