using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banking.Models.UserDetail
{
    public class HomeLoanDetail
    {
        public int Age { get; set; }
        [Display(Name = "Annual Income")]
        public long AnnualIncome { get; set; }
        public long Amount { get; set; }
        public int Tenure { get; set; }
       
        public HomeLoanDetail()
        {
        }
    }
}