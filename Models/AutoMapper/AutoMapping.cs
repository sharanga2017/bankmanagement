using AutoMapper;
using BankManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<PrimaryAccountCreateViewModel, PrimaryAccount>();
            CreateMap<PrimaryAccountEditViewModel, PrimaryAccount>();
            CreateMap<PrimaryAccount, PrimaryAccountEditViewModel>();
            CreateMap<SavingsAccountCreateViewModel, SavingsAccount>();
            CreateMap<ApplicationUser, FrontUserViewModel >();

            CreateMap<Recipient, Recipient>();

        }
    }
}
