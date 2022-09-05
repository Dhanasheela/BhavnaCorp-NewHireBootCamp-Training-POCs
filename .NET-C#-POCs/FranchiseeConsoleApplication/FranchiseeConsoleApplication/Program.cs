using FranchiseeConsoleApplication.PresentationLayer;
using System;

namespace FranchiseeConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Franchisee franchisee = new Franchisee();
            Employee employee = new Employee();

            Console.WriteLine("Enter Ur Option");
            Console.WriteLine("1:enter ur role");
            int option = int.Parse(Console.ReadLine());

            Console.WriteLine("enter role");
            string role = Console.ReadLine();

            switch (option)
            {
                case 1:
                    if (role == "admin")
                    {
                        franchisee.AddFranchisee(role);
                       
                    }
                    else if(role=="franchisee")
                    {
                        employee.AddEmployee(role);
                    }
                   
                    else
                    {
                        Console.WriteLine("Invalid role");
                    }

                    break;
                default:
                    Console.WriteLine("invalid options");
                    break;
            }

        }
    
    }

}
