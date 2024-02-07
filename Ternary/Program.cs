using System;

namespace Ternary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What day is it? ");
            string day = Console.ReadLine();
            string howToSpendTime;

            /*   if (day.ToLower().Equals("saturday"))
               {
                   howToSpendTime = "Relax";
               }
               else
               {
                   howToSpendTime = "Work";
               }
            */
            howToSpendTime = day.ToLower().Equals("saturday") ? "Relax" : "Work";
            Console.WriteLine($"{howToSpendTime} on {day}");
        }
    }
}
