using System;

namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 12;
            x *= 34;
            Console.WriteLine(x);

            int y = 12;
            y = y * 34;
            Console.WriteLine(y);

            int z = y -= 8;
            Console.WriteLine($"y is {y}, z is {z}");
        }
    }
}
