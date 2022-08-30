using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    public class Employee : IEmployee
    {
        public List<EmployeeModel> empDetail = new List<EmployeeModel>();
        SqlConnection con = new SqlConnection("server=localhost;database=bhavnadb;Integrated Security=true;");
        SqlCommand sqlCommand;
        SqlDataAdapter sqlData;

        public List<EmployeeModel> AddEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            try
            {
                Console.WriteLine("Enter following information to add new Employee:");
                Console.WriteLine("Enter Name");
                employeeModel.name = Console.ReadLine();
                Console.WriteLine("Enter Contact(Only Numeric)");
                employeeModel.contact = Convert.ToInt64(Console.ReadLine());
                SqlCommand cmd = new SqlCommand("insert into employee values('" + employeeModel.name + "'," + employeeModel.contact + ")", con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Inserted Succesfull");
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Inserted failed" + e);
            }

            return empDetail;
        }


        public int update(int empId)
        {
            int result = 0;
            EmployeeModel employee = new EmployeeModel();
            try
            {                
                    Console.WriteLine("Enter Name");
                    employee.name = Console.ReadLine();
                    Console.WriteLine("Enter Contact(Only Numeric)");
                    employee.contact = Convert.ToInt64(Console.ReadLine());
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update employee set name='" + employee.name + "',contact=" + employee.contact + " where empid=" + empId + "",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Employee with id:" + empId +"\n" + "updated successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Update Failed");
            }
            return result;
        }
        public int DeleteEmployee(int empid)
        {
            sqlCommand = new SqlCommand("delete from employee where empid=" + empid + "",con);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Employee with id:" + empid + "\n" + "Deleted successfully");
            con.Open();
            return empid;
        }

        public void DisplayList()
        {
            con.Open();
            sqlCommand = new SqlCommand("select * from employee", con);
            SqlDataReader sdr = sqlCommand.ExecuteReader();
            while(sdr.Read())
            {
               Console.WriteLine("Employee Id:"+sdr.GetValue(0)+"\n"+"Employee Name:"+sdr.GetValue(1) + "\n" + "Employee Contact:"+sdr.GetValue(2) + "\n");
            }
            con.Close();
        }

        public List<EmployeeModel> Search(string name)
        {
            var empList = new List<EmployeeModel>();
            con.Open();
            sqlCommand = new SqlCommand("select * from employee where name Like  '%"+ name +"%'  ", con);
            SqlDataReader sdr = sqlCommand.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Employee Id:" + sdr.GetValue(0) + "\n" + "Employee Name:" + sdr.GetValue(1) + "\n" + "Employee Contact:" + sdr.GetValue(2) + "\n");
            }
            con.Close();
            return empList;
        }
    }
}
