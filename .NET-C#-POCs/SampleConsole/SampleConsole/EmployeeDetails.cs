using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{

    class EmployeeDetails
    {
         public static void Main(string[] args)
        {
            Program emp = new Program();
            int option1 =emp.DisplayMainMenu();
            emp.MainCall(option1);
            Console.Read();
        }

       
    }
}
