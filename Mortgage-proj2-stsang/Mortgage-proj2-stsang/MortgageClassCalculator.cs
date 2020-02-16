using System;

namespace Mortgage_proj2_stsang
{
	public class MortgageCalculator
	{
		//function 
		//calculates monthly payment
		//takes in our 3 variables: loanAmount | interestAmount | durationTime
		//							principal  | rate			| years

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
	}
}


