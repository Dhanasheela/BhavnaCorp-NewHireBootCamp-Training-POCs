using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Interfaces.Admin;

namespace VotingApp.Models.Admin
{
    public class CountVotes:Base,ICountVotes
    {
        void ICountVotes.Count()
        {
            try
            {
                SqlConnection con = new SqlConnection("server = BHAVNAWKS620\\SQLEXPRESS; database = newPolling; User id = sa; Password = Bhavna@123");
                DataSet ds = new DataSet();
                Console.WriteLine("Enter the symbol of party whose total votes you want to see or Enter ALL to see the all parties votes");
                string partyName = Console.ReadLine();



                if (partyName.ToUpper() == "ALL")
                {
                    SqlDataAdapter newdata = new SqlDataAdapter("select party_name, party_symbol, total_votes from Party_info", con);



                    if (ds.Tables.CanRemove(ds.Tables["parties_votes"]))
                        ds.Tables.Remove(ds.Tables["parties_votes"]);



                    newdata.Fill(ds, "parties_votes");



                    int num = ds.Tables["parties_votes"].Rows.Count;



                    if (num > 0)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            Console.WriteLine($"Party Name: {ds.Tables["parties_votes"].Rows[i][0].ToString()}, " +
                                $"Party Symbol: {ds.Tables["parties_votes"].Rows[i][1].ToString()}, " +
                                $"Votes recieved: {ds.Tables["parties_votes"].Rows[i][2].ToString()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find any information related to parties in db\n");
                    }
                }
                else
                {
                    SqlDataAdapter newdata = new SqlDataAdapter("select party_name, party_symbol, total_votes from Party_info where party_symbol = '" + partyName + "'", con);



                    if (ds.Tables.CanRemove(ds.Tables["party_votes"]))
                        ds.Tables.Remove(ds.Tables["party_votes"]);



                    newdata.Fill(ds, "party_votes");



                    int num = ds.Tables["party_votes"].Rows.Count;
                    if (num > 0)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            Console.WriteLine($"Party Name: {ds.Tables["party_votes"].Rows[i][0].ToString()}, " +
                                $"Party Symbol: {ds.Tables["party_votes"].Rows[i][1].ToString()}, " +
                                $"Votes recieved: {ds.Tables["party_votes"].Rows[i][2].ToString()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Party doesn't exist in db\n");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
