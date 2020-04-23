using BankManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankManagement.Security
{
    public class PCommon : IPCommon
    {
       // private ApplicationUser _user;

        public PCommon(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
           
            
        }

        private IHttpContextAccessor _httpContextAccessor { get; }
        private UserManager<ApplicationUser> _userManager { get; }

        private string _userId { get; }

    public  string getUserId()
        {
            string id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        return id;
        }


        public async Task<ApplicationUser> getUser()
        {

            ApplicationUser user = await _userManager.FindByIdAsync(_userId);
            return user;
        }

       

        public bool hasSavinsAccount()
        {
            throw new NotImplementedException();
        }

        public bool hasPrimaryAccount()
        {
            throw new NotImplementedException();
        }
    }


    public interface IPCommon
    {
       string getUserId();
        bool hasPrimaryAccount();
        bool hasSavinsAccount();
    }
}
