using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banking.Models
{
    public class LoanViewModel
    {
        public List<LoansDetails> LoansDetailsList { get; set; }
        public dynamic DataPoints { get; set; }
        public string Loantype { get; set; }
    }
}