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
    public class Franchisee : IFranchisee
    {
        SqlConnection con = new SqlConnection("server=localhost;database=bhavnadb;Integrated Security=true;");
        SqlCommand sqlCommand;

        public string AddFranchisee(string role)
        {
                FranchiseeModel franchiseeModel = new FranchiseeModel();


            if (role == "admin")
            {
                Console.WriteLine("Enter admin Username");
                var username = Console.ReadLine();
                Console.WriteLine("Enter Admin Password");
                var password = Console.ReadLine();

                //stored procedures
                sqlCommand = new SqlCommand("CheckUser", con);
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
                    Console.WriteLine( "Login successful");
                    con.Close();
                    Console.WriteLine("Enter ur choice");
                Console.WriteLine("1:Add Franchisee");
                Console.WriteLine("2:Display Franchisee details");
                Console.WriteLine("3:Display Franchisee code wise");
                Console.WriteLine("4:Display Date Franchisee details");
                Console.WriteLine("5:Total Sales");
                // Console.WriteLine("6:continue y/n");
                Console.WriteLine("6:exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter following information to add new Franchisee:");
                        Console.WriteLine("Enter Employee Id");
                        franchiseeModel.emp_id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Franchisee username");
                        franchiseeModel.username = Console.ReadLine();

                        Console.WriteLine("Enter Franchisee Password");
                        franchiseeModel.password = Console.ReadLine();

                        Console.WriteLine("Enter Franchisee code");
                        franchiseeModel.code = Console.ReadLine();

                        Console.WriteLine("Enter Franchisee Date");
                       string f_date=franchiseeModel.franch_date = DateTime.Now.ToString(Console.ReadLine());

                            Console.WriteLine("Enter Franchisee sakes");
                            franchiseeModel.sales = int.Parse(Console.ReadLine());

                            con.Open();
                        SqlCommand cmd = new SqlCommand("insert into franchisee values(" + franchiseeModel.emp_id + ",'" + franchiseeModel.username + "','" + franchiseeModel.password + "','" + franchiseeModel.role + "','" + franchiseeModel.code + "','" + franchiseeModel.franch_date + "',"+franchiseeModel.sales+")", con);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserted Succesfull");
                        con.Close();
                        break;
                    case 2:
                        DisplayDetails();
                        break;
                    case 3:
                        Console.WriteLine("Enter Code");
                        string code = Console.ReadLine();
                        DisplayCodeWiseDetails(code);
                        break;
                    case 4:
                        Console.WriteLine("Enter Franchisee Date ");
                        DateTime franch_date = DateTime.Parse(Console.ReadLine());
                        DisplayDateDetails(franch_date);
                        break;
                    case 5:
                        Console.WriteLine("total sales");
                            Console.WriteLine("Enter username");
                            string username1 = Console.ReadLine();
                            TotalSales(username1);
                        break;
                    case 6:
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
            return "inserted succesfully";

        }
        public void DisplayDetails()
        {
            con.Open();
            sqlCommand = new SqlCommand("select * from franchisee", con);
            SqlDataReader sdr = sqlCommand.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("franchisee Id:" + sdr.GetValue(0) + "\n"+ "franchisee employee"+sdr.GetValue(1)+"\n" + "franchisee Username:" + sdr.GetValue(2) + "\n" + "franchisee  password :" + sdr.GetValue(3) + "\n" + "franchisee role:" + sdr.GetValue(4) + "\n" + "franchisee Code:" + sdr.GetValue(5)+"\n"+ "franchisee date"+sdr.GetValue(6));
            }
            con.Close();
        }
        public string DisplayCodeWiseDetails(string code)
        {

            try
            {
                con.Open();
                sqlCommand = new SqlCommand("select * from franchisee where code='" + code + "' ", con);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                        Console.WriteLine("franchisee Id:" + sdr.GetValue(0) + "\n" + "franchisee employee" + sdr.GetValue(1) + "\n" + "franchisee Username:" + sdr.GetValue(2) + "\n" + "franchisee  password :" + sdr.GetValue(3) + "\n" + "franchisee role:" + sdr.GetValue(4) + "\n" + "franchisee Code:" + sdr.GetValue(5) + "\n" + "franchisee date" + sdr.GetValue(6));

                    }
                    con.Close();
            }
            catch(Exception)
            {
                Console.WriteLine("Record is not found");
            }
            return "Record is found";
        }
        public string DisplayDateDetails(DateTime franch_date)
        {

            try
            {
                con.Open();
                sqlCommand = new SqlCommand("select * from franchisee where franch_date='" + franch_date + "' ", con);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
               Console.WriteLine("franchisee Id:" + sdr.GetValue(0) + "\n" + "franchisee employee" + sdr.GetValue(1) + "\n" + "franchisee Username:" + sdr.GetValue(2) + "\n" + "franchisee  password :" + sdr.GetValue(3) + "\n" + "franchisee role:" + sdr.GetValue(4) + "\n" + "franchisee Code:" + sdr.GetValue(5) + "\n" + "franchisee date" + sdr.GetValue(6));

                 }
                    con.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Record is not found");
            }
            return "Record is found";
        }

        public void TotalSales(string username1)
        {
            try
            {
                con.Open();
              
                sqlCommand = new SqlCommand("select  sales as Total_sales from franchisee where username='"+username1+"'  ", con);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                
                con.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Record is not found");
            }
           
        }
    }
}
