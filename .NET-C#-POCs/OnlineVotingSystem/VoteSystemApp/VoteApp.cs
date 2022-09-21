using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnlineVotingSystem.VoteSystemApp;

namespace OnlineVotingSystem
{
    public class VoteApp: IVoteApp
    {
        private readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
        private readonly ILogger<VoteApp> _logger;
        SqlCommand sqlCommand;

        public VoteApp(IConfiguration configuration, ILogger<VoteApp> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DevConnection"]);
        }

        public VoteApp()
        {
        }
        public void AppMenu()
        {
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.List");
            var n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("enter admin credentials");
                    CheckAdminNameAndPasswordAsync();
                    goto case 2;
                case 2:
                    Login();
                    goto case 3;
                case 3:
                    list();
                    break;
            }
        }


        public void CheckAdminNameAndPasswordAsync()
        {
            try
            {
                Console.WriteLine("Enter Admin Username");
                var username = Console.ReadLine();
                Console.WriteLine("Enter Admin Password");
                var password = Console.ReadLine();


                sqlCommand = new SqlCommand("select * from admin where username='" + username + "' and password ='" + password + "'", _sqlConnection);
                _sqlConnection.Open();

                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {

                    Console.WriteLine(sdr.GetValue(0) + " " + sdr.GetValue(1) );
                    Console.WriteLine("-----Admin Login successfully---" + "\n");

                }

                _sqlConnection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("invalid credentials");
            }

        }

        public void Login()
        {
            try
            {
                Console.WriteLine("Enter Ur Adhar Number");
                var adhar_no = Console.ReadLine();
                Console.WriteLine("Enter Otp");
                var otp = Console.ReadLine();
                //int n = 0;
                //Random randomnumber = new Random();
                //n = randomnumber.Next(1, 1000);
                //   sqlCommand = new SqlCommand("select * from voterLogin where adhar_no=" + adhar_no + " and otp =" + otp + "", _sqlConnection);

                sqlCommand = new SqlCommand("select r.voter_name,l.* from voter_registration r inner join voterLogin l on r.adhar_no=l.adhar_no where l.adhar_no=" + adhar_no + " and l.otp =" + otp + " ", _sqlConnection);

                _sqlConnection.Open();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                if (sdr.Read())
                {
                    Console.WriteLine($"-----Welcome {sdr.GetValue(0)} login successfully-----"+"\n");
                }
                else
                {
                    Console.WriteLine("login unsuccesful");
                }
                _sqlConnection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("invalid credentials");
            }
        }



        public void list()
        {
            

            _sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select voter_name,adhar_no,votercard_no,contact_no,vote_casted from voter_registration", _sqlConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("User Details Are Following:" + "\n");
                for (int curCol = 1; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Columns[curCol].ToString().Trim() + "\t");
                }
                Console.WriteLine("\n"+"------------");
                for (int curRow = 1; curRow < dt.Rows.Count; curRow++)
                {
                   // Console.WriteLine("\n" + "------------");
                    for (int curCol = 1; curCol < dt.Columns.Count; curCol++)
                    {

                        Console.Write(dt.Rows[curRow][curCol].ToString().Trim() + "\t" );
                    }
                    Console.WriteLine();
                }
                _sqlConnection.Close();
            }
        }

        }
}


