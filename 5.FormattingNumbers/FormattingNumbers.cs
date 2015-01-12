using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FormattingNumbers
{
    class FormattingNumbers
    {
        /*  Write a program that reads 3 numbers:
            integer a (0 <= a <= 500)
            floating-point b
            floating-point c
            The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
            The number a should be printed in hexadecimal, left aligned
            Then the number a should be printed in binary form, padded with zeroes
            The number b should be printed with 2 digits after the decimal point, right aligned
            The number c should be printed with 3 digits after the decimal point, left aligned. */ 
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter an int number between 0 and 500: ");
                int intNum = int.Parse(Console.ReadLine());
                if (intNum < 0 || intNum > 500)
                {
                    Console.WriteLine("The int must be < 500");
                }
                else
                {
                    Console.Write("Enter floating-point number: ");
                    float floatOne = float.Parse(Console.ReadLine());
                    Console.Write("Enter floating-point number: ");
                    float floatTwo = float.Parse(Console.ReadLine());

                    string numberToBinaryStr = Convert.ToString(intNum, 2);
                    Console.WriteLine("{0, -10:X}|{1, -10}|{2, 10:F2}|{3, -10:F3}|", intNum, numberToBinaryStr.PadLeft(10, '0'), floatOne, floatTwo);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong data format!");
            }
            
        }
    }
}
