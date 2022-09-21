using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Interfaces
{
    public interface IBase
    {
         string Username { get; set; }
         string Password { get; set; }

        long adhar_no { get; set; }
        string dob { get; set; }

        int otp { get; set; }

         string name { get; set; }

         long votercard_no { get; set; }
         long contact_no { get; set; }
         string address { get; set; }

         long votingAreaId { get; set; }

         string status { get; set; }
         bool voteCasted { get; set; }

         string party_name { get; set; }

         string party_symbol { get; set; }
         
         int area_id { get; set; }
    }

}
