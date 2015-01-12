using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.NumbersFrom1ToN
{
    class NumbersFrom1ToN
    {
        // Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.
        static void Main(string[] args)
        {
            Console.Write("Type in number: ");
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                for (int i = 1; i <= number; i++)
                {
                    Console.WriteLine("{0, 18}", i);
                }
            }
            else
            {
                Console.WriteLine("Wrong data format!");
            }
        }
    }
}
