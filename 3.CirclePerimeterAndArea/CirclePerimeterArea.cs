using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CirclePerimeterAndArea
{
    class CirclePerimeterArea
    {
        // Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.
        static void Main(string[] args)
        {
            double radius;
            Console.Write("Enter the radius: ");
            if (double.TryParse(Console.ReadLine(), out radius))
            {
                double area = Math.PI * (radius * radius);
                double perimeter = 2 * Math.PI * radius;
                Console.WriteLine("The area is: {0:F}, and the perimeter is: {1:F}", area, perimeter);
            }
            else
            {
                Console.WriteLine("Wrond data format!");
            }
        }
    }
}
