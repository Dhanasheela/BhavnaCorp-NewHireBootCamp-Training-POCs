using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR_ManufacturingApp.UI
{
    public class AppScreen
    {
        
        internal static void Welcome()
        {
            //clears the console screen
            Console.Clear();
            //sets the title of the console window
            Console.Title = "Car manufacturing Service";
            //sets the text color or foreground color to white
            // Console.ForegroundColor = ConsoleColor.White;

            //set the welcome message 
            Console.WriteLine("\n\n-----------------Welcome to My Car manufacturing Service-----------------\n\n");
           
            PressEnterToContinue();
        }
        public static void PressEnterToContinue()
        {
            Console.WriteLine("\n\nPress Enter to continue...\n");
            Console.ReadLine();
        }
        internal static void WelcomeEmployee(string emp_name)
        {
            SqlConnection con = new SqlConnection("server=localhost;database=carManufacture;Integrated Security=true;");
            SqlCommand sqlCommand;
            con.Open();
            sqlCommand = new SqlCommand("select *  from employees  " +
                  "where emp_name='" + emp_name + "' ", con);
            SqlDataReader sdr = sqlCommand.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine($"Welcome back,"+ sdr.GetValue(1) + "\n");
            }
            con.Close();
            //Console.WriteLine($"Welcome back, {emp_name}");
            PressEnterToContinue();
        }
        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("-------My Car manufacturing Service Menu-------");
            Console.WriteLine("1. Add new Employees    :");
            Console.WriteLine("2. salary distrubution  :");
            Console.WriteLine("3. Purchase New car :");
            Console.WriteLine("4. Purchased car details :");
            Console.WriteLine("5. Monthly DateWise  :");
            Console.WriteLine("6. Logout  :");
        }
        internal static void LogoutProgress()
        {
            Console.WriteLine("Thank you for using My Car manufacturing Service App.");
            Console.Clear();
        }
        public static void PrintMessage(string msg, bool success = true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            PressEnterToContinue();
        }
        public static string GetUserInput(string prompt)
        {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }
    }
}
