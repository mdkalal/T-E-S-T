using System;
using System.Diagnostics.CodeAnalysis;

namespace SampleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(AddNumbers(2, 2));

            Console.WriteLine("Test for Add Numbers");

            int addTest;
            addTest = AddNumbers(2, 3);
            if (addTest == 5)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("false");
            }

        }

        static int AddNumbers(int First, int Second)
        {
            int sum;
            sum = First + Second;
            return sum;
        }

    }
}
