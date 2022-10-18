using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banking.Models.UserDetail
{
    public class CarLoanDetail
    {
       
        public int Age { get; set; }
        [Display(Name = "Annual Income")]
        public long AnnualIncome { get; set; }
        public long Amount { get; set; }      
        public int Tenure { get; set; }
        [Display(Name = "Type Of Employement")]
        public List<string> TypeOfEmployement { get; set; }
        [Display(Name = "Type Of Car Model")]
        public List<string> TypeOfCarModels { get; set; }
        public CarLoanDetail()
        {
            TypeOfEmployement = new List<string>();
            TypeOfEmployement.Add("Salaried");
            TypeOfEmployement.Add("Self emplyed");
            TypeOfEmployement.Add("Professional");
            TypeOfCarModels = new List<string>();
            TypeOfCarModels.Add("Hatch back");
            TypeOfCarModels.Add("Sedan");
            TypeOfCarModels.Add("SUV");
            TypeOfCarModels.Add("MUV");
            TypeOfCarModels.Add("luxury");

        }
    }
}