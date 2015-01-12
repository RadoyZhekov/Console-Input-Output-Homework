using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.PrintCompanyInfo
{
    class PrintInfo
    {
        // A company has name, address, phone number, fax number, web site and manager. 
        // The manager has first name, last name, age and a phone number.
        // Write a program that reads the information about a company and its manager and prints it back on the console.
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Enter company's info below: ");
                Console.Write("Enter the name: ");
                string companyName = Console.ReadLine();
                Console.Write("Enter the address: ");
                string address = Console.ReadLine();
                Console.Write("Enter the phone number: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Enter the fax number: ");
                string faxNumber = Console.ReadLine();
                Console.Write("Enter the web site: ");
                string webSite = Console.ReadLine();

                Console.WriteLine("Enter manager's info below:");
                Console.Write("Enter his first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter his last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter his age: ");
                string age = Console.ReadLine();
                Console.Write("Enter his phone number: ");
                string managerPhone = Console.ReadLine();

                Console.WriteLine("The data you just typed in:");
                Console.WriteLine("{0}\nAddress: {1}\nTel.: {2}\nFax: {3}\nWeb site: {4}",
                    companyName, address, phoneNumber, faxNumber, webSite);
                Console.WriteLine("Manager: {0} {1} (age: {2}, tel.: {3})",
                    firstName, lastName, age, managerPhone);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong data format");
            }
        }
    }
}
