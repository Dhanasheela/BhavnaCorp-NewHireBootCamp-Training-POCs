using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Interfaces;

namespace VotingApp.Models
{
    public class Base : IBase
    {
       public string Username { get; set; }
        public string Password { get; set; }

       public long adhar_no { get; set; }
      public  string dob { get; set; }

       public int otp { get; set; }
        public string name { get; set;}

        public long votercard_no { get; set; }
        public long contact_no { get; set; }
        public string address { get; set; }

        public long votingAreaId { get; set; }

        public string status { get; set; }

        public string mode { get; set; }

        public bool voteCasted { get; set; }

        public string party_name { get; set; }

        public string party_symbol { get; set; }
      
        public int area_id { get; set; }
    }

}
