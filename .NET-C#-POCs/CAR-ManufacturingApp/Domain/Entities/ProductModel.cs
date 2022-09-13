using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR_ManufacturingApp.Domain.Entities
{
    public class ProductModel
    {
        public int car_id { get; set; }
        public string car_name {get;set;}
        public float car_price { get; set; }
        public string car_parts { get; set; }
        public int car_stocks { get; set; }
        public string purchased_date { get; set; }
        public string emp_name { get; set; }


    }
}
