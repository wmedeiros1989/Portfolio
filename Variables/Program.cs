using System;
using System.Globalization;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();

            int firstNumber = randomNumber.Next(2, 10);
            int secondNumber = randomNumber.Next(2, 10);

            var subtraction = randomNumber.Next(2, 10);

            int answer = firstNumber * secondNumber - subtraction;
            string prompt = ". Don't type in the answer just press ENTER when ready";

            Console.WriteLine("Think of a number between 1 and 10" + prompt);
            Console.ReadKey();
            Console.WriteLine("Multiply your number by " + firstNumber + prompt);
            Console.ReadKey();
            Console.WriteLine("Now multiply the result by " + secondNumber + prompt);
            Console.ReadKey();
            Console.WriteLine("Divide the result by the number you originally thought of" + prompt);
            Console.ReadKey();
            Console.WriteLine("Now subtract " + subtraction + prompt);
            Console.ReadKey();

            Console.WriteLine("The answer is " + answer);
        }
    }
}
