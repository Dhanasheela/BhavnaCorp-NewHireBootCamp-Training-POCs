using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR_ManufacturingApp.UI
{
    public static class Validator
    {
        public static T Convert<T>(string prompt)
        {
            bool valid = false;
            string userInput;

            while (!valid)
            {
                userInput = AppScreen.GetUserInput(prompt);

                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput);
                    }
                    else
                    {
                        return default;
                    }
                }
                catch
                {
                    AppScreen.PrintMessage("Invalid input. Try again.", false);
                }
            }
            return default;
        }
    }
}
