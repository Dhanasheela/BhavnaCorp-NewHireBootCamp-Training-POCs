using CustomerProject;
using System;

namespace BankingProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter Ur Option");
            Console.WriteLine("1:Enter ur role");
           int option = int.Parse(Console.ReadLine());
            Console.WriteLine("enter role");
            string role = Console.ReadLine();
            switch (option)
            {
                case 1:
                    customer.AddCustomer(role);
                    break;
                default:
                    Console.WriteLine("invalid options");
                    break;
            }

        }
    }
}
