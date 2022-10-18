using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banking.Models
{
    public class LoansDetails
    {
       public int Id { get; set; }
        public string BankName { get; set; }
        public string InterestRates { get; set; }
        public string ProcessingFee { get; set; } 
    }
}