using System;

namespace BasicConsoleApplication
{
    class BaseClass
    {
        public virtual int Add(int num1, int num2)
        {
            return (num1 + num2);
        }
    }

    class ChildClass : BaseClass
    {
        public override int Add(int num1, int num2)
        {
            if (num1 <= 0 || num2 <= 0)
            {
                Console.WriteLine("Values could not be less than zero or equals to zero");
                Console.WriteLine("Enter First value : ");
                num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter First value : ");
                num2 = Convert.ToInt32(Console.ReadLine());
            }
            return (num1 + num2);
        }
    }
    class ArmstrongNum
    {
        
    }
    class Program
    { 
        static void Main(string[] args)
        {
            //armstrong
            int n1, r, sum2 = 0, temp;
            Console.Write("Enter the Number= ");
            n1 = int.Parse(Console.ReadLine());
            temp = n1;
            while (n1 > 0)
            {
                r = n1 % 10;
                sum2 = sum2 + (r * r * r);
                n1 = n1 / 10;
            }
            if (temp == sum2)
                Console.Write("Armstrong Number.");
            else
                Console.Write("Not Armstrong Number.");


            //sum of left diagonal matrix
            int i, j, sum = 0, n, m = 0;
            int[,] arr1 = new int[50, 50];


            Console.Write("\n\nFind the sum of left diagonals of a matrix :\n");
            Console.Write("--------------------------------------------\n");

            Console.Write("Input the size of the square matrix : ");
            n = Convert.ToInt32(Console.ReadLine());
            m = n;
            Console.Write("Input elements in the matrix :\n");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("element - [{0}],[{1}] : ", i, j);
                    arr1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.Write("The matrix is :\n");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                    Console.Write("{0}  ", arr1[i, j]);
                Console.Write("\n");
            }
            // calculate the sum of left diagonals
            for (i = 0; i < n; i++)
            {
                m = m - 1;
                for (j = 0; j < n; j++)
                {
                    if (j == m)
                    {
                        sum = sum + arr1[j, i];

                    }
                  

                }
            }


            Console.Write("Addition of the  left Diagonal elements is :{0}\n", sum);

            int k, l, sum1 = 0, num;
            int[,] arr = new int[50, 50];

            Console.Write("Input the size of the square matrix : ");
            num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input elements in the first matrix :\n");
            for (k = 0; k < num; k++)
            {
                for (l= 0; l < num; l++)
                {
                    Console.Write("element - [{0}],[{1}] : ", k, l);
                    arr[k, l] = Convert.ToInt32(Console.ReadLine());
                    if (k == l) sum1 = sum1 + arr[k, l];
                }
            }
            Console.Write("The matrix is :\n");

            for (k = 0; k < num; k++)
            {
                for (l= 0; l< num; l++)
                    Console.Write("{0} ", arr[k, l]);
                Console.Write("\n");
            }

            Console.Write("Addition of the  right Diagonal elements is :{0}\n", sum1);

            //overloading
            BaseClass obj = new BaseClass();
            Console.WriteLine("Base class method Add :" + obj.Add(-3, 8));
            obj = new ChildClass();
            Console.WriteLine("Child class method Add :" + obj.Add(-2, 2));
            Console.ReadLine();

            
        }
    }
}
