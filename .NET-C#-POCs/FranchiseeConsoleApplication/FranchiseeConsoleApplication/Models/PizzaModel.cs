using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeConsoleApplication.Models
{
    public class PizzaModel
    {
        public int pizza_id { get; set; }
        public string pizza_name { get; set; }
        public string pizza_sales_type { get; set; }
        public DateTime pizza_date { get; set; }
    }
}
