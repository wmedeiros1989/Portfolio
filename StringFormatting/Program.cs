using System;

namespace StringFormatting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*   string apples = "Apples";
               int appleQuantity = 8;
               int applePrice = 100;
               string orange = "Oranges";
               int orangeQuantity = 12;
               int orangePrice = 80;

               string column1Heading = "Fruit";
               string column2Heading = "Quantity";
               string column3Heading = "Price";

               Console.WriteLine($"{column1Heading, -12} {column2Heading, 8} {column3Heading, 6}");
               Console.WriteLine($"{apples, -12} {appleQuantity, -8} {applePrice / 100.0, 6:C}");
               Console.WriteLine($"{orange,-12} {orangeQuantity,-8} {orangePrice / 100.0, 6:C}");
            */

            Console.WriteLine($"PI is {Math.PI}");
            Console.WriteLine($"PI is {Math.PI:F3}");
            Console.WriteLine($"PI is {Math.PI:F0}");
            Console.WriteLine($"PI is {Math.PI:F12}");
            Console.WriteLine($"PI is {Math.PI:F99}");

        }
    }
}
