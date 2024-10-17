using System;
using System.Collections.Generic;
using System.IO;

namespace Osaki__Final_Project
{
    internal class Program
    {
        static List<string> completedQuizzes = new List<string>();
        static Dictionary<string, int> quizScores = new Dictionary<string, int>(); // Store quiz names and scores

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
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("        [Choose Subject]        ");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("[1] Computer Programming 1.     ");
                Console.WriteLine("[2] Introduction to Computing.  ");
                Console.WriteLine("[3] View Scores.                ");
                Console.WriteLine("[4] Exit Program.               ");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                int choice;
                bool validChoice = int.TryParse(Console.ReadLine(), out choice);

                if (!validChoice || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number (1-4).");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if (completedQuizzes.Contains("Computer Programming 1"))
                        {
                            Console.WriteLine("You have already completed this quiz.");
                        }
                        else
                        {
                            Console.Clear();
                            ComProg();
                        }
                        break;
                    case 2:
                        if (completedQuizzes.Contains("Introduction to Computing"))
                        {
                            Console.WriteLine("You have already completed this quiz.");
                        }
                        else
                        {
                            Console.Clear();
                            IntroToComp();
                        }
                        break;
                    case 3:
                        ViewScores();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Program...");
                        return;
                }
            }
        }

        static void ViewScores()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~ Scores ~~~~~~~~~~~~~");

            if (quizScores.Count == 0)
            {
                Console.WriteLine("No quizzes have been completed yet.");
            }
            else
            {
                foreach (var quiz in quizScores)
                {
                    Console.WriteLine($"{quiz.Key}: {quiz.Value} points");
                }
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }

        static void ComProg()
        {
            int score = 0;

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
            completedQuizzes.Add("Computer Programming 1");
            quizScores["Computer Programming 1"] = score; // Store the score
        }

        static void IntroToComp()
        {
            int score = 0;

            string[] questions =
            {
                "1. A programmable electronic device that can accept input; store data; and retrieve, process and output information.",
                "2. Provides a list of commands and functions that guide hardware through various processes.",
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
            completedQuizzes.Add("Introduction to Computing");
            quizScores["Introduction to Computing"] = score; // Store the score
        }
    }
}
