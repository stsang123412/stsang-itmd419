# Assignment 4 - Cleaner Mortgage
**Objective:** To create a cleaner version of project 3.

### Front End
``index.cshtml``  
This part is nothing big. Front end form is what the user sees and how they input their 3 fields of data.  
```csharp
<div class="text-center">
    <h1 class="display-4">Mortgage Project 4 - Stsang</h1>
    <p>Assignment 5 of ITMD 419</p>
    <p>Cleaner Mortgage Assignment</p>
</div>

<div class="customFormDiv">
    <!-- Create a form for taking in user data -->
    <form method="post">
        <label>Principal: </label>
        <input type="text" name="principalString" />

        <label>Years: </label>
        <input type="text" name="yearString" />

        <label>Interest: </label>
        <input type="text" name="rateString" />

        <button type="submit">Submit</button>
    </form>
</div>

<p>
    @Model.Msg
</p>
```

``index.cshtml.cs``  
So this page is essentially what happens when the user hits **"submit"**. 
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using proj4_stsang_mortgage_dotnetCORE_library;

namespace proj4_stsang_mortgage_dotnetCORE_app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IConfiguration iconfigVar;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration iconfigVar)
        {
            _logger = logger;
            this.iconfigVar = iconfigVar;
        }
        public string Msg
        {
            get;            //public; anyone can get
            private set;    //private; not anyone can change the value
        }

        public void OnGet()
        {
            Msg = "Enter Principal, Duration, and Interest Rate: ";
        }
        public void OnPost()
        {
            // first create a new variable [string] that holds the connection string for our azure account
                // this value uses the iconfig object we made in line 15 to pull in our connection string to our azure account
                // in this case, we will be taking our connection string to <stevestorage419> which can be found in the appsettings.json file
                // this string is also not hard coded, big difference compared to project 3            
                // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1  <-- Iconfig 

            string connectionString = iconfigVar.GetValue<string>("SteveAzureConnectStorageString");

            // Parse the string
            CloudStorageAccount storageAccountVariable = CloudStorageAccount.Parse(connectionString);
            // Create the client
            CloudQueueClient queueClient = storageAccountVariable.CreateCloudQueueClient();
            // get the reference to the queue; stick it into 'queueName' variable
            CloudQueue queueName = queueClient.GetQueueReference("project3queue");


            // new object that stores the 3 user fields entered in the front page
            if (ModelState.IsValid)
            {
                UserMortgageInputObject newMortgageObject = new UserMortgageInputObject
                {
                    principalString = Request.Form["principalString"],
                    yearString = Request.Form["yearString"],
                    rateString = Request.Form["rateString"]
                };

                // writes the serialized JSON object into the queue
                //var boxedUpData = JsonConvert.SerializeObject(newMortgageObject);

                var newJSONstring = newMortgageObject.ToSerializedObject(ref newMortgageObject);

                queueName.AddMessageAsync(new CloudQueueMessage(newJSONstring));
            }
            else 
            {
                Msg = "Yeah there's an error. Please fix.";
            }
        }

    }
}

```
``UserMortgageInputObject.cs``  
This class essentially contains the user mortgage object/model and contains the method used to serialize (and possibly deserialize once I finish) the object that is passed into the function.  
```csharp
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using proj4_stsang_mortgage_dotnetCORE_library;

namespace proj4_stsang_mortgage_dotnetCORE_library
{
    public class UserMortgageInputObject
    {
        public UserMortgageInputObject() { } // constructor
        public UserMortgageInputObject(string principalString, string yearString, string rateString)
        {
            var principal = principalString;
            var year = yearString;
            var rate = rateString;
        }
        public string ToSerializedObject(ref UserMortgageInputObject UserX) //ref proj4_stsang_mortgage_dotnetCORE_library.UserMortgageInputObject UserX
        {
            // godbless https://stackoverflow.com/questions/8708632/passing-objects-by-reference-or-value-in-c-sharp
            var boxedUpData = JsonConvert.SerializeObject(UserX);

            return boxedUpData;

            // the output is a JSON string
        }


        public string principalString { get; set; }
        public string yearString { get; set; }
        public string rateString { get; set; }
    }
}

```
``CalculateMonthlyPaymentFunction.cs``  
At the current time that I'm writing this, this calculate the monthly payment has not yet been implemented, but the idea is that the program will call on this method to take in the 3 user fields after being **deserialized**, calculate the monthly payment, then return that monthly payment in the form of a double. 
```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace proj4_stsang_mortgage_dotnetCORE_library
{
    public class CalculateMonthlyPaymentFunction
    {
		public static double CalculateMonthlyPayment(string stringprincipal, string stringYears, string stringRate)
		{
			double monthly;

			double principal = Convert.ToDouble(stringprincipal);
			double years = Convert.ToDouble(stringYears);
			double rate = Convert.ToDouble(stringRate);

			double top = principal * rate / 1200.00;
			double bottom = 1 - Math.Pow(1.0 + rate / 1200.00, -12.0 * years);
			monthly = top / bottom;

			return monthly;
		}
	}
}

```