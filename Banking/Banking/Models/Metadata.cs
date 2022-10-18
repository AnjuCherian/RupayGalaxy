using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Banking.Models
{
    [MetadataType(typeof(Registrationdata))]
    public partial class Registration
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string RPassword { get; set; }
        public HttpPostedFileBase File { get; set; }
    }

    public partial class Registrationdata
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Mobile { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(12)]
        public string AaadharNo { get; set; }
        [StringLength(10)]
        public string PAN { get; set; }
        [Display(Name = "District")]
        public Nullable<int> DistrictID { get; set; }
        public string Salary { get; set; }
    }

    [MetadataType(typeof(Logindata))]
    public partial class Login
    {
    }

    public partial class Logindata
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}