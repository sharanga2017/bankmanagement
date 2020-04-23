using System;
using BankManagement.Models;
using BankManagement.Security;
using Microsoft.AspNetCore.Identity;


namespace BankManagement.services
{
    public class AccountService : IAccountService
    {

        public AccountService(IPrimaryAccountRepository primaryAccountRepository, 
            ISavingsAccountRepository savingsAccountRepository,
            IPCommon pCommon,
            UserManager<ApplicationUser> userManager,
            ITransactionService transactionService)
        {
            _primaryAccountRepository = primaryAccountRepository;
            _savingsAccountRepository = savingsAccountRepository;
            _pCommon = pCommon;
            this.userManager = userManager;
            _transactionService = transactionService;
        }

        public IPrimaryAccountRepository _primaryAccountRepository { get; }
        public IPCommon _pCommon { get; }
        public UserManager<ApplicationUser> userManager { get; }
        public ITransactionService _transactionService { get; }
        private ISavingsAccountRepository _savingsAccountRepository { get; }



        public PrimaryAccount CreatePrimaryAccount()
        {
            PrimaryAccount primaryAccount = new PrimaryAccount()
            {
                Balance = new decimal(0.0),
                CreatedOn = DateTime.Now,
                Name = "PRIMARY ACCOUNT",
                UserRef = _pCommon.getUserId(),
                UniqueId = 435354,
            };


           return  _primaryAccountRepository.Add(primaryAccount);
      
            
            
        }

        public SavingsAccount CreateSavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount()
            {
                Balance = new decimal(0.0),
                CreatedOn = DateTime.Now,
                Name = "SAVINGS ACCOUNT",
                UserRef = _pCommon.getUserId(),
                UniqueId = 435354,
            };


            return _savingsAccountRepository.Add(savingsAccount);
          

        }

        public void Deposit(AccountType accountType, decimal amount, ApplicationUser user)
        {
             


            if (accountType == AccountType.PRIMARY)
            {
                PrimaryAccount primaryAccount = _primaryAccountRepository.GetByUser(user);
               
                primaryAccount.Balance = primaryAccount.Balance + amount;
                
                _primaryAccountRepository.Update(primaryAccount);

                DateTime created = DateTime.Now;

                Transaction primaryTransaction = new Transaction()

                {
                    Date = created,
                    Description = "Deposit to Primary Account",
                    Status = "Finished",
                   AvailableBalance = primaryAccount.Balance,
                   Amount = amount,
                   TransactionAccountType= TransactionAccountType.PrimaryAccount,
                   TransactionType =TransactionType.DEPOT,

            };


                _transactionService.AddDepositTransaction(primaryTransaction);

            }
            else if (accountType == AccountType.SAVINGS)
            {
                SavingsAccount savingsAccount = _savingsAccountRepository.GetByUser(user);
                
                savingsAccount.Balance = savingsAccount.Balance + amount;

                _savingsAccountRepository.Update(savingsAccount);

                DateTime created = DateTime.Now;

                SavingsTransaction savingsTransaction = new SavingsTransaction()

                {
                    Date = created,
                    Description = "Deposit to Savings Account",
                    Status = "Finished",
                    AvailableBalance = savingsAccount.Balance,
                    Amount = amount,
                    SavingsAccount = savingsAccount,
                    TransactionType = TransactionType.DEPOT,
                    TransactionAccountType = TransactionAccountType.SavingsAccount
                };


                _transactionService.AddDepositTransaction(savingsTransaction);

            }
        }

        public void Withdraw(AccountType accountType, decimal amount, ApplicationUser user)
        {



            if (accountType == AccountType.PRIMARY)
            {
                PrimaryAccount primaryAccount = _primaryAccountRepository.GetByUser(user);
                decimal AvailableBalance = primaryAccount.Balance;
                primaryAccount.Balance = primaryAccount.Balance - amount;

                _primaryAccountRepository.Update(primaryAccount);

                DateTime created = DateTime.Now;

                Transaction primaryTransaction = new Transaction()

                {
                    Date = created,
                    Description = "Withdraw from Primary Account",
                    Status = "Finished",
                    AvailableBalance = primaryAccount.Balance,
                    Amount = amount,
                    TransactionType = TransactionType.RETRET,
                    TransactionAccountType = TransactionAccountType.PrimaryAccount
                };


                _transactionService.AddDepositTransaction(primaryTransaction);

            }
            else if (accountType == AccountType.SAVINGS)
            {
                SavingsAccount savingsAccount = _savingsAccountRepository.GetByUser(user);
                decimal AvailableBalance = savingsAccount.Balance;
                savingsAccount.Balance = savingsAccount.Balance - amount;

                _savingsAccountRepository.Update(savingsAccount);

                DateTime created = DateTime.Now;

                SavingsTransaction savingsTransaction = new SavingsTransaction()

                {
                    Date = created,
                    Description = "Withdraw from Savings Account",
                    Status = "Finished",
                    AvailableBalance = savingsAccount.Balance,
                    Amount = amount,
                    SavingsAccount = savingsAccount,
                    TransactionType = TransactionType.RETRET,
                    TransactionAccountType = TransactionAccountType.SavingsAccount
                };


                _transactionService.AddDepositTransaction(savingsTransaction);

            }
        }
    }
}
