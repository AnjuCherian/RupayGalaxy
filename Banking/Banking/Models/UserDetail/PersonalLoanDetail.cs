using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banking.Models.UserDetail
{
    public class PersonalLoanDetail
    {
    
        public int Age { get; set; }
        [Display(Name = "Monthly Income")]
        public long MonthlyIncome { get; set; }
        public long Amount { get; set; }
        public int Tenure { get; set; }

        public PersonalLoanDetail()
        {
        }
    }
}