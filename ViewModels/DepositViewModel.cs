﻿using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.ViewModels
{
    public class DepositViewModel
    {


        public AccountType AccountTypeTo { get; set; }       

        public decimal Montant { get; set; }

    }
}
