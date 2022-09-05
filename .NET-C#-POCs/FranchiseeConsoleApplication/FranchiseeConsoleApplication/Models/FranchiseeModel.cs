using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeConsoleApplication.Models
{
    public class FranchiseeModel
    {
        public int franch_id { get; set; }
        public int emp_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool role { get; set; }
        public string code { get; set; }
        public string franch_date { get; set; }
        public int sales { get; set; }

    }
}
