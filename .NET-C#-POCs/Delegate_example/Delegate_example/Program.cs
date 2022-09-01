using System;
using System.Collections.Generic;

namespace Delegate_example
{
    public delegate void my_delegate(int x, int y);//declaring delegate
    delegate bool isPromote(Employee emp);
    public delegate FunDelegate Func<in T, out FunDelegate>(T arg);//function delegates

    public class emp
    {
        public  emp()
            {
            Console.WriteLine("constructor");
            }
        //~emp()
        //{
        //    string type = GetType().Name;
        //    Console.WriteLine($"Object {type} is Destroyed");

        //}
        public void Dispose()
        {
           Console.WriteLine($"Object is Destroyed");

        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            emp con = new emp();
            con.Dispose();
            emp con1 = new emp();
           
            //without delegates
            delegate_class obj1 = new delegate_class();
            obj1.add(3, 2);
            // with delegates
            my_delegate obj = new my_delegate(obj1.add);
            obj(3, 2);
            List<Employee> empl = new List<Employee>();
            empl.Add(new Employee() { ID = 101, Name = "Ravi", salary = 20000, Experiance = 3 });
            empl.Add(new Employee() { ID = 102, Name = "John", salary = 30000, Experiance = 5 });
            empl.Add(new Employee() { ID = 103, Name = "Mary", salary = 50000, Experiance = 8 });
            empl.Add(new Employee() { ID = 104, Name = "Mike", salary = 10000, Experiance = 2 });


            //function delegates 
            Console.WriteLine("---Function Delegates--");
            Func<int, int, int, int> funObj = fun_delegate.myFun;
            Console.WriteLine(funObj(10, 20, 30));

            ///action delegates
            Console.WriteLine("-----Action Delegates");
            Action<int, int, int> actionDelegatesObj = Action_Delegates.mul;
            actionDelegatesObj(10, 20, 30);


            //predicate delegates
            // Using predicate delegate
            // here, this delegate takes
            // only one parameter
            Console.WriteLine(" ");
            Console.WriteLine("---Predicate delegate----");
            Console.WriteLine("Predicate Delegates");
            Predicate<string> pro_obj=predict_delegates.Promote;
             Console.WriteLine(pro_obj("dhanu"));

        }
        


    }
    class delegate_class
    {
        public void add(int x, int y)
        {
            Console.WriteLine("add:" + (x + y));

        }

    }

    //sample example of  function delegates
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int salary { get; set; }
        public float Experiance { get; set; }

        public static List<Employee> PromoteEmp(List<Employee> list, isPromote IsEligible)
        {
            foreach (Employee emp in list)
            {
                if (emp.Experiance >= 5)
                {
                    Console.WriteLine("employee promoted" + emp.Name);
                }
            }
            return list;
        }
    }

    class fun_delegate
    {
        public static int myFun(int a, int b, int c)
        {
            return (a + b) / c;
        }
    }

    class Action_Delegates
    {
        public static void mul(int a, int b, int c)
        {
            Console.WriteLine("Multiply of a&b&c:" + (a * b * c));
        }
    }

    ///predicate delegate
    class predict_delegates
    {
        public static bool Promote(string str)
        {
            if (str.Length < 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}