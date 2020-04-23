using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankManagement.Models;
using BankManagement.Security;
using BankManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankManagement.Controllers
{
    public class SavingsController : Controller
    {
        public AppDbContext _context { get; }
        public UserManager<ApplicationUser> _userManager { get; }
        public ISavingsAccountRepository _savingsAccountRepository { get; }
        public IMapper _mapper { get; }
        public IPCommon _pCommon { get; }

        public SavingsController(AppDbContext context, UserManager<ApplicationUser> userManager, 
            ISavingsAccountRepository savingsAccountRepository,
            IMapper mapper,
            IPCommon pCommon
            )
        {
            _context = context;
            _userManager = userManager;
            _savingsAccountRepository = savingsAccountRepository;
            _mapper = mapper;
            _pCommon = pCommon;
        }

        // GET: PrimaryTest
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            SavingsAccount model = _savingsAccountRepository.GetByUser(user);
            if(model != null)
            {
                return View(model);
            }
            else
            {
               return RedirectToAction("Create");
                
            }
            
        }

        // GET: Savings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Savings/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Savings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SavingsAccountCreateViewModel savingsAccount)
        {

            if (ModelState.IsValid)
            {

                SavingsAccount account = _mapper.Map<SavingsAccount>(savingsAccount);
                account.CreatedOn = DateTime.Now;
                account.UserRef = _pCommon.getUserId();


                _savingsAccountRepository.Add(account);

                return RedirectToAction("Index");
            }



            return View();




            //try
            //{


            //    // TODO: Add insert logic here

            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Savings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Savings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Savings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Savings/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}