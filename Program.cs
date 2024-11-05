using System;
using System.Collections.Generic;
using System.IO;

namespace Osaki__Final_Project
{
    internal class Program
    {
        static List<string> completedQuizzes = new List<string>();
        static Dictionary<string, int> quizScores = new Dictionary<string, int>(); // Store quiz names and scores
        const string filePath = "users.txt";

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
            Console.WriteLine("\nWelcome! Please select an option:");
            Console.WriteLine("[1] Log In");
            Console.WriteLine("[2] Register");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                return PerformLogin();
            }
            else if (choice == "2")
            {
                Register();
                return Login(); // Prompt login again after registration
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting program...");
                return false;
            }
        }

        static bool PerformLogin()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine().Trim();

            Console.Write("Enter Password: ");
            string password = ReadPassword().Trim();

            // Check if username and password are correct
            bool isValidUser = ValidateUser(username, password);
            Console.WriteLine(isValidUser ? "Login successful!" : "Incorrect username or password.");
            return isValidUser;
        }

        static void Register()
        {
            Console.Write("Create a Username: ");
            string username = Console.ReadLine().Trim();

            Console.Write("Create a Password: ");
            string password = ReadPassword().Trim();

            // Check if username already exists
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts[0] == username)
                    {
                        Console.WriteLine("Username already exists. Please try again.");
                        return;
                    }
                }
            }

            // Save the new user to the file
            string userEntry = $"{username},{password}";
            File.AppendAllText(filePath, userEntry + Environment.NewLine);
            Console.WriteLine("\nRegistration successful! You can now log in.");
        }

        static bool ValidateUser(string username, string password)
        {
            if (!File.Exists(filePath)) return false;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0].Trim() == username && parts[1].Trim() == password)
                {
                    return true;
                }
            }
            return false;
        }

        static string ReadPassword()
        {
            string password = string.Empty;
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        static void Subjects()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("\n        [Choose Subject]        ");
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
                "3. Plays a crucial role in simplifying complex processes and ensuring clear communication.",
                "4. Declared with the bool keyword and can only take the values true or false",
                "5. The ________ expression is evaluated once",
                "6. It is also possible to place a loop inside another loop",
                "7. It stores single characters, such as 'a' or 'B'. Char values are surrounded by single quotes",
                "8. It stores text, such as Hello World. String values are surrounded by double quotes",
                "9. It stores values with two states: true or false",
                "10. It is use to specify a new condition to test, if the first condition is false",
            };
            string[] options =
            {
                "[A] Logical Error [B] Syntax Error [C] Human Error",
                "[A] Pseudocode [B] Flowchart [C] Algorithm",
                "[A] Flowchart [B] Algorithm [C] Pseudocode",
                "[A] Boolean [B] Integer [C] Double",
                "[A] Break [B] Case [C] Switch",
                "[A] For Loop [B] Nested Loop [C] While Loop",
                "[A] Double [B] Int [C] Char",
                "[A] String [B] Bool [C] Int",
                "[A] Char [B] Bool [C] Double",
                "[A] Else [B] Else If [C] If",
            };
            string[] correctAns =
            {
                "B", "C", "A", "A", "C", "B", "C", "A", "B", "B"
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
                "3. A collection of relevant data",
                "4. What does MIS refers to?",
                "3. "
            };
            string[] options =
            {
                "[A] Information System [B] Computer System [C] None",
                "[A] Software [B] Hardware [C] Both A and C",
                "[A] Software [B] Hardware [C] Database",
                "[A] Management Industry [B] Management Information System [C] Managing Information Security",
                "[A] "
            };
            string[] correctAns =
            {
                "B", "A", "C", "B"
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
