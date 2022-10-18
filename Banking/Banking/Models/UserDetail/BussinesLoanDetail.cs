using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banking.Models.UserDetail
{
    public class BussinesLoanDetail
    {
       
        public int  Age { get; set; }
        [Display(Name = "Turn Over")]
        public long TurnOver { get; set; }
        public long Amount { get; set; }
        public int  Tenure { get; set; }
      
        public BussinesLoanDetail()
        {

        }
    }
}