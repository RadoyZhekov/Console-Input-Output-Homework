using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.NumberComparer
{
    class NumberComparer
    {
        // Write a program that gets two numbers from the console and prints the greater of them.
        // Try to implement this without if statements.
        static void Main(string[] args)
        {
            try
            {
                Console.Write("First number: ");
                double numberOne = double.Parse(Console.ReadLine());
                Console.Write("Second number: ");
                double numberTwo = double.Parse(Console.ReadLine());
                double biggerNum = numberOne > numberTwo ? numberOne : numberTwo;
                Console.WriteLine("The bigger of the two is: {0}", biggerNum);

            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong format data!");
            }
        }
    }
}
