using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject
{

    public class Customer : ICustomer
    {
        public List<CustomerModel> empDetail = new List<CustomerModel>();
        SqlConnection con = new SqlConnection("server=localhost;database=bhavnadb;Integrated Security=true;");
        SqlCommand sqlCommand;
        CustomerModel customerModel = new CustomerModel();
        public List<CustomerModel> AddCustomer(string role)
        {

            try
            {

                if (role == "admin")
                {
                    Console.WriteLine("Enter Customer Name");
                    var email = Console.ReadLine();
                    Console.WriteLine("Enter Customer Password");
                    var password = Console.ReadLine();
                    con.Open();
                    sqlCommand = new SqlCommand("select * from customer where email='" + email + "' and password='" + password + "'", con);
                    SqlDataReader sdr = sqlCommand.ExecuteReader();
                    //while(sdr.Read())
                    //{
                    //    Console.WriteLine("Customer Email:" + sdr.GetValue(1) + "\n" + "Customer Password" + sdr.GetValue(3) + "\n");
                    //}
                    con.Close();
                    Console.WriteLine("Enter ur choice");
                    Console.WriteLine("1:Add Customer");
                    Console.WriteLine("2:Delete Customer");
                    Console.WriteLine("3:Display Customer");
                    Console.WriteLine("4:Update customer");
                    Console.WriteLine("5:display trigger customer");
                    Console.WriteLine("6:exit");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter following information to add new Employee:");
                            Console.WriteLine("Enter Customer Email");
                            customerModel.email = Console.ReadLine();
                            Console.WriteLine("Enter Customer Account number(Only Numeric)");
                            customerModel.acco_no = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Customer Password");
                            customerModel.password = Console.ReadLine();
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into customer values('" + customerModel.email + "'," + customerModel.acco_no + ",'" + customerModel.password + "','" + customerModel.role + "')", con);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Inserted Succesfull");
                            con.Close();
                            break;
                        case 2:
                            Console.WriteLine("Enter custometId which you want to delete:");
                            int customerid = int.Parse(Console.ReadLine());
                            DeleteCustomer(customerid);
                            break;
                        case 3:
                            DisplayList();
                            break;
                        case 4:
                            Console.WriteLine("Enter custometId which you want to Update:");
                            int id = int.Parse(Console.ReadLine());
                            UpdateCustomer(id);
                            break;
                        case 5:
                            DisplayTriggerList();
                            break;
                        case 6:
                            Console.WriteLine("");
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;

                    }
                }

                else if (role != "admin")
                {
                    Console.WriteLine("Ur not admin");

                }
                else
                {
                    Console.WriteLine("Invalid Credentials");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Inserted failed" + e);
            }

            return empDetail;
        }

        public int DeleteCustomer(int customerid)
        {
            sqlCommand = new SqlCommand("delete from customer where customer_id=" + customerid + "", con);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Customer with id:" + customerid + "\n" + "Deleted successfully");
            con.Open();
            return customerid;
        }

        public void DisplayList()
        {
            con.Open();
            sqlCommand = new SqlCommand("select * from customer", con);
            SqlDataReader sdr = sqlCommand.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Customer Id:" + sdr.GetValue(0) + "\n" + "customer email:" + sdr.GetValue(1) + "\n" + "customer  acc_no :" + sdr.GetValue(2) + "\n" + "Customer password:" + sdr.GetValue(3) + "\n" + "Customer Role:" + sdr.GetValue(4));
            }
            con.Close();
        }

        public int UpdateCustomer(int customerid)
        {
            int result = 0;

            try
            {
                Console.WriteLine("Enter following information to add new Employee:");
                Console.WriteLine("Enter Customer Email");
                customerModel.email = Console.ReadLine();
                //Console.WriteLine("Enter Customer Account number(Only Numeric)");
                //customerModel.acco_no = int.Parse(Console.ReadLine());
                //Console.WriteLine("Enter Customer Password");
                //customerModel.password = Console.ReadLine();
                con.Open();
                SqlCommand cmd = new SqlCommand("update customer set email='" + customerModel.email + "' where customer_id=" + customerid + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Customer with id:" + customerid + "\n" + "updated successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Update Failed");
            }
            return result;
        }
        public void DisplayTriggerList()
        {
            con.Open();
            sqlCommand = new SqlCommand("select * from customer_test", con);
            SqlDataReader sdr = sqlCommand.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("customer trigger Cid:" + sdr.GetValue(0) + "\n" + "customer trigger customer_id :" + sdr.GetValue(1) + "\n" + "Customer trigger operation:" + sdr.GetValue(2) + "\n" + "Customer trigger date:" + sdr.GetValue(3) + "----------");
            }
            con.Close();
        }
    }
}
