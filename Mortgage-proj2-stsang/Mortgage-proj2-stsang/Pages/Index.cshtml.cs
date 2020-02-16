using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Mortgage_proj2_stsang.Pages
{
    public class IndexModel : PageModel
    {
            public string Msg
            {
                get;            //public; anyone can get
                private set;    //private; not anyone can change the value
            }
            [Required]
            [BindProperty]
            public string principalString
            // this variable is linked to index.cshtml
            // <input type="text" asp-for="loanAmount" value=""/>
            {
                get;            //public; anyone can get
                set;            //no private; must be set by the 
            }
            public string yearString
            // this variable is linked to index.cshtml
            // <input type="text" asp-for="durationTime" value=""/>
            {
                get;            //public; anyone can get
                set;            //no private; must be set by the 
            }
            public string rateString
            // this variable is linked to index.cshtml
            // <input type="text" asp-for="interestAmount" value=""/>
            {
                get;            //public; anyone can get
                set;            //no private; must be set by the 
            }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Msg = "This small application will calculate your loan information based on the information you provide";
        }
        public void OnPost()
        {
            string principal = Request.Form["principalString"];
            string years = Request.Form["yearString"];
            string rate = Request.Form["rateString"];

            double showMonthlyPayment = MortgageCalculator.CalculateMonthlyPaymentFunction(principal, years, rate);

            Msg = $"${showMonthlyPayment} is your monthly payment over the course of {years} years at a rate of {rate}% interest.";
        }
    }
}
