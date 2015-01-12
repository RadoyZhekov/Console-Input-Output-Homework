using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SumOfThreeNums
{
    class SumOfNums
    {
        // Write a program that reads 3 real numbers from the console and prints their sum
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter first number: ");
                double numberOne = double.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                double numberTwo = double.Parse(Console.ReadLine());
                Console.Write("Enter third number: ");
                double numberThree = double.Parse(Console.ReadLine());
                Console.WriteLine("The sum is: {0}", numberOne + numberTwo + numberThree);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong data format!");
            }
        }
    }
}
