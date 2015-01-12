using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.SumOfNumbers
{
    class SumOfNumbers
    {
        // Write a program that enters a number n and after that enters more n numbers 
        // and calculates and prints their sum. Note: You may need to use a for-loop.
        static void Main(string[] args)
        {
            Console.Write("Type in number's count: ");
            int number;
            double input;
            double sum = 0;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                while (number > 0)
                {
                    Console.Write("Type in number: ");
                    if (double.TryParse(Console.ReadLine(), out input))
                    {
                        sum += input;
                    }
                    number--;
                }
                Console.WriteLine("The sum is: {0}", sum);
            }
        }
    }
}
