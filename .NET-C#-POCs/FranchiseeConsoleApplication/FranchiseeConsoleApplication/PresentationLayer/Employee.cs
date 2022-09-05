using FranchiseeConsoleApplication.Interfaces;
using FranchiseeConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeConsoleApplication.PresentationLayer
{
    public class Employee:IFranchiseeEmployee
    {
        SqlConnection con = new SqlConnection("server=localhost;database=bhavnadb;Integrated Security=true;");
        SqlCommand sqlCommand;
        public void AddEmployee(string role)
        {
            EmployeeModel employeeModel = new EmployeeModel();


            if (role == "franchisee")
            {
                Console.WriteLine("Enter Employee Username");
                var username = Console.ReadLine();
                Console.WriteLine("Enter Employee Password");
                var password = Console.ReadLine();

                //stored procedures
                sqlCommand = new SqlCommand("CheckFranchiseeUser", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("username", username);
                SqlParameter p2 = new SqlParameter("password", password);
                sqlCommand.Parameters.Add(p1);
                sqlCommand.Parameters.Add(p2);

                con.Open();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    Console.WriteLine("Login successful");
                    con.Close();
                    Console.WriteLine("Enter ur choice");


                    Console.WriteLine("1:Employee Registration");
                    Console.WriteLine("2:Salary Distribution");
                    Console.WriteLine("3:Pizza Sales offline or online date wiserole");
                    Console.WriteLine("4:exit");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter following information to add new Franchisee:");
                            Console.WriteLine("Enter Employee username");
                            employeeModel.username = Console.ReadLine();

                            Console.WriteLine("Enter Employee Password");
                            employeeModel.password = Console.ReadLine();

                            Console.WriteLine("Enter Employee role");
                            employeeModel.emp_role = Console.ReadLine();

                           
                            Console.WriteLine("Enter Employee pizza Id");
                            employeeModel.pizza_id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Employee salary");
                            employeeModel.salary = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Employee date");
                           string date= employeeModel.date = DateTime.Now.ToString( Console.ReadLine());



                            con.Open();

                            SqlCommand cmd = new SqlCommand("insert into franch_employee values('" + employeeModel.username + "','" + employeeModel.password + "','" + employeeModel.emp_role + "','" + employeeModel.role + "'," + employeeModel.pizza_id + "," + employeeModel.salary + ",'"+employeeModel.date+"')", con);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Inserted Succesfull");
                            con.Close();
                            break;
                        case 2:
                             SalaryDistribution();
                            break;
                        case 3:
                            Console.WriteLine("Enter ur Pizza  sales offline or online");
                            string sale = Console.ReadLine();
                            PizzaSales(sale);
                            break;
                        case 4:
                            Console.WriteLine("");
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Login unsuccessful");

                }

            }
            else
            {
                Console.WriteLine("ur not admin ");
            }


        }

        public string PizzaSales(string salestype)
        {
            try
            {
                con.Open();

                //displaying pizza according to their sales type ie., offline or online
                sqlCommand = new SqlCommand("select *  from pizza  " +
                    "where pizza_sales_type='" + salestype + "' ", con);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while(sdr.Read())
                {
                    Console.WriteLine("Pizza Name:" + sdr.GetValue(1) + "\n" + "Pizza Type Sales: " + sdr.GetValue(2) + "\n" + "pizza Date:" + sdr.GetValue(3));
                }
                con.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Record is not found");
            }
            return "Record is found";
        }

        public string SalaryDistribution()
        { 
            try
            {
                Console.WriteLine("Enter ur employee  role");
                string role = Console.ReadLine();
               
                con.Open();

                //adding 2*sal salary for every employee based on emp_role 
                sqlCommand = new SqlCommand("select sum(2*salary) as Total_salary from franch_employee " +
                    "where emp_role='" + role + "'", con);
                SqlDataReader sdr= sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine("Employees sum of sales:" + sdr.GetValue(0));

                }
                con.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Record is not found");
            }
            return "Record is found";
           
        }
    }
}
