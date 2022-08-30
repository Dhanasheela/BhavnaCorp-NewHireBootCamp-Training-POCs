using EmployeeProject;
using System;

namespace ConsoleDBApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee();
            Console.WriteLine("Enter Ur Option");
            Console.WriteLine("1:Insert");
            Console.WriteLine("2:Update");
            Console.WriteLine("3:Select");
            Console.WriteLine("4:Delete");
            Console.WriteLine("5:Search");

            int option = int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                    employee.AddEmployee();
                    employee.DisplayList();
                    break;
                case 2:
                    Console.WriteLine("Enter EmployeeId which you want to update:");
                   int empId1 = int.Parse(Console.ReadLine());
                   int result = employee.update(empId1);
                    employee.DisplayList();
                    break;
                case 3:
                    employee.DisplayList();
                    break;
                case 4:
                    Console.WriteLine("Enter EmployeeId which you want to delete:");
                    int empId2 = int.Parse(Console.ReadLine());
                    employee.DeleteEmployee(empId2);
                    employee.DisplayList();
                    break;
                case 5:
                    Console.WriteLine("Enter name to search:");
                    var name = Console.ReadLine();
                    employee.Search(name);
                    break;
                default:
                    Console.WriteLine("invalid options");
                    break;

            }
        }
    }
}
