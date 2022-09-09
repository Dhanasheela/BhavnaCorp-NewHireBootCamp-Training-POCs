using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;


namespace FileConsoleApp
{
    class Program
    {
        static void Main(string[] args)
            {
            SqlConnection con = new SqlConnection("server=localhost;database=bhavnadb;Integrated Security=true;");

        startpoint: Console.WriteLine("-----------welcome to my project--------------------");
            Console.WriteLine("1-insert\n2-exit\n========================");
             string start = Console.ReadLine();
            if (start=="1")
            {
                Console.WriteLine("Enter  Paragraph");
                string para = Console.ReadLine();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into sample(para) values('" + para + "')", con);
                StreamWriter sw = new StreamWriter("sample.txt");
                sw.Write("Hi  welcome " + (Environment.NewLine) + para);
                sw.Close();
                cmd.ExecuteNonQuery();
                con.Close();

                Console.Clear();
                Console.WriteLine("===========================\nany text here\n\n========================\n*-Back ");
                string gostart = Console.ReadLine();
                if (gostart == "*")
                {
                    Console.Clear();
                    goto startpoint;
                }
            }
           
               else
                    if(start=="2")
                {
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("invalid option");
                }
            }
            

        }
    }

    
