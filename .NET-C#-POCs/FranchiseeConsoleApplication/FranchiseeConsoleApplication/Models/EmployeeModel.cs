using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeConsoleApplication.Models
{
    public class EmployeeModel
    {
        public int emp_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string emp_role { get; set; }
        public bool role { get; set; }
        public int pizza_id { get; set; }

        public float salary { get; set; }
        public string date { get; set; }
    }
}
