using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banking.Models
{
    public class BankingViewModel
    {

        [Required]
        [Display(Name = "Loan")]
        public string SelectedLoan { get; set; }
        public IEnumerable<SelectListItem> LoansList { get; set; }       
        public List<SelectListItem> BanksList { get; set; }
    }
}