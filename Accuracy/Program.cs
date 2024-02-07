using System;

namespace Accuracy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //double result1 = 0.1 * 7;
            //double result2 = 0.1 + 0.1 + 0.1 + 0.1 + 0.1 + 0.1 + 0.1;

            //Console.WriteLine($"1st result is {result1:R}");
            //Console.WriteLine($"2nd result is {result2:R}");

            //double difference = result1 - result2;
            //Console.WriteLine($"The difference is {difference:R}");

            decimal result1 = 0.1m * 7m;
            decimal result2 = 0.1m + 0.1m + 0.1m + 0.1m + 0.1m + 0.1m + 0.1m;

            Console.WriteLine($"1st result is {result1}");
            Console.WriteLine($"2nd result is {result2}");

            decimal difference = result1 - result2;
            Console.WriteLine($"The difference is {difference}");

            bool checkResult = result1 - result2 == 0;

        }
    }
}
