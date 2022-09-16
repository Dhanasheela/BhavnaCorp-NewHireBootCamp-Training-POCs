using System;
using System.Threading;

namespace ThreadSampleExampleApp
{
    class Program
    {
        // Parameters:
        //   obj:
        //     An object that contains data for the thread procedure.
        public delegate void ThreadStart(object? str);
        private static void thread1()
        {
             for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine("thread1 is in progress!!!");
                    Thread.Sleep(2000);

                }
            
            Console.WriteLine("thread ends..");
        }
        private static void thread2()
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("thread2 is in progress!!!");
                Thread.Sleep(1000);

            }
            Console.WriteLine("thread ends..");
        }
       void print(object? str)
        {
            Console.WriteLine("string:" + str);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("thread starts");
            Thread t1 = new Thread(thread1);
            Thread t2 = new Thread(thread2);
           
            t2.Start();
            t1.Start();

            Console.WriteLine($"thread name{t1.Name}");
            Console.WriteLine($"thread name{t1.Priority}");
            Console.WriteLine($"thread name{t1.IsAlive}");
            Console.WriteLine($"thread name{t1.IsBackground}");
            Console.WriteLine($"thread name{t1.ManagedThreadId}");

            //delegates
            Program pr = new Program();
       
            Thread th3 = new Thread(new ParameterizedThreadStart(pr.print));
                       th3.Start("hello");
            Thread th4 = new Thread(pr.print);
            th4.Start("hi");

            //lock
            int i=0;
            object locker = new();
            for (int x = 1; x <= 5; x++)
            {
                Thread Thread = new(Print);
                Thread.Name = $"Thread {x}";
                Thread.Start();
            }
            void Print()
            {
                //lock statement is used,
                 //when lock block completes execution then only it goes into another block
                lock (locker)
                {
                    i = 1;
                    for (int x = 1; x <= 5; x++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                        i++;
                        Thread.Sleep(100);
                    }
                }
                Console.WriteLine("thread ends..");
            }
        }
    }


    

}
