using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.DivideableNumbersInInterval
{
    class DivideableNumbers
    {
        // Write a program that reads two positive integer numbers and prints 
        // how many numbers p exist between them such that the reminder of the division by 5 is 0.
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Type in starting number: ");
                uint start = uint.Parse(Console.ReadLine());
                Console.Write("Type in ending number: ");
                uint end = uint.Parse(Console.ReadLine());
                int count = 0;
                for (uint i = start; i <= end; i++)
                {
                    if (i % 5 == 0)
                    {
                        Console.Write("{0}", i);
                        count++;
                    }
                    if (i % 5 == 0 && i < end)
                    {
                        Console.Write(", ");
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("-");
                }
                Console.WriteLine("\nTotal numbers count: {0}", count);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please type in ONLY positive integers!");
            }
        }
    }
}
