using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Interfaces;
using VotingApp.Interfaces.Admin;

namespace VotingApp.Models.Admin
{
    public class VoterRegistration : Base,IVoterRegisteration
    {
        void IVoterRegisteration.registeration(string b)
        {
            try {
                //db connection string-----------------
                SqlConnection con = new SqlConnection("server = BHAVNAWKS620\\SQLEXPRESS; database = newPolling; User id = sa; Password = Bhavna@123");
              //  DataSet ds = new DataSet();


     


     

                        Console.WriteLine("Enter voter's aadhaar number");
                        adhar_no = long.Parse(Console.ReadLine());



                        Console.WriteLine("Enter voter's name as per the aadhaar card");
                        name = Console.ReadLine();



                        Console.WriteLine("Enter voter's votercard number");
                        votercard_no = long.Parse(Console.ReadLine());



                        Console.WriteLine("Enter voter's contact number");
                        contact_no = long.Parse(Console.ReadLine());



                        Console.WriteLine("Enter the voter's address");
                         address = Console.ReadLine();



                        Console.WriteLine("Enter the dob of the voter in dd-mm-yyyy format only");
                        dob = Console.ReadLine();



                        Console.WriteLine("Enter the voting area id for the voter");
                        votingAreaId = long.Parse(Console.ReadLine());



                        Console.WriteLine("Enter the status of the voter - active/inactive");
                        status = Console.ReadLine();



                        Console.WriteLine("Enter the mode of the voter - online/offline");
                        mode = Console.ReadLine();

                       voteCasted = false;



                        //inserting a record in db



                        SqlCommand cmd = new SqlCommand("insert into voter_registration values( '" + name + "'  , " + adhar_no + " ,  " + votercard_no + " ,  " + contact_no + " , '" + address + "', '" + dob + "'," + votingAreaId + ",'" + status + "','" + mode + "', '"+voteCasted+"')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                //-------------we can add dot animation here for few seconds-----------------

                IUtility utility = new Utilitiy();
                Console.WriteLine("\nPlease wait We're adding the voter details.");
                utility.PrintDotAnimation();

                Console.WriteLine(b);




                }
            
            
    
            catch (Exception ex)
            {



                Console.WriteLine(ex.Message);
            }

        }
    }
}
