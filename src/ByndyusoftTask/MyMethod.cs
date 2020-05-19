using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ByndyusoftTask
{
    public class MyMethod
    {
        public static void Main(string[] args)
        {
            int[] testArray = new int[100000000];
            Random randNum = new Random();
            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = randNum.Next(-1000, 1000);
            }

            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            Stopwatch stopwatch3 = new Stopwatch();
            Stopwatch stopwatch4 = new Stopwatch();

            Console.WriteLine("The four functions with different ways of task resolving were developed.");
            Console.WriteLine("This section tests the productivity of each function.");
            Console.WriteLine();

            Console.WriteLine("Function1:");
            stopwatch1.Start();
            var result1 = SumMinArrayElements1(testArray);
            Console.WriteLine(result1);
            Console.WriteLine(stopwatch1.Elapsed.ToString());
            Console.WriteLine("=============================");

            Console.WriteLine("Function2:");
            stopwatch2.Start();
            var result2 = SumMinArrayElements2(testArray);
            Console.WriteLine(result2);
            Console.WriteLine(stopwatch2.Elapsed.ToString());
            Console.WriteLine("=============================");

            Console.WriteLine("Function3:");
            stopwatch3.Start();
            var result3 = SumMinArrayElements3(testArray);
            Console.WriteLine(result3);
            Console.WriteLine(stopwatch3.Elapsed.ToString());
            Console.WriteLine("=============================");

            Console.WriteLine("Function4:");
            stopwatch4.Start();
            var result4 = SumMinArrayElements4(testArray);
            Console.WriteLine(result4);
            Console.WriteLine(stopwatch4.Elapsed.ToString());
            Console.WriteLine("=============================");
            Console.WriteLine("=============================");

            Console.WriteLine("RESULT: Function3 is more effective than others, so we will perform Unit Tests only for Function3.");
            Console.ReadKey();
        }
              
        public static int SumMinArrayElements1(int[] array)
        {
            ArrayLengthChecking(array);

            return array.OrderBy(el => el).Take(2).Sum();
        }
        public static int SumMinArrayElements2(int[] array)
        {
            ArrayLengthChecking(array);

            var listFromArray = array.ToList();
            var min1 = listFromArray.Min();

            listFromArray.Remove(min1);

            var min2 = listFromArray.Min();

            return min1 + min2;
        }
        public static int SumMinArrayElements3(int[] array)
        {
            ArrayLengthChecking(array);

            var listFromArray = array.ToList();
            int min1 = listFromArray[0];
            int min2 = listFromArray[1];
            if (min1 > min2)
            {
                int buffer = min2;
                min2 = min1;
                min1 = buffer;
            }

            for (int i = 2; i < array.Length; i++)
            {
                if (array[i] < min1)
                {
                    min2 = min1;
                    min1 = array[i];
                }
                else if (array[i] < min2)
                {
                    min2 = array[i];
                }
            }
           return min1 + min2;
        }
        public static int SumMinArrayElements4(int[] array)
        {
            ArrayLengthChecking(array);

            var min1 = array.Min();
            var min4_1_index = array.ToList().IndexOf(min1);
            array[min4_1_index] = array.Max();
            var min4_2 = array.Min();
            return min1 + min4_2;
        }

        private static void ArrayLengthChecking(int[] array)
        {
            if (array.Length < 2)
            {
                throw new Exception("Not enough elements in array.");
            }
        }
    }
}
