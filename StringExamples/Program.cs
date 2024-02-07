using System;


namespace StringExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string courseName = "Learn C# for Beginners Crash Course";

            int position = -1;

            do
            {
                position = courseName.IndexOf(" c", position + 1, StringComparison.OrdinalIgnoreCase);
                if (position != -1)
                {
                    courseName = ReplaceByIndex(courseName, position, " c".Length, " Java");
                    Console.WriteLine(courseName);
                }
            } while (position != -1);

            string fixedString = courseName.Replace(" Java", " C");
            Console.WriteLine(fixedString);
        }

        private static string ReplaceByIndex(string original, int start, int length, string replacement)
        {
            string newString = original.Remove(start, length);
            return newString.Insert(start, replacement);
        }
    }
}
