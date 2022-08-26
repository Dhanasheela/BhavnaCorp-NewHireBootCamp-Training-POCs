using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject
{
    interface IOrders
    {
        public List<OrderDetails> AddOrder();
    }
}
