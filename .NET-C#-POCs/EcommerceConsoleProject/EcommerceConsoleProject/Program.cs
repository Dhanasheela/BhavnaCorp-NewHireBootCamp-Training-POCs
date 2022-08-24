using CustomerProject;
using ProductProject;
using OrderProject;
using System;

namespace EcommerceConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customers = new Customer();
            Product products = new Product();
            Order orders = new Order();
            Console.WriteLine("Enter Ur Option");
            int option = int.Parse(Console.ReadLine());

           switch(option)
            {
                case 1:
                    customers.AddCustomer();
                   // customers.DisplayList();
                    goto case 2;
                case 2:
                    products.AddProduct();
                    goto case 3;
                case 3:
                    orders.AddOrder();
                    break;
                default:
                    Console.WriteLine("invalid options");
                    break;


            }
        }
    }
}
