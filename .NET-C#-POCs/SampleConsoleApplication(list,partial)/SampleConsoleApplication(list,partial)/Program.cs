using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleConsoleApplication_list_partial_
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            List<Employee> empList = new List<Employee>();

            empList.Add(new Employee() 
            { empid=101,ename= "dhanu", gender="female",salary=20000, company = "" });

            empList.Add(new Employee()
            { empid = 102, ename = "raki", gender = "male", salary = 30000, company = "" });

            empList.Add(new Employee()
            { empid = 103, ename = "sahi", gender = "female", salary = 25000, company = "" });
            empList.Add(new Employee()
            { empid = 104, ename = "manish", gender = "male", salary = 15000, company = "" });


            foreach (Employee emps in empList)
            {
                Console.WriteLine("Employee details:" +"\n"+ "employee id: "+emps.empid  + "\n" + "employee name: " 
                    + emps.ename+ "\n" + "employee gender: " + emps.gender + "\n" +"employee salary: " + emps.salary +"\n"+ "employee Company: "  + emps.company);
            }

           
                var empgen = empList.Where(e => e.gender== "female").ToList();
            foreach (Employee emps in empgen)
            {
                Console.WriteLine("-------------------"+"\n"+"Employees:" + emps.empid + "\n" + emps.ename + "\n" + emps.gender + "\n" + emps.salary);
            }
         
           
            
        }
    }
}
