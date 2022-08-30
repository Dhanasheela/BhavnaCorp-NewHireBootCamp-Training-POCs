using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject
{
    interface ICustomer
    {
        public List<CustomerModel> AddCustomer(string role);
        public void DisplayList();
        public int DeleteCustomer(int empid);
        public int UpdateCustomer(int empid);
        public void DisplayTriggerList();
    }
}
