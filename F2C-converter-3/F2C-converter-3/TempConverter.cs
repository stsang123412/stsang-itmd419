using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2C_converter_3
{
    public class TempConverter
    {
        //static function; does not need a running instance
        public static (bool PassedOrNot, double convertedTemperature) ChangeF2C(string Temperature)
        {
            double convertedTemperature; // declaration of one single variable, so that we can store a single value  to return

            if (int.TryParse(Temperature, out int TempNowINT)) // take the temperature string, parse it into an INT, and OUT pops a new INT (TempNowINT)
            {
                System.Console.WriteLine("Woohoo! Your new temperature is: " + TempNowINT.ToString());

                convertedTemperature = (TempNowINT - 32) * (5.0 / 9);

                return (true, convertedTemperature);

                //Msg = $"{TempNowINT} Fahrenheit is {Math.Round(celsius, 0)} Celsius";
                //return; we dont need return statement here because its { public VOID }
            }
            else
            {
                return (false, 0);

            }
            // We're returning the value and shoving it into a truple (bool PassedOrNot, double convertedTemperature)
        }
    }
}
