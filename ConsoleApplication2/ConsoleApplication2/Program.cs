//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;
//namespace ConsoleApplication2
//{
    
//    class Program
//    {
//        public static bool[] Continue = {false,false,false};
//        public static int[] PSum = {0,0,0};
//        static void Main(string[] args)
//        {
         
//            // Initialization of Array 
//            Random randNum = new Random();
//            int[] array = Enumerable
//                    .Repeat(0, 300)
//                    .Select(i => randNum.Next(0, 100))
//                    .ToArray();
            
//            //foreach (int value in array)
//            //{
//            //    Console.WriteLine(value);
                
//            //}
//            //  Threads initialization
//            Thread t1 = new Thread(() => Sum(0, 100, array));
//            Thread t2 = new Thread(() => Sum(100, 200, array));
//            Thread t3 = new Thread(() => Sum(200, 300, array));
//            t1.Name = "0";
//            t2.Name = "1";
//            t3.Name = "2";
//            t1.Start();
//            t2.Start();
//            t3.Start();
//            //////////////////////
//            //t1.Join();
//            //t2.Join();
//            //t3.Join();
//            while (!Continue[1] || !Continue[2] || !Continue[0])
//            {
//            }
//            int TotalSum = PSum[0]+PSum[1]+PSum[2];
//            Console.WriteLine("Sum is " + TotalSum);
//            Console.ReadKey();

//        }
//        static void Sum(int StartIndex, int LastIndex, int[] input)
//        {
//            int j = Convert.ToInt32(Thread.CurrentThread.Name);
            
//            Console.WriteLine("Start with index "+ (j+1));
//            for (int i = StartIndex; i < LastIndex; i++)
//            {
//                PSum[j] += input[i];
//            }
//            Continue[j]=true;
//        }
//    }
//}
