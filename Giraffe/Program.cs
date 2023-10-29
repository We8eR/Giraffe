// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number:");
            string firstNumber = Console.ReadLine();
            Console.Write("Enter second number:");
            string secondNumber = Console.ReadLine();
            Console.Write("Choose operation: 1:+  2:-  3:* 4: :");
            string operation = Console.ReadLine();
            int x = Int32.Parse(firstNumber);
            int y = Int32.Parse(secondNumber);
            if (operation == "1")
            {   
                Console.WriteLine(x + y);
            }
            else if (operation == "2")
            {
                Console.WriteLine(x - y);
            }
            else if(operation == "3")
            {
                Console.WriteLine(x * y);
            }
            else if( operation == "4")
            {
                Console.WriteLine(x / y);
            }
            else
            {
                Console.WriteLine("ERROR");
            }    
                
            Console.ReadLine();
        }
    }

}
   