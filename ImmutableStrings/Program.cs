using System;
using System.Text;

namespace ImmutableStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder first = new StringBuilder("This is a string");
            StringBuilder second = new StringBuilder("This is a string");

            Console.WriteLine($"first:  {first}");

            Console.WriteLine("Clearing first...");
            //first.Length = 0;
            //Console.WriteLine($"first:  *{first}*");

            //first.Append("Another string");
            first.Clear();
            first.Append("Another string");
            first.Clear().Append("Another string").Append(" ").Append(second);
            Console.WriteLine($"First: *{first}*");
        }
    }
}