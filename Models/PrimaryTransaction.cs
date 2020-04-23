using System;
using System.ComponentModel.DataAnnotations;

namespace BankManagement.Models
{
    public class PrimaryTransaction :Transaction
    {
        

        public PrimaryAccount PrimaryAccount { get; set; }
    }
}