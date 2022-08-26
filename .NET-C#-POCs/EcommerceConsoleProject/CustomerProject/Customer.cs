using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject
{
    public class Customer: ICustomer
    {
        List<CustomerDetails> customer = new List<CustomerDetails>();
        public  List<CustomerDetails> AddCustomer()
        {
            CustomerDetails customerDetails = new CustomerDetails();
           
                Console.WriteLine("Enter following information to add new Customer:");
                Console.WriteLine("Enter customer Id");
                customerDetails.CustomerId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter customer name");
                customerDetails.Username = Console.ReadLine();
                Console.WriteLine("Enter customer password");
                customerDetails.Password = Console.ReadLine();
                Console.WriteLine("Customer ID:" + customerDetails.CustomerId + "\n" + "Customer Name:" + customerDetails.Username + "\n" + " Customer password:" + customerDetails.Password+"\n");

            return customer;
        }
       
    }
}
