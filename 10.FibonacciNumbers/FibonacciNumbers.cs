using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.FibonacciNumbers
{
    class FibonacciNumbers
    {
        // Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence 
        // (at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
        static void Main(string[] args)
        {
            Console.Write("Type in number of Fibonacci sequence members: ");
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                for (int i = 0; i < number; i++)
                {
                    Console.Write(FibonacciSequence(i));
                    if (i < number)
                    {
                        Console.Write(", ");
                    }
                }
            }
        }
        public static int FibonacciSequence(int n)
        {
            int a = 0;
            int b = 1;
            // Gets skipped the 1st time in, prints 0
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = b + temp;
            }
            return a;
        }
    }
}
