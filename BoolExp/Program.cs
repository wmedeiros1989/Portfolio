using System;

namespace BoolExp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int apples = 6;
            int oranges = 9;
            decimal applePrice = 12.60m;
            decimal orangePrice = 4.50m;

            bool moreApples;
            bool applesAreDearer;
            
            moreApples = (apples > oranges);
            applesAreDearer = (applePrice > orangePrice);
            Console.WriteLine($"We have more apples: {moreApples}");
            Console.WriteLine($"Apples are dearer: {applesAreDearer}");

            // Console.WriteLine($"Reducing apple cost: {moreApples && applesAreDearer}");
            // Console.WriteLine($"Reducing apple cost: {moreApples || applesAreDearer}");

            bool moreApplesAndDearer = moreApples && applesAreDearer;
            bool moreApplesOrDearer = moreApples || applesAreDearer;
            Console.WriteLine($"Reducing apple Cost: {moreApplesAndDearer}");
            Console.WriteLine($"Reducing apple Cost: {moreApplesOrDearer}");

            bool trueValue = true;
            bool falseValue = false;

        }
    }
}
