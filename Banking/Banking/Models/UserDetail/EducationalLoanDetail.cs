using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banking.Models.UserDetail
{
    public class EducationalLoanDetail
    {
        public int Age { get; set; }
        [Display(Name = "Academic Percentage")]
        public long AcademicPercentage { get; set; }
        public long Amount { get; set; }
        public int tenure { get; set; }
        [Display(Name = "Type Of Course")]
        public List<string> TypeOfCourse { get; set; }
        public EducationalLoanDetail()
        {
            TypeOfCourse = new List<string>();
            TypeOfCourse.Add("Btech");
            TypeOfCourse.Add("Medcine");
            TypeOfCourse.Add("Degree");
            TypeOfCourse.Add("PG");
            TypeOfCourse.Add("Medical");
            TypeOfCourse.Add("Others");          

        }
    }
}