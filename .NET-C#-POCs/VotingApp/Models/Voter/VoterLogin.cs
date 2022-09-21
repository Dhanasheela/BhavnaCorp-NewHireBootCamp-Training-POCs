using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Interfaces;
using VotingApp.Interfaces.Voter;

namespace VotingApp.Models.Voter
{
    public class VoterLogin : Base, IVoterLogin
    {
        bool IVoterLogin.VLogin(string a)
        {
            bool temp = false;
            try
            {
                Console.WriteLine("\n Enter Ur Adhar Number");
                adhar_no = long.Parse(Console.ReadLine());
                Console.WriteLine("\n Enter your DOB in dd-mm-yyyy format");
                dob = Console.ReadLine();
                IUtility utility = new Utilitiy();
                Console.WriteLine("Please wait generating the otp");
                utility.PrintDotAnimation();
                Console.WriteLine("\n Enter the OTP");
                otp = int.Parse(Console.ReadLine());

                SqlConnection con = new SqlConnection("server = BHAVNAWKS620\\SQLEXPRESS; database = newPolling; User id=sa;Password=Bhavna@123");
                SqlCommand command = new SqlCommand("select * from voterLogin where adhar_no=" + adhar_no + " and dob = '" + dob + "' and otp =" + otp + "", con);
                int count = 0;
                con.Open();
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    count++;




                }

                con.Close();
                Console.WriteLine("\nPlease wait We're Checking the login details");
                utility.PrintDotAnimation();
                if (count == 1)
                {

                    Console.WriteLine("\nVoter is Successfully Logged in: ");
                    temp = true;
                }
                else
                {
                    Console.WriteLine("\nData is Incorrect");
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
