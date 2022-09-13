using CAR_ManufacturingApp.Domain.Entities;
using CAR_ManufacturingApp.Domain.Enums;
using CAR_ManufacturingApp.Domain.Interfaces;
using CAR_ManufacturingApp.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR_ManufacturingApp.App
{
    public class AppCar:IEmployee
    {
        private List<EmployeeModel> employeeModels;
        private EmployeeModel employee;
        SqlConnection con = new SqlConnection("server=localhost;database=carManufacture;Integrated Security=true;");
        SqlCommand sqlCommand;
        EmployeeModel employeeModel = new EmployeeModel();

        public void InitializeData()
        {
            Console.WriteLine("employee");
            Console.WriteLine("enter employee name");employeeModel.emp_name= Console.ReadLine();
            Console.WriteLine("Enter Employee password:"); employeeModel.password = Console.ReadLine();
            Console.WriteLine("Eter ur shift :"); employeeModel.shift_type = Console.ReadLine();
            Console.WriteLine("Enter ur depart name:"); employeeModel.depart_name=Console.ReadLine();
            Console.WriteLine("enter number of workings days: "); employeeModel.working_days = int.Parse(Console.ReadLine());
            Console.WriteLine("enter salary date :");employeeModel.sal_date = Console.ReadLine();
            Console.WriteLine("enter salary :");employeeModel.salary =int.Parse(Console.ReadLine());
            con.Close();

            con.Open();

            SqlCommand cmd = new SqlCommand("insert into employees values('" + employeeModel.emp_name + "','" + employeeModel.password + "','" + employeeModel.shift_type+ "','" + employeeModel.depart_name + "'," + employeeModel.working_days + ",'"+employeeModel.sal_date+"'," + employeeModel.salary + ",'" + employeeModel.role + "')", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserted Succesfull");
           // Run();
            con.Close();

            
        }
        public void Run()
        {
            AppScreen.Welcome();

            AppScreen.WelcomeEmployee(employeeModel.emp_name);
            while (true)
            {
                AppScreen.DisplayAppMenu();
                ProcessMenuoption();
            }
        }

      

        public void CheckEmpNameAndPassword()
        {
            try
            {
                Console.WriteLine("Enter Employee Username");
                var username = Console.ReadLine();
                Console.WriteLine("Enter Employee Password");
                var password = Console.ReadLine();

                //stored procedures
                sqlCommand = new SqlCommand("LoginEmployee ", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("emp_name", username);
                SqlParameter p2 = new SqlParameter("password", password);
                sqlCommand.Parameters.Add(p1);
                sqlCommand.Parameters.Add(p2);

                con.Open();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    Console.WriteLine("Login successful");
                    
                }
                con.Close();
            }
            catch(Exception)
            {
                Console.WriteLine("invalid credetinal");
            }

        }

       
        public string SalaryDistribution()
        {
            try
            {
                Console.WriteLine("Enter ur employee  Department");
                string Department = Console.ReadLine();

                con.Open();

                //adding 2*sal salary for every employee based on emp_role 
                sqlCommand = new SqlCommand("select sum(salary*working_days) as Total_salary from employees " +
                    "where depart_name='" + Department + "'", con);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine("Employees sum of salaries:" + sdr.GetValue(0));

                }
                con.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Record is not found");
            }
            return "Record is found";

        }
        public string PurchaseCarDetails()
        {
            try
            {
                Console.WriteLine("Enter ur Car name");
                string car = Console.ReadLine();

                con.Open();

                //adding 2*sal salary for every employee based on emp_role 
                sqlCommand = new SqlCommand("select *  from car " +
                    "where car_name='" + car + "'", con);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine("Car Name:" + sdr.GetValue(1)+"\n Car price:"+sdr.GetValue(2)+"\n Car Parts"+sdr.GetValue(3)+"\n Car stocks "+sdr.GetValue(4)+"\n Car Purchased date "+sdr.GetValue(5));

                }
                con.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Record is not found");
            }
            return "Record is found";

        }
        public void PurchaseNewCar()
        {
            ProductModel productModel = new ProductModel();
            Console.WriteLine("enter Car name"); productModel.car_name = Console.ReadLine();
            Console.WriteLine("Enter Car price:"); productModel.car_price=float.Parse( Console.ReadLine());
            Console.WriteLine("enter Car Parts: "); productModel.car_parts = Console.ReadLine();
            Console.WriteLine("enter Car Stocks :"); productModel.car_stocks=int.Parse( Console.ReadLine());
            Console.WriteLine("enter Date:");productModel.purchased_date = Console.ReadLine();
            Console.WriteLine("Employee Name:");productModel.emp_name = Console.ReadLine();

            con.Close();

            con.Open();

            SqlCommand cmd = new SqlCommand("insert into employees values('" + productModel.car_name + "',"+productModel.car_price+",'"+productModel.car_parts+"',"+productModel.car_stocks+",'"+productModel.purchased_date+"','"+productModel.emp_name+"')", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserted Succesfull");
            // Run();
            con.Close();


        }
        public string MonthlyWiseCars()
        {

            try
            {
                Console.WriteLine("Enter date to know the purchased cars:");string date = Console.ReadLine();
                con.Open();
                sqlCommand = new SqlCommand("select * from car where purchased_date='" + date + "' ", con);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine("Car Name:" + sdr.GetValue(1) + "\n Car price:" + sdr.GetValue(2) + "\n Car Parts" + sdr.GetValue(3) + "\n Car stocks " + sdr.GetValue(4) + "\n Car Purchased date " + sdr.GetValue(5)+"\n Employee name:"+sdr.GetValue(6));


                }
                con.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Record is not found");
            }
            return "Record is found";
        }
        private void ProcessMenuoption()
        {
            switch (Validator.Convert<int>("an option:"))
            {
                case (int)AppMenu.AddEmployee:
                    InitializeData();
                    AppScreen.PrintMessage("You have Registered successfully . ");
                    Run();
                    break;
                case (int)AppMenu.salarydistrubution:
                    SalaryDistribution();
                    AppScreen.PrintMessage("Your Salary Details. ");
                    Run();
                    break;
                case (int)AppMenu.PurchaseNewCar:
                    PurchaseNewCar();
                    AppScreen.PrintMessage("Your Purchased Car successfully;. ");
                    Run();
                    break;
                case (int)AppMenu.PurchasedCarDetails:
                    PurchaseCarDetails();
                    AppScreen.PrintMessage("Your Purchased Car Details. ");
                    Run();
                    break;
                case (int)AppMenu.MonthlyWiseCars:
                    MonthlyWiseCars();
                    AppScreen.PrintMessage("Your Purchased Car Details. ");
                    Run();
                    break;
                case (int)AppMenu.Logout:
                    AppScreen.LogoutProgress();
                    AppScreen.PrintMessage("You have successfully logged out. ");
                    Run();
                    break;
            }
        }
    }
}
