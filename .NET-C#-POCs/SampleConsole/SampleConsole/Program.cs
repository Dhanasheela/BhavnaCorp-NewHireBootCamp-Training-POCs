using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    class Program
    {
        public List<Employee> empDetail = new List<Employee>();

        //    static void Main(string[] args)
        //    {
        //        Console.WriteLine("enter option");
        //        int option =int.Parse(Console.ReadLine());
        //             //  int option1 = int.Parse(Console.ReadLine());

        //        int empId =0;
        //        string Ename="";
        //        switch (option )
        //        {
        //            case 1:
        //                 Console.WriteLine("enter Id");
        //                empId = int.Parse(Console.ReadLine());
        //                Console.WriteLine("Enter Employee Name");
        //                Ename = Console.ReadLine();
        //                goto case 2;
        //            case 2:
        //                Console.WriteLine("");
        //                Console.WriteLine("---Employee Details---");
        //                Console.WriteLine("Employee ID:" + empId + " Name:" + Ename);
        //                goto case 3 ;
        //            case 3:
        //                string s, revs = "";
        //                Console.WriteLine(" Enter string");
        //                s = Console.ReadLine();
        //                for (int i = s.Length - 1; i >= 0; i--) //String Reverse  
        //                {
        //                    revs += s[i].ToString();
        //                }
        //                if (revs == s) // Checking whether string is palindrome or not  
        //                {
        //                    Console.WriteLine("String is Palindrome \n Entered String Was {0} and reverse string is {1}", s, revs);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("String is not Palindrome \n Entered String Was {0} and reverse string is {1}", s, revs);
        //                }
        //                Console.ReadKey();
        //                break;
        //            default:
        //                Console.WriteLine("invalid input ");
        //                 break;
        //        }


        //    }
        public void MainCall(int option)
        {
            int result = 0;
            int empId1 = 0;
            switch (option)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    DisplayList();
                    int option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
                case 3:
                    Console.WriteLine("Enter EmployeeId which you want to update:");
                    empId1 = int.Parse(Console.ReadLine());
                    result = update(empId1);
                    break;
                case 4:
                    Console.WriteLine("Enter EmployeeId which you want to delete:");
                    empId1 = int.Parse(Console.ReadLine());
                    result = DeleteEmployee(empId1);
                    if (result == 1)
                        Console.WriteLine("Employee deleted");
                    else
                        Console.WriteLine("Employee with ID:" + empId1 + " not found");
                    option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
                case 5:
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Invalid Input!!!!!!Re-Enter");
                    option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
            }
        }
        /// Display Main menu

        public  int DisplayMainMenu()
        {
            Console.WriteLine("\nSelect any option:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display Employee");
            Console.WriteLine("3. Edit Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Exit");

            Int32 option = 0;
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Some Error Occured");
            }
            return option;
        }

        /// Add New Employee
       public List<Employee> AddEmployee()
        {
            Employee employee = new Employee();
            try
            {
                Console.WriteLine("Enter following information to add new Employee:");
                Console.WriteLine("Enter Name");
                employee.name = Console.ReadLine();
                Console.WriteLine("Enter Emp ID (Only Numeric)");
                employee.empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Contact(Only Numeric)");
                employee.contact = Convert.ToInt64(Console.ReadLine());
                if (empDetail.Count > 0)
                {
                    if (empDetail.Exists(emp => emp.empid == employee.empid))
                    {
                        Console.WriteLine("Employee already exists with id:" + employee.empid);
                    }
                    else
                    {
                        empDetail.Add(employee);
                    }
                }
                else
                {
                    empDetail.Add(employee);
                    Console.WriteLine("Employee successfully Added");
                }
                Console.WriteLine(@"Do you want to add more Employee? Y\N");
                char choice = Console.ReadKey().KeyChar;
                switch (Char.ToUpper(choice))
                {
                    case 'Y':
                        AddEmployee();
                        break;
                    case 'N':
                        Int32 option1 = DisplayMainMenu();
                        MainCall(option1);
                        break;
                    default:
                        Console.WriteLine("Some Error Occured!! Please select right option");
                        Console.WriteLine("-----------------------------------------------");
                        option1 = DisplayMainMenu();
                        MainCall(option1);
                        break;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some Error Occured!! Please select right option");
                Console.WriteLine("-----------------------------------------------");
                int option1 = DisplayMainMenu();
                MainCall(option1);
            }
            return empDetail;
        }


        /// Display Employee List
        public void DisplayList()
        {
            Console.WriteLine("");
            Console.WriteLine("-----------------------------Employee Detail---------------------------------------");
            foreach (Employee emp in empDetail)
            {
                Console.WriteLine("Employee ID:" + emp.empid + " Name:" + emp.name + " Contact:" + emp.contact);
            }
        }

        /// <summary>
        /// Update Existing employee information

        public int update(int empId)
        {
            int result = 0;
            Employee employee = new Employee();
            try
            {
                var empinfo = empDetail.Where(e => e.empid == empId).FirstOrDefault();
                if (empinfo != null)
                {
                    Console.WriteLine("Enter Name");
                    employee.name = Console.ReadLine();
                    Console.WriteLine("Enter Contact(Only Numeric)");
                    employee.contact = Convert.ToInt64(Console.ReadLine());
                    empDetail.Where(e => e.empid == empId).FirstOrDefault().name = employee.name;
                    empDetail.Where(e => e.empid == empId).FirstOrDefault().contact = employee.contact;
                    Console.WriteLine("Employee with id:" + empId + "updated successfully");
                    int option1 = DisplayMainMenu();
                    MainCall(option1);
                }
                else
                {
                    Console.WriteLine("Employee with id:" + empId + "does not exist");
                    int option1 = DisplayMainMenu();
                    MainCall(option1);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some Error Occured!! Please select right option");
                Console.WriteLine("-----------------------------------------------");
                int option1 = DisplayMainMenu();
                MainCall(option1);
            }
            return result;
        }

        /// Delete Existing Employee

        public int DeleteEmployee(int empid)
        {
            int result = empDetail.RemoveAll(e => e.empid == empid);
            return result;
        }
    }


}

