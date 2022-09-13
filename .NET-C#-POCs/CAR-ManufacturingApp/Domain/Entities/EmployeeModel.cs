using CAR_ManufacturingApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR_ManufacturingApp.Domain.Entities
{
    public class EmployeeModel
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string password { get; set; }
        public string shift_type { get; set; }
        public string depart_name { get; set; }
        public int working_days { get; set; }
        public string sal_date { get; set; }
        public float salary { get; set; }
        public  bool role { get; set; }
    }
}
