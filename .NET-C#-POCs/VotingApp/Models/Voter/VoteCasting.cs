using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Interfaces.Voter;

namespace VotingApp.Models.Voter
{
    public class VoteCasting: Base,IVoteCasting
    {
        void IVoteCasting.VoteCaste()
        {
            try
            {
                DataSet ds = new DataSet();
                Console.WriteLine("Please enter your voter card id:");
                votercard_no = long.Parse(Console.ReadLine());


                SqlConnection con= new SqlConnection("server = BHAVNAWKS620\\SQLEXPRESS; database = newPolling; User id = sa; Password = Bhavna@123");
                SqlDataAdapter dataadap = new SqlDataAdapter("select votercard_no, vote_casted, status from voter_registration where votercard_no = " + votercard_no + "", con);



                if (ds.Tables.CanRemove(ds.Tables["voteCasted"]))
                    ds.Tables.Remove(ds.Tables["voteCasted"]);



                dataadap.Fill(ds, "voteCasted");



                if (ds.Tables["voteCasted"].Rows[0][1].ToString() == "False")
                {
                    if (ds.Tables["voteCasted"].Rows[0][2].ToString() == "active")
                    {
                        Console.WriteLine("Congratulations! You are eligible for online vote casting\n" +
                        "Welcome to the online voting system.\n" +
                        "Below are the political parties list. Please cast your vote by entering the correct party symbol name below\n");



                        //printing the parties names to the console -
                        SqlDataAdapter data = new SqlDataAdapter("select party_name, party_symbol from Party_info", con);



                        if (ds.Tables.CanRemove(ds.Tables["Parties"]))
                            ds.Tables.Remove(ds.Tables["Parties"]);



                        data.Fill(ds, "Parties");



                        int num = ds.Tables["Parties"].Rows.Count;



                        if (num > 0)
                        {
                            for (int i = 0; i < num; i++)
                            {
                                Console.WriteLine("Party: " + ds.Tables["Parties"].Rows[i][0].ToString() + ", Symbol: " + ds.Tables["Parties"].Rows[i][1].ToString() + "\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Couldn't find any information related to parties in db\n");
                        }



                        //storing the vote of voter
                        string vote = Console.ReadLine();



                        //updating the voter's vote in the database
                        SqlCommand cmd3 = new SqlCommand("UPDATE Party_info SET total_votes = (total_votes + 1) WHERE party_symbol = '" + vote + "'", con);



                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();



                        //updating the votecasted to true in the database
                        SqlCommand cmd4 = new SqlCommand("UPDATE voter_registration SET vote_casted = 1 where votercard_no = " +votercard_no + "", con);



                        con.Open();
                        cmd4.ExecuteNonQuery();
                        con.Close();



                        Console.WriteLine("Congratulations, You've successfully casted your vote!!\n" +
                             "Proud to have a citizen like yours\n" +
                             "Thank You for using online voting system\n");
                    }
                    else
                    {
                        Console.WriteLine("You're not eligible for online voting. Please visit you nearby polling booth to cast your vote. Thank You!\n");
                    }
                }
                else
                {
                    Console.WriteLine("You've already casted your vote. Thank You!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
