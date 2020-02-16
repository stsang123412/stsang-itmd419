# Assignment 2 - Mortgage
**Objective:** To modify the previous project ``F2C-converter3`` and create a mortgage calculator which takes:  
* Principal
* Interest Rate
* Number of Years  
After finishing with the code portion of this project, the next step will be to deploy the application onto a Free tier Azure website:  

**https://mortgage-proj2-stsang20200216075203.azurewebsites.net/**

## Walkthrough
1. When the application is first launched, the user will see the single razor page with 3 fields: ``Principal``, ``Years``, and ``Interest``.  
   * To access / make edits to this page, look for the ``index.cshtml`` file in solutions explorer.  
2. Backend
   * First made 3 getter-setter methods for ``principalString``, ``yearString``, and ``rateString``.
   ```csharp
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
    ```
    * ``public void OnGet()`` will bringthe ``Msg`` and display it on page.
    * ``public void OnPost()`` 
      * This function requests the input from the user via ``Request.Form[]`` and enter it into the string.
      * Pass the string into the ``CalculateMonthlyPaymentFunction`` function.
      * **Output:** returns a ``double`` with the amount the user pays per month. 
    ```csharp
        public void OnPost()
        {
            string principal = Request.Form["principalString"];
            string years = Request.Form["yearString"];
            string rate = Request.Form["rateString"];

            double showMonthlyPayment = MortgageCalculator.CalculateMonthlyPaymentFunction(principal, years, rate);

            Msg = $"${showMonthlyPayment} is your monthly payment over the course of {years} years at a rate of {rate}% interest.";
        }
    ```
    ```csharp
        public static double CalculateMonthlyPaymentFunction(string stringprincipal, string stringYears, string stringRate)
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
    ```

