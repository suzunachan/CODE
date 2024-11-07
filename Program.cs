using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Osaki__Final_Project
{
    internal class Program
    {
        static List<string> completedQuizzes = new List<string>();
        static Dictionary<string, int> quizScores = new Dictionary<string, int>(); 
        const string filePath = "users.txt";
        const string scoresFilePath = "scores.txt"; 

        static string currentUser = ""; 

        static void Main(string[] args)
        {
            LoadScores(); 

            while (true)
            {
                if (Login())
                {
                    Subjects(); 
                }
            }
        }

        static bool Login()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nWelcome! Please select an option:");
                Console.WriteLine("[1] Log In");
                Console.WriteLine("[2] Register");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (PerformLogin())
                    {
                        LoadScores();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect username or password. Redirecting to login...");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else if (choice == "2")
                {
                    Register();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Redirecting to login...");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        static bool PerformLogin()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine().Trim();

            Console.Write("Enter Password: ");
            string password = ReadPassword().Trim();

            bool isValidUser = ValidateUser(username, password);
            if (isValidUser)
            {
                Console.WriteLine("Login successful!");
                Thread.Sleep(1000);
                currentUser = username;
            }
            return isValidUser;
        }

        static void Register()
        {
            Console.Write("Create a Username: ");
            string username = Console.ReadLine().Trim();

            Console.Write("Create a Password: ");
            string password = ReadPassword().Trim();

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
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("\n        [Choose Subject]        ");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("[1] Computer Programming 1.     ");
                Console.WriteLine("[2] Introduction to Computing.  ");
                Console.WriteLine("[3] View Scores of a User.      ");
                Console.WriteLine("[4] Log Out.                    ");
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
                            Console.WriteLine("\nYou have already completed this quiz.");
                            Thread.Sleep(1200);
                            Console.Clear();
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
                            Console.WriteLine("\nYou have already completed this quiz.");
                            Thread.Sleep(1200);
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            IntroToComp();
                        }
                        break;

                    case 3:
                        ViewUserScores();
                        break;

                    case 4:
                        Console.WriteLine("Logging out...");
                        currentUser = "";
                        return;
                }
            }
        }

        static void ViewUserScores()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~ All Users' Scores ~~~~~~~");

            bool foundScores = false;

            if (File.Exists(scoresFilePath))
            {
                string[] lines = File.ReadAllLines(scoresFilePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        string username = parts[0].Trim();
                        string quizName = parts[1].Trim();
                        string score = parts[2].Trim();

                        Console.WriteLine($"User: {username} | Quiz: {quizName} | Score: {score} points");
                        foundScores = true;
                    }
                }

                if (!foundScores)
                {
                    Console.WriteLine("No scores found for any user.");
                }
            }
            else
            {
                Console.WriteLine("Scores file not found.");
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }

        static void SaveScores()
        {
            bool scoreUpdated = false;
            List<string> lines = new List<string>();

            if (File.Exists(scoresFilePath))
            {
                lines = new List<string>(File.ReadAllLines(scoresFilePath));
            }

            foreach (var quiz in quizScores)
            {
                bool found = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts[0] == currentUser && parts[1] == quiz.Key)
                    {
                        lines[i] = $"{currentUser},{quiz.Key},{quiz.Value}";
                        found = true;
                        scoreUpdated = true;
                        break;
                    }
                }

                if (!found)
                {
                    lines.Add($"{currentUser},{quiz.Key},{quiz.Value}");
                    scoreUpdated = true;
                }
            }

            if (scoreUpdated)
            {
                File.WriteAllLines(scoresFilePath, lines);
            }
        }


        static void LoadScores()
        {
            if (File.Exists(scoresFilePath))
            {
                string[] lines = File.ReadAllLines(scoresFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3 && int.TryParse(parts[2], out int score) && parts[0] == currentUser)
                    {
                        quizScores[parts[1]] = score;
                        completedQuizzes.Add(parts[1]);
                    }
                }
            }
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

            quizScores["Computer Programming 1"] = score;
            completedQuizzes.Add("Computer Programming 1");
            SaveScores();

            Console.WriteLine($"Your score for Computer Programming 1: {score}");
            Console.Write("Press any key to return to Main Menu.");
            Console.ReadKey();
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
                "5. It is the protection of the underlying networking infastracture from unauthorized access, misuse, or theft.",
                "6. It is Network Security device that monitors incoming and outgoing network traffic.",
                "7. This means that users can deny having performed an action e.g., sending or receiving data",
                "8. It is an accidental consequences that complicates things.",
                "9. It is the most important software that runs on a computer",
                "10. What does SDLC stands for?"
            };
            string[] options =
            {
                "[A] Information System [B] Computer System [C] None",
                "[A] Software [B] Hardware [C] Both A and C",
                "[A] Software [B] Hardware [C] Database",
                "[A] Management Industry [B] Management Information System [C] Managing Information Security",
                "[A] Network Security [B] Operating System [C]Kerberos",
                "[A] VPN [B] Access Control [C] Firewalls",
                "[A] Spoofing Identity [B] Repudiation [C] Denial of Service",
                "[A] Rammification [B] Wireless Security [C] Behavioral Analytics",
                "[A] Operating System [B] Computer [C] Network Security",
                "[A] System Development Life Cycle [B] System Developmental Life Cycle [C] Security Device Life Cycle"
            };
            string[] correctAns =
            {
                "B", "A", "C", "B", "A", "C", "B", "A", "C", "A"
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

            quizScores["Introduction to Computing"] = score;
            completedQuizzes.Add("Introduction to Computing");
            SaveScores();

            Console.WriteLine($"Your score for Introduction to Computing: {score}");
            Console.Write("Press any key to return to Main Menu.");
            Console.ReadKey();
        }
    }
}


