using System;

namespace SampleUnitTest
{
    public class Sample
    {
        public int factorial(int num)
        {
            int fact = 1, i = 1;
            while (i <= num) //2<5
            {
                fact = fact * i;//1=1*5
                i++;

                Console.WriteLine($"fact number {fact}*{i}= is:" + fact);

            }
            return fact;
        }

        public bool  Prime(string str)
        {
            if (str.Length % 2 == 0)
            {
                Console.WriteLine("it is prime");
                return true;

            }
            else
               Console.WriteLine("not prime");
                return false;
                
        }
    }
}
