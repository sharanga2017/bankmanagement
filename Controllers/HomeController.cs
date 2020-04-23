using AutoMapper;
using BankManagement.Models;
using BankManagement.Security;
using BankManagement.services;
using BankManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;
        private readonly IDataProtector protector;

        public IPrimaryAccountRepository _primaryAccountRepository { get; }
        public ISavingsAccountRepository _savingsAccountRepository { get; }
        public IMapper _mapper { get; }
        public UserManager<ApplicationUser> _userManager { get; }
        public ITransactionService _transactionService { get; }
        public IAccountService _accountService { get; }
        public IPrimaryTransactionRepository _primaryTransactionRepository { get; }
        public ISavingsTransactionRepository _savingsTransactionRepository { get; }
        public ITransactionRepository _transactionRepository { get; }

        private readonly IPCommon _pCommon;

        public IHttpContextAccessor _httpContextAccessor { get; }

        public HomeController(
                              IPrimaryAccountRepository primaryAccountRepository,
                              ISavingsAccountRepository savingsAccountRepository,
                              IHostingEnvironment hostingEnvironment,
                              ILogger<HomeController> logger,
                              IDataProtectionProvider dataProtectionProvider,
                              DataProtectionPurposeStrings dataProtectionPurposeStrings,
                              IPCommon pCommon,
                              IMapper mapper,
                              UserManager<ApplicationUser> userManager,
                              ITransactionService transactionService,
                              IAccountService accountService,
                              IPrimaryTransactionRepository primaryTransactionRepository,
                              ISavingsTransactionRepository savingsTransactionRepository,
                              ITransactionRepository transactionRepository)
        {
            
            _primaryAccountRepository = primaryAccountRepository;
            _savingsAccountRepository = savingsAccountRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
            _pCommon = pCommon;
            _mapper = mapper;
            _userManager = userManager;
            _transactionService = transactionService;
            _accountService = accountService;
            _primaryTransactionRepository = primaryTransactionRepository;
            _savingsTransactionRepository = savingsTransactionRepository;
            _transactionRepository = transactionRepository;
            
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction("MyAccounts");
           // return View();
        }

        [AllowAnonymous]
        public IActionResult MyHome()
        {
           
             return View();
        }


        [AllowAnonymous]
        public ViewResult Accounts()
        {
            var model = _primaryAccountRepository.GetAllPrimaryAccount()
                            .Select(e =>
                            {
                                e.EncryptedId = protector.Protect(e.Id.ToString());
                                return e;
                            });
            return View(model);
        }




        
        public async Task<ViewResult> AccountUser()
        {
          // string userId = _pCommon.getUserId();

            ApplicationUser user = await _userManager.GetUserAsync(User);

            FrontUserViewModel frontUserViewModel = new FrontUserViewModel();

            PrimaryAccount primaryAccount =_primaryAccountRepository.GetByUser(user);
            SavingsAccount savingsAccount = _savingsAccountRepository.GetByUser(user);


            if(primaryAccount!= null)
            {
                frontUserViewModel.BalancePrimary = primaryAccount.Balance.ToString();
                frontUserViewModel.NamePA = primaryAccount.Name;
            }
            
            if(savingsAccount != null)
            {
                frontUserViewModel.BalanceSavings = savingsAccount.Balance.ToString();

                frontUserViewModel.NameSA = savingsAccount.Name;

            }
          
            
           



            return View(frontUserViewModel);
        }


        public ViewResult Account(int Id)
        {
            var model = _primaryAccountRepository.GetPrimaryAccount(Id);

            return View(model);
        }

        
        [HttpGet]
        public ViewResult CreatePrimaryAccount()
        {
            
            return View();
        }

       

              
        [HttpPost]
        public IActionResult CreatePrimaryAccount(PrimaryAccountCreateViewModel model)
        {
           
            
            if (ModelState.IsValid)
            {

                PrimaryAccount primaryAccount = _mapper.Map<PrimaryAccount>(model);
                primaryAccount.CreatedOn = DateTime.Now;
                primaryAccount.UserRef = _pCommon.getUserId();
                            

                 _primaryAccountRepository.Add(primaryAccount);

                return RedirectToAction("accounts");
            }

            

            return View();
        }


        

     



       
        public ViewResult DetailsPrimaryAccount(int id)
        {
            //throw new Exception("Error in Details View");

            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

            //  int primaryAccountId = Convert.ToInt32(protector.Unprotect(id.ToString()));
            int primaryAccountId = id;
            PrimaryAccount primaryAccount = _primaryAccountRepository.GetPrimaryAccount(primaryAccountId);

            if (primaryAccount == null)
            {
                Response.StatusCode = 404;
                return View("PrimaryNotFound", primaryAccountId);
            }

            PrimaryAccountDetailsViewModel homeDetailsViewModel = new PrimaryAccountDetailsViewModel()
            {
                Id = id,
                Balance = primaryAccount.Balance,
                Name = primaryAccount.Name
            };

            return View(homeDetailsViewModel);
        }

        
        [HttpGet]
        public ViewResult EditPrimaryAccount(int id)
        {
            PrimaryAccount primaryAccount = _primaryAccountRepository.GetPrimaryAccount(id);
            PrimaryAccountEditViewModel primaryAccountEditViewModel = _mapper.Map<PrimaryAccountEditViewModel>(primaryAccount);
            return View(primaryAccountEditViewModel);
        }


        
        [HttpPost]
        public IActionResult EditPrimaryAccount(PrimaryAccountEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                PrimaryAccount primaryAccount = _mapper.Map<PrimaryAccount>(model);
                _primaryAccountRepository.Update(primaryAccount);
                return RedirectToAction("Accounts");
            }

            return View();
        }





        public async Task<IActionResult> MyAccounts()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            SavingsAccount savingsAccount = _savingsAccountRepository.GetByUser(user);

            
            PrimaryAccount primaryAccount = _primaryAccountRepository.GetByUser(user);

            if(primaryAccount ==null && savingsAccount == null)
            {

                return RedirectToAction("MyHome");
            }

            MyAccountsViewModel account = new MyAccountsViewModel();
            account.FullName = user.Email;

            if (savingsAccount!= null)
            {
                account.NameSavings = savingsAccount.Name;

                account.SavingsBalance = savingsAccount.Balance.ToString();
            }

            if (primaryAccount != null)
            {

                account.NamePrimary = primaryAccount.Name;

                account.PrimaryBalance = primaryAccount.Balance.ToString();

            }
            return View(account);
        }



        [HttpGet]
        public IActionResult Transfert()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Transfert(TransfertViewModel transfertViewModel)
        {
            AccountType transferFrom = transfertViewModel.AccountTypeFrom;
            AccountType transferTo = transfertViewModel.AccountTypeTo;
            decimal amount = transfertViewModel.Montant;
            ApplicationUser user =  await _userManager.GetUserAsync(User);
            PrimaryAccount primaryAccount = _primaryAccountRepository.GetByUser(user);
            SavingsAccount savingsAccount = _savingsAccountRepository.GetByUser(user);


            _transactionService.AccountsTransfer(transferFrom, transferTo, amount, primaryAccount, savingsAccount);

            PrimaryAccount primaryAccount2 = user.PrimaryAccount;
            SavingsAccount savingsAccount2 = user.SavingsAccount;

            return RedirectToAction("MyAccounts");
        }




        [HttpGet]
        public IActionResult Deposit()
        {

            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Deposit(DepositViewModel depositViewModel)
        {
            AccountType depositType = depositViewModel.AccountTypeTo;
           
            decimal amount = depositViewModel.Montant;

            ApplicationUser user = await _userManager.GetUserAsync(User);



            PrimaryAccount primaryAccount = _primaryAccountRepository.GetByUser(user);
            SavingsAccount savingsAccount = _savingsAccountRepository.GetByUser(user);


            _accountService.Deposit(depositType, amount, user);

            PrimaryAccount primaryAccount2 = user.PrimaryAccount;
            SavingsAccount savingsAccount2 = user.SavingsAccount;

            return RedirectToAction("MyAccounts");
        }




        [HttpGet]
        public IActionResult Wizdraw()
        {

            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Wizdraw(WizdrawViewModel wizdrawViewModel)
        {
            AccountType wizdrawType = wizdrawViewModel.AccountTypeFrom;

            decimal amount = wizdrawViewModel.Montant;

            ApplicationUser user = await _userManager.GetUserAsync(User);



            PrimaryAccount primaryAccount = _primaryAccountRepository.GetByUser(user);
            SavingsAccount savingsAccount = _savingsAccountRepository.GetByUser(user);


            _accountService.Withdraw(wizdrawType, amount, user);

            PrimaryAccount primaryAccount2 = user.PrimaryAccount;
            SavingsAccount savingsAccount2 = user.SavingsAccount;

            return RedirectToAction("MyAccounts");
        }




        [HttpGet]
        public IActionResult ListTransactions()
        {
            IEnumerable<Transaction> model =_transactionRepository.GetAllTransaction();

            return View(model);
        }





        [HttpGet]
        public IActionResult DetailsTransactions(int id)
        {
            Transaction model = _transactionRepository.GetTransaction(id);

            return View(model);
        }




    }
}
