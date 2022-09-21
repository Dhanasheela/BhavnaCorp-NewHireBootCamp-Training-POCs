using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Interfaces;
using VotingApp.Interfaces.Admin;

namespace VotingApp.Models.Admin
{
    public class PartyRegistration: Base, IPartyRegistration
    {
        void IPartyRegistration.Pregisteration(string c)
        {
            Console.WriteLine("Enter the name of the party");
            party_name = Console.ReadLine();



            Console.WriteLine("Enter the symbol name for the party");
            party_symbol = Console.ReadLine();



            Console.WriteLine("Enter the area id for the party where voting will be held");
             area_id = int.Parse(Console.ReadLine());


            SqlConnection con = new SqlConnection("server = BHAVNAWKS620\\SQLEXPRESS; database = newPolling; User id = sa; Password = Bhavna@123");
            //  DataSet ds = new DataSet();
            //inserting party record in db------------------------------------------------
            SqlCommand partycmd = new SqlCommand("insert into Party_info (party_name, party_symbol, total_votes, voting_areaID) values( '" + party_name + "'  , '" + party_symbol + "' , 0 , " + area_id + ")", con);
            con.Open();
            partycmd.ExecuteNonQuery();
            con.Close();



            //we can add dot animation here for few seconds-------------------------------
            IUtility utility = new Utilitiy();
            Console.WriteLine("\nPlease wait We're adding the Party details.");
            utility.PrintDotAnimation();
            Console.WriteLine(c);
        }
    }
}
