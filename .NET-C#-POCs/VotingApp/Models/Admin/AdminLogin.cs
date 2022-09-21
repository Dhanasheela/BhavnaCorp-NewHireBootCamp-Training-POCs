using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Interfaces;
using VotingApp.Interfaces.Admin;

 namespace VotingApp.Models.Admin
{
    public class AdminLogin : Base, IAdminLogin
    {
        bool temp = false;
        bool IAdminLogin.ALogin(string a)
        {
            try
            {
                Console.WriteLine("Enter the username for admin account:");
                Username = Console.ReadLine();

                Console.WriteLine("Enter the password for  admin account:");
                Password = Console.ReadLine();

                //  IUtility utility = new Utilitiy();
                //string con = utility.getConnection();

                // string con = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
                // Console.WriteLine(con);
                SqlConnection connection = new SqlConnection("server = BHAVNAWKS620\\SQLEXPRESS; database = newPolling; User id = sa; Password = Bhavna@123");
                SqlCommand command = new SqlCommand("select * from admin where username='" + Username + "' and password ='" + Password + "'", connection);
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                int count = 0;
                while (sdr.Read())
                {
                    count++;
                }
                connection.Close();
                IUtility utility = new Utilitiy();
                Console.WriteLine("\nPlease wait We're Checking the login details");
                utility.PrintDotAnimation();
                if (count == 1)
                {

                    Console.WriteLine("\nAdmin is Successfully Logged in: ");
                    temp = true;
                }
                else
                {
                    Console.WriteLine("\nUsername and Password is Incorrect");
                    temp = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return temp;
        }
    }
}
