﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionProject
{
    public class Category : ICategory
    {
        SqlConnection con = new SqlConnection("server=localhost;database=bhavnadb;Integrated Security=true;");
        SqlCommand sqlCommand;
        CategoryDetails categoryModel = new CategoryDetails();
        List<CategoryDetails> catList = new List<CategoryDetails>();
        public string AddCat(string role)
        {
            
            if (role == "category")
            {
               
                Console.WriteLine("Enter ur choice");
                Console.WriteLine("1:Add category");
                Console.WriteLine("2:Delete category");
                Console.WriteLine("3:Display category");
                Console.WriteLine("4:Update category");
                Console.WriteLine("5:exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter following information to add new Category:");
                        Console.WriteLine("Enter category name");
                        categoryModel.cname = Console.ReadLine();
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into category values('" + categoryModel.cname + "')", con);
                        cmd.ExecuteNonQuery();
                       // Console.WriteLine("Inserted Succesfull");
                        con.Close();
                        break;
                    case 2:
                        Console.WriteLine("Enter categoryId which you want to delete:");
                        int cid = int.Parse(Console.ReadLine());
                        Action<int> action = new Action<int>(DeleteCat);
                        action(cid);
                        break;
                    case 3:
                        DisplayList();
                        break;
                    case 4:
                        Console.WriteLine("Enter categoryId which you want to Update:");
                        int id = int.Parse(Console.ReadLine());
                        UpdateCat(id);
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
                Console.WriteLine("ur not admin");
            }
            return "inserted successfully";
        }


    public void DeleteCat(int cid)
    {
            sqlCommand = new SqlCommand("delete from category where cid=" + cid + "", con);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("category with id:" + cid + "\n" + "Deleted successfully");
            con.Open();
        }

    public void DisplayList()
    {
            con.Open();
            sqlCommand = new SqlCommand("select * from category", con);
            SqlDataReader sdr = sqlCommand.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Category Id:" + sdr.GetValue(0) + "\n" + "category name:" + sdr.GetValue(1) );
            }
            con.Close();
        }

    public int UpdateCat(int cid)
    {
           int result = 0;

            try
            {
                Console.WriteLine("Enter following information to add new Employee:");
                Console.WriteLine("Enter category Email");
                categoryModel.cname = Console.ReadLine();
                con.Open();
                SqlCommand cmd = new SqlCommand("update category set cname='" + categoryModel.cname + "' where cid=" + cid + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("category with id:" + cid + "\n" + "updated successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Update Failed");
            }
            return result;
    }

}
}
