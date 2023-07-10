using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApplication2
{

    class Program
    {
        public static int[] PSum;
        static void Main(string[] args)
        {
            Console.WriteLine("Array length: ");
            int len = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("range of random numbers: ");

            int range = Convert.ToInt32(Console.ReadLine()); ;
            // Initialization of Array 
            Random randNum = new Random();
            int[] array = Enumerable
                    .Repeat(0, len)
                    .Select(i => randNum.Next(1, range))
                    .ToArray();

            for (int h = 0; h < len; h++) {
                Console.WriteLine(h+" "+ array[h]);
            }
                //  Threads initialization

                Console.WriteLine("Number of Thread you want to use: ");

            int ThreadNum = Convert.ToInt32(Console.ReadLine());
            PSum = new int[ThreadNum];
            
            for (int k = 0; k < ThreadNum; k++)
            {
                PSum[k] = 0;
            }
           
            Thread[] Threads = new Thread[ThreadNum];
            for (int k = 0; k < ThreadNum; k++)
            {
                int tmp = k;
                Threads[k] = new Thread(() => Sum(tmp, (len * tmp / ThreadNum), (len * (tmp + 1) / ThreadNum), array));
                Threads[k].Start();
                

            }

            int TotalSum = 0;
            for (int n = 0; n < ThreadNum; n++)
            {
                Threads[n].Join();
                TotalSum += PSum[n];
            }
            Console.WriteLine("Sum is " + TotalSum);
            Console.ReadKey();

        }
        static void Sum(int ThID, int start, int last, int[] input)
        {
           
            Console.WriteLine("Thread "+ThID+"  "+start+"  "+last);
            for (int i =start; i < last; i++)
            {
                Console.WriteLine("Thread " + (ThID + 1));
                PSum[ThID] += input[i];
                Console.WriteLine(PSum[ThID]);
            }
        }
    }
}
