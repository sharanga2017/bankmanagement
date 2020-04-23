using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BankManagement.Controllers
{
    [Authorize]
    public class PrimaryAccountsController : Controller
    {
        private readonly AppDbContext _context;

        public UserManager<ApplicationUser> _userManager { get; }

        public PrimaryAccountsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: PrimaryAccounts
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user.PrimaryAccount != null)
            {
                int id = user.PrimaryAccount.Id;
                return RedirectToAction("Details",id);
            }

            else
            {
                return RedirectToAction("Create");
            }
                                 
            //var primaryAccount = _context.PrimaryAccounts.Include(s => s.User).FirstOrDefaultAsync(s => s.UserRef == user.Id);
            //if()


            //return View(await primaryAccount);
        }

        // GET: PrimaryAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var primaryAccount = await _context.PrimaryAccounts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (primaryAccount == null)
            {
                return NotFound();
            }

            return View(primaryAccount);
        }

        // GET: PrimaryAccounts/Create
        public IActionResult Create()
        {
            ViewData["UserRef"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: PrimaryAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UniqueId,Name,Balance,CreatedOn,UserRef")] PrimaryAccount primaryAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(primaryAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserRef"] = new SelectList(_context.Users, "Id", "Id", primaryAccount.UserRef);
            return View(primaryAccount);
        }

        // GET: PrimaryAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var primaryAccount = await _context.PrimaryAccounts.FindAsync(id);
            if (primaryAccount == null)
            {
                return NotFound();
            }
            ViewData["UserRef"] = new SelectList(_context.Users, "Id", "Id", primaryAccount.UserRef);
            return View(primaryAccount);
        }

        // POST: PrimaryAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UniqueId,Name,Balance,CreatedOn,UserRef")] PrimaryAccount primaryAccount)
        {
            if (id != primaryAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(primaryAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrimaryAccountExists(primaryAccount.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserRef"] = new SelectList(_context.Users, "Id", "Id", primaryAccount.UserRef);
            return View(primaryAccount);
        }

        // GET: PrimaryAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var primaryAccount = await _context.PrimaryAccounts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (primaryAccount == null)
            {
                return NotFound();
            }

            return View(primaryAccount);
        }

        // POST: PrimaryAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var primaryAccount = await _context.PrimaryAccounts.FindAsync(id);
            _context.PrimaryAccounts.Remove(primaryAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrimaryAccountExists(int id)
        {
            return _context.PrimaryAccounts.Any(e => e.Id == id);
        }
    }
}
