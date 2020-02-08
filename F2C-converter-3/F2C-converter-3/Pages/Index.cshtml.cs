using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace F2C_converter_3.Pages
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
        public string Temperature
        // this variable is linked to index.cshtml
        // <input type="text" asp-for="myTemperatureValue" value=""/>
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
            //this msg is called in [index.cshtml, line 12; @Model.msg]
            Msg = "This is the message set in index.cshtml.cs";
        }
        public void OnPost() // (action) what happens on post
        {
            string s = Temperature;

            (bool PassedOrNot, double NewConvertedTemp)= TempConverter.ChangeF2C(s);
            // this command above will say:
                // go into the TempConverter.cs (class)
                // grab the ChangeF2C function
                // shove the Temperature input you grabbed from the form 
                    //into MyNewTemp
                //and do X with it 

            if(PassedOrNot)
            {
                Msg = $"{Temperature} Fahrenheit is {Math.Round(NewConvertedTemp, 0)} Celsius";
            }
            else
            {
                Msg = $"{Temperature} was not valid.";
            }





        }
    }
}
