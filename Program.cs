using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Osaki__Final_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Login())
            {
                Subjects();
            }
            else
            {
                Console.WriteLine("Login failed. Exiting program...");
            }
        }

        static bool Login()
        {
            string correctUsername = "suzunavachary"; 
            string correctPassword = "123456"; 

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            return username == correctUsername && password == correctPassword;
        }

        static void Subjects()
        {
            int choice;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("        [Choose Subject]        ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("[1] Computer Programming 1.     ");
            Console.WriteLine("[2] Introduction to Computing.  ");
            Console.WriteLine("[3] Exit Program.               ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    ComProg();
                    break;
                case 2:
                    Console.Clear();
                    IntroToComp();
                    break;
                case 3:
                    Console.WriteLine("Exiting Program...");
                    break;
            }
        }



        static void ComProg()
        {
            int score = 0;

            while (true)
            {
                string[] questions =
                {
                    "1. An error in the syntax of a sequence of characters",
                    "2. A step-by-step procedure or formula for solving a problem.",
                    "3. Plays a crucial role in simplifying complex processes and ensuring clear communication."
                };
                string[] options =
                {
                    "[A] Logical Error [B] Syntax Error [C] Human Error",
                    "[A] Pseudocode [B] Flowchart [C] Algorithm",
                    "[A] Flowchart [B] Algorithm [C] Pseudocode"
                };
                string[] correctAns =
                {
                    "B", "C", "A"
                };

                score = 0; // Reset score for new quiz

                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine(questions[i]);
                    Console.WriteLine(options[i]);

                    Console.Write("Write Answer: ");
                    string userAns = Console.ReadLine().ToUpper();

                    if (userAns == correctAns[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Correct Answer!\n");
                        score++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Incorrect! The correct answer is {correctAns[i]}\n");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"Quiz in Computer Programming 1 has been completed! Your score is {score}/{questions.Length}\n");

                Console.WriteLine("Would you like to take another quiz? [Yes] [No]");
                string choice = Console.ReadLine().ToLower();

                if (choice.Equals("no"))
                {
                    break; 
                }
            }
            Console.Clear();
            Subjects();
        }

        static void IntroToComp()
        {
            int score = 0;

            while (true)
            {
                string[] questions =
                {
                    "1. A programmable electronic device that can accept input; store data; and retrieve, process and output information.",
                    "2. provides a list of commands and functions that guide hardware through various processes.",
                    "3. A collection of relevant data"
                };
                string[] options =
                {
                    "[A] Information System [B] Computer System [C] None",
                    "[A] Software [B] Hardware [C] Both A and C",
                    "[A] Software [B] Hardware [C] Database"
                };
                string[] correctAns =
                {
                    "B", "A", "C"
                };

                score = 0; 

                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine(questions[i]);
                    Console.WriteLine(options[i]);

                    Console.Write("Write Answer: ");
                    string userAns = Console.ReadLine().ToUpper();

                    if (userAns == correctAns[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Correct Answer!\n");
                        score++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Incorrect! The correct answer is {correctAns[i]}\n");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"Quiz in Introduction to Computing has been completed! Your score is {score}/{questions.Length}\n");

                Console.WriteLine("Would you like to take another quiz? [Yes] [No]");
                string choice = Console.ReadLine().ToLower();

                if (choice.Equals("no"))
                {
                    break; 
                }
            }
            Console.Clear();
            Subjects();
        }
    }
}
