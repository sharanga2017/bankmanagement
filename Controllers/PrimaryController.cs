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
    [Authorize]
    public class PrimaryController : Controller
    {
        public AppDbContext _context { get; }
        public UserManager<ApplicationUser> _userManager { get; }
        public IPrimaryAccountRepository _primaryAccountRepository { get; }
        public IMapper _mapper { get; }
        public IPCommon _pCommon { get; }

        public PrimaryController(AppDbContext context, UserManager<ApplicationUser> userManager, 
            IPrimaryAccountRepository primaryAccountRepository,
            IMapper mapper,
            IPCommon pCommon
            )
        {
            _context = context;
            _userManager = userManager;
            _primaryAccountRepository = primaryAccountRepository;
            _mapper = mapper;
            _pCommon = pCommon;
        }

        // GET: PrimaryTest
        public async Task<ActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            PrimaryAccount model = _primaryAccountRepository.GetByUser(user);

            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Create");

            }
            
        }

        // GET: PrimaryTest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrimaryTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrimaryTest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrimaryAccountCreateViewModel primaryAccount)
        {

            if (ModelState.IsValid)
            {

                PrimaryAccount account = _mapper.Map<PrimaryAccount>(primaryAccount);
                account.CreatedOn = DateTime.Now;
                account.UserRef = _pCommon.getUserId();


                _primaryAccountRepository.Add(account);

                return RedirectToAction("Index");
            }



            return View();
        }

        // GET: PrimaryTest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrimaryTest/Edit/5
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

        // GET: PrimaryTest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrimaryTest/Delete/5
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