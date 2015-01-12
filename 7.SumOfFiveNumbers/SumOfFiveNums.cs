using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.SumOfFiveNumbers
{
    class SumOfFiveNums
    {
        // Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 5 numbers, given in a single line, separated by space:");
            string[] input = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += double.Parse(input[i]);
            }
            Console.WriteLine("Their sum is : {0}", sum);
        }
    }
}
