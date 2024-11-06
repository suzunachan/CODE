using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HIPO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SystemMenu();
        }
        static void SystemMenu()
        {
            int choice;

            Console.WriteLine("[1] Age Category");
            Console.WriteLine("[2] Odd or Even");
            Console.WriteLine("[3] Odd and Even");
            Console.WriteLine("[4] Sum of Even 1 - 50");
            Console.WriteLine("[5] FizzBuzz!");
            Console.WriteLine("[6] Multiplication Table");
            Console.WriteLine("[7] Discount Table");
            Console.WriteLine("[8] Multiplication Table Generator");
            Console.WriteLine("[9] Converter");
            Console.WriteLine("[10] Minimum Maximum");
            Console.WriteLine("[11] Positive, Negative, and Zero");
            Console.WriteLine("[12] EXIT");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AgeCategory();
                    break;
                case 2:
                    OddorEven();
                    break;
                case 3:
                    OddandEven();
                    break;
                case 4:
                    SumofEven();
                    break;
                case 5:
                    FizzBuzz();
                    break;
                case 6:
                    MultiplicationTable();
                    break;
                case 7:
                    DiscountTable();
                    break;
                case 8:
                    MultTable();
                    break;
                case 9:
                    Converter();
                    break;
                case 10:
                    MinMax();
                    break;
                case 11:
                    PosNegZero();
                    break;
                case 12:    
                    break;
            }
        }
        static void AgeCategory()
        {
            int age;

            Console.WriteLine("Your Age: ");
            age = Convert.ToInt32(Console.ReadLine());

            if (age < 13)
            {
                Console.WriteLine("Child");
            }
            else if (age > 12 && age < 20)
            {
                Console.WriteLine("Teenager");
            }
            else
            {
                Console.WriteLine("Adult");
            }
        }
        static void OddandEven()
        {
            int i;
            int num;

            Console.WriteLine("Input Number: ");
            num = Convert.ToInt32(Console.ReadLine());

            for (i = 1; i <= num; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
            for (i = 1; i <= num; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }

            }


        }
        static void OddorEven()
        {
            int num;

            Console.WriteLine("Input Number: ");
            num = Convert.ToInt32(Console.ReadLine());

            if (num % 2 == 0)
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }
        }
        static void SumofEven()
        {
            int i;
            int sum = 0;


            Console.WriteLine("The SUM of all EVEN number is 1 - 50 is ");
            for (i = 1; i <= 50; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
        static void FizzBuzz()
        {
            //write a C# program that prints members from 1 to 100. For multiplies of 3,
            //print "Fizz" instead of the number, and for multiples of 5, print "Buzz". For numbers
            //that are multiples of both 3 and 5 print "FizzBuzz"

            int i;

            for (i = 1; i <= 100; i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    Console.WriteLine("FizzBUzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void MultiplicationTable()
        {
            int x, cols, rows;

            while (true)
            {
                Console.WriteLine("Multiplication Table");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("How many do you want?");
                Console.WriteLine("-----------------------------------------");
                x = Convert.ToInt32(Console.ReadLine());

                rows = 1;

                while (rows <= x)
                {
                    cols = 1;

                    do
                    {
                        Console.Write("{0 , 6}", rows * cols);
                        cols++;
                    }

                    while (cols <= x);
                    Console.WriteLine();
                    rows++;
                }

                Console.WriteLine("Do you want to continue?  [Yes] [No] ");
                if (Console.ReadLine().ToString().ToLower().Contains("no"))
                {
                    break;
                }
                Console.Clear();
            }
        }
        static void DiscountTable()
        {
            int x;

            Console.WriteLine("Enter Amount: ");
            x = int.Parse(Console.ReadLine());

            decimal discount;
            decimal totalAmount;
            decimal discAmount;

            if (x >= 1000)
            {
                discount = 20M;
            }
            else if ((x < 1000) && (x >= 500))
            {
                discount = 15M;

            }
            else if ((x < 500) && (x >= 100))
            {
                discount = 10M;
            }
            else
            {
                discount = 0M;
            }

            discAmount = discount * x / 100;
            totalAmount = x - discAmount;

            Console.WriteLine("\nDiscount Table");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Original Amount: $" + x);
            Console.WriteLine($"Number of Discount: " + discount + "%");
            Console.WriteLine($"Amount of Discount: $" + discAmount);
            Console.WriteLine($"Total Amount: $" + totalAmount);
        }
        static void MultTable()
        {
            Console.WriteLine("Input Table Number: ");
            int v = int.Parse(Console.ReadLine());

            int i = 1;

            while (i <= v)
            {
                Console.WriteLine($"\nMultiplication Table no: {i}");


                int n = 1;
                while (n <= 10)
                {
                    int result = i * n;
                    Console.WriteLine($"{i} x {n} = {result}");
                    n++;
                }
                i++;
            }
        }
        static void Converter()
        {
            Console.WriteLine("Enter number of temperature: ");
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                Console.Write($"Enter temperature {i} in Celsius: ");
                int c = int.Parse(Console.ReadLine());

                double temp = (c * 9 / 5) + 32;
                Console.WriteLine($"Temperature {i} in Fahrenheit: {temp:F2}");
            }

        }
        static void MinMax()
        {
            int n;
            int min = int.MaxValue;
            int max = int.MinValue;

            Console.WriteLine("Enter a series of number (enter -1 to finish): ");

            while (true)
            {
                Console.Write("Enter a number: ");
                n = int.Parse(Console.ReadLine());

                if (n == - 1)
                {
                    break;
                }

                if (n < min)
                {
                    min = n;
                }
                if (n > max)
                {
                    max = n;
                }
            }
            Console.WriteLine($"The lowest number is {min}");
            Console.WriteLine($"The highest number is {max}");
        }
        static void PosNegZero()
        {
            while (true)
            {
                int i = 1;

                do
                {
                    Console.WriteLine("Input an Integer: ");
                    int n = int.Parse(Console.ReadLine());

                    if (n == -999)
                    {
                        return;
                    }

                    if (n < 0 && n > -999)
                    {
                        Console.WriteLine("Negative");
                    }
                    else if (n == 0)
                    {
                        Console.WriteLine("Zero");
                    }
                    else if (n > 0)
                    {
                        Console.WriteLine("Positive");
                    }
                }
                while (true);
            }
        }
    }
}
