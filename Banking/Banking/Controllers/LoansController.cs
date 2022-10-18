using Banking.Models;
using Banking.Models.UserDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Banking.Controllers
{
    public class LoansController : Controller
    {

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        private string TableId = "//table[@class='table table-curved']";
        public static bool msg = false;
        public static string currentselectedloan = "";
        public static Dictionary<string, string> bankDictionary = null;
        public LoansController()
        {
            bankDictionary = new Dictionary<string, string>();
            bankDictionary.Add("Axis", "Axis Bank");
            bankDictionary.Add("Yes", "Yes Bank");
            bankDictionary.Add("Syndicate", "Syndicate Bank");
            bankDictionary.Add("Baroda", "Bank of Baroda");
            bankDictionary.Add("Andhra", "Andhra Bank");
            bankDictionary.Add("IDBI", "IDBI Bank");
            bankDictionary.Add("Union", "Union Bank");
            bankDictionary.Add("ICICI", "ICICI Bank");
            bankDictionary.Add("HDFC", "HDFC Bank");
            bankDictionary.Add("SBI", "SBI Bank");
            bankDictionary.Add("Federal", "Federal Bank");
            bankDictionary.Add("Karur", "Karur Vysya Bank");
            bankDictionary.Add("Karnataka", "Karnataka Bank");
            bankDictionary.Add("Overseas", "Indian Overseas Bank");
            bankDictionary.Add("Maharashtra", "Bank of Maharashtra");
            bankDictionary.Add("IndusInd", "IndusInd Bank");
            bankDictionary.Add("United", "United Bank of India");

        }

        public ActionResult Index()
        {
            BankingViewModel objBankingViewModel = new BankingViewModel();
            List<SelectListItem> loanlist = new List<SelectListItem>();
            loanlist.Add(new SelectListItem { Text = "Home Loan", Value = "HomeLoan" });
            loanlist.Add(new SelectListItem { Text = "Education Loan", Value = "EducationLoan" });
            loanlist.Add(new SelectListItem { Text = "Car Loan", Value = "CarLoan" });
            loanlist.Add(new SelectListItem { Text = "Personal Loan", Value = "PersonalLoan" });
            loanlist.Add(new SelectListItem { Text = "Business Loan", Value = "BusinessLoan" });
            loanlist.Add(new SelectListItem { Text = "Fixed Deposit", Value = "FixedDeposit" });
            objBankingViewModel.LoansList = loanlist;
            return View(objBankingViewModel);

        }

        [HttpPost]
        public ActionResult LoanDetails(BankingViewModel Loan)
        {
            currentselectedloan = Loan.SelectedLoan;
            string viewname = string.Empty;
            if (currentselectedloan == "HomeLoan")
            {
                HomeLoanDetail objHomeLoanDetail = new HomeLoanDetail();
                viewname = "HomeDetails";
                return View(viewname, objHomeLoanDetail);
            }
            else if (currentselectedloan == "EducationLoan")
            {
                EducationalLoanDetail objEducationalLoanDetail = new EducationalLoanDetail();
                viewname = "EducationDetails";
                return View(viewname, objEducationalLoanDetail);
            }
            else if (currentselectedloan == "CarLoan")
            {
                CarLoanDetail objCarLoanDetail = new CarLoanDetail();
                viewname = "CarDetails";
                return View(viewname, objCarLoanDetail);
            }
            else if (currentselectedloan == "PersonalLoan")
            {
                viewname = "PersonalDetails";
                PersonalLoanDetail objPersonalLoanDetail = new PersonalLoanDetail();
                return View(viewname, objPersonalLoanDetail);
            }
            else if (currentselectedloan == "BusinessLoan")
            {
                viewname = "BussinesDetails";
                BussinesLoanDetail objBussinesLoanDetail = new BussinesLoanDetail();
                return View(viewname, objBussinesLoanDetail);
            }
            else if (currentselectedloan == "FixedDeposit")
            {
                return BindBankList();
            }
            return View(viewname);



        }

        [HttpPost]
        public ActionResult BankDetail(dynamic Loan)
        {
           
            return BindBankList();
        }

        public ActionResult BindBankList()
        {
            BankingViewModel objBankingViewModel = new BankingViewModel();
            List<List<string>> table = GetdatafromHTMLTable(currentselectedloan);
            IList<string> banknameList = new List<string>();
            foreach (var item in table)
            {
                LoansDetails loans = new LoansDetails();
                banknameList.Add(item[0]);
            }
            objBankingViewModel.BanksList = new List<SelectListItem>();
            foreach (var item in bankDictionary.Keys)
            {
                if (banknameList.Any(str => str.Contains(item)))
                {
                    objBankingViewModel.BanksList.Add(new SelectListItem { Text = bankDictionary[item], Value = item });
                }
            }
            if (currentselectedloan == "FixedDeposit")
            {
                return View("BankDetail",objBankingViewModel);
            }
            else
            {
                return View(objBankingViewModel);
            }
            
        }



        [HttpPost]
        public ActionResult LoanStatistics(BankingViewModel Loan)
        {

            List<string> Selectedbanklist = new List<string>();



            foreach (var item in Loan.BanksList)
            {
                if (item.Selected)
                {
                    Selectedbanklist.Add(item.Value);
                }
            }
            if (Selectedbanklist.Count == 0)
            {
                msg = true;
                return RedirectToAction("Index");

            }

            List<List<string>> table = GetdatafromHTMLTable(currentselectedloan);
            List<LoansDetails> LoanRateList = new List<LoansDetails>();
            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (var item in table)
            {
                LoansDetails loans = new LoansDetails();
                loans.BankName = item[0];
                loans.InterestRates = item[1];
                loans.ProcessingFee = item[2];
                var bankdetails = BankExists(loans.BankName, Selectedbanklist);
                if (bankdetails.Item1)
                {
                    LoanRateList.Add(loans);
                    double result = 0.0;
                    if (currentselectedloan == "FixedDeposit")
                    {
                        string rate = string.Empty;
                        string[] rates = loans.InterestRates.Split('-');
                        if (rates.Count() > 1)
                        {
                            rate = rates[1];
                        }
                        else
                        {
                            rate = rates[0];
                        }
                        result = double.Parse(rate.Substring(0, rate.IndexOf("%")));

                    }
                    else
                    {
                        result = double.Parse(loans.InterestRates.Substring(0, loans.InterestRates.IndexOf("%")));
                    }
                    dataPoints.Add(new DataPoint(result, bankdetails.Item2));

                }
                else
                {
                    loans = null;
                }
            }
            LoanViewModel objLoanViewModel = new LoanViewModel();
            objLoanViewModel.LoansDetailsList = LoanRateList;
            objLoanViewModel.Loantype = currentselectedloan;
            objLoanViewModel.DataPoints = JsonConvert.SerializeObject(dataPoints, _jsonSetting);

            if (currentselectedloan == "FixedDeposit")
            {
                return View("FixedStatistics", objLoanViewModel);
            }
            else
            {
                return View("LoanDetails", objLoanViewModel);
            }


        }


        private Tuple<bool, string> BankExists(string bank, List<string> Selectedbanklist)
        {
            string bankvalue = string.Empty;
            bool isExist = false;
            try
            {

                foreach (var item in Selectedbanklist)
                {
                    if (bank.Contains(item))
                    {
                        isExist = true;
                        bankvalue = item;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                isExist = false;
            }
            return Tuple.Create(isExist, bankvalue); ;
        }


        private List<List<string>> GetdatafromHTMLTable(string loantype)
        {
            List<List<string>> table = new List<List<string>>();
            try
            {
                string url = string.Empty;
                switch (loantype)
                {
                    case "EducationLoan":
                        url = "https://www.myloancare.in/education-loan-interest/ ";
                        break;
                    case "CarLoan":
                        url = "https://www.myloancare.in/car-loan-calculator/";
                        break;
                    case "PersonalLoan":
                        url = "https://www.myloancare.in/personal-loan/";
                        break;
                    case "BusinessLoan":
                        url = " https://www.myloancare.in/business-loan/";
                        break;
                    case "FixedDeposit":
                        url = " https://www.myloancare.in/fixed-deposit/fd-interest-rates/";
                        TableId = "//table[@class='table table-curved doc-table']";
                        break;
                    case "HomeLoan":
                    default:
                        url = "https://www.myloancare.in/home-loan-interest-rates/";
                        break;
                }



                WebClient webClient = new WebClient();
                ServicePointManager.Expect100Continue = true;
               ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string page = webClient.DownloadString(url);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);
                return table = doc.DocumentNode.SelectSingleNode(TableId)
                .Descendants("tr")
                .Skip(1)
                .Where(tr => tr.Elements("td").Count() > 1)
                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                .ToList();
            }
            catch (Exception ex)
            {

            }
            return table;
        }

    }
}
