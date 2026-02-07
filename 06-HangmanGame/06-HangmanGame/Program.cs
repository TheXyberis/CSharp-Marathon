using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_HangmanGame
{
    internal class Program
    {
        private static readonly string[] WordBank = { "programming", "csharp", "developer", "software", "keyboard" };
        private static readonly Random RandomGenerator = new Random();
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                RunGameSession();

                Console.WriteLine("\nPlay again? (y/n): ");
                string answer = Console.ReadLine().ToLower();
                playAgain = answer == "y";
                Console.Clear();
            }
        }
        static void RunGameSession()
        {
            string targetWord = WordBank[RandomGenerator.Next(WordBank.Length)].ToLower();

            int maxLives = 7;
            int currentLives = maxLives;
            HashSet<char> guessedLetters = new HashSet<char>();

            while (currentLives > 0)
            {
                Console.Clear();
                DrawHangman(currentLives);
                DisplayWordProgress(targetWord, guessedLetters);

                Console.WriteLine($"\n\nLives: {currentLives}/{maxLives}");
                Console.WriteLine("Guessed so far " + string.Join(", ", guessedLetters));
                Console.WriteLine("Guess a letter: ");

                string input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(input) || !char.IsLetter(input[0]))
                {
                    PrintColoredMessage("Please enter a valid single letter!", ConsoleColor.DarkYellow);
                    continue;
                }

                char guess = input[0];

                if (guessedLetters.Contains(guess))
                {
                    PrintColoredMessage($"You already tried '{guess}'", ConsoleColor.DarkYellow);
                    continue;
                }

                guessedLetters.Add(guess);

                if (targetWord.Contains(guess))
                {
                    PrintColoredMessage("Correct!", ConsoleColor.Green);
                }
                else
                {
                    PrintColoredMessage("Incorrect!", ConsoleColor.Red);
                    currentLives--;
                }

                if (targetWord.All(c => guessedLetters.Contains(c)))
                {
                    EndGame(true, targetWord, guessedLetters);
                    return;
                }
            }
            EndGame(false, targetWord, guessedLetters);
        }
        static void DisplayWordProgress(string word, HashSet<char> guessed)
        {
            foreach (char c in word)
            {
                if (guessed.Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(c + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("_ ");
                }
            }
        }
        static void DrawHangman(int lives)
        {
            string[] stages =
            {
                // 0 lives: Full body
                "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n=========", 
                // 1 life: Missing one leg
                "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
                // 2 lives: Missing both legs
                "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
                // 3 lives: Missing one arm
                "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
                // 4 lives: Just head and torso
                "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
                // 5 lives: Just head
                "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
                // 6 lives: Just rope
                "  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========",
                // 7 lives: Empty gallows
                "  +---+\n  |    \n      |\n      |\n      |\n      |\n========="
            };

            if (lives < stages.Length)
            {
                Console.WriteLine(stages[lives]);
            }
        }
        static void PrintColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
            System.Threading.Thread.Sleep(800); //brief pause so the player can see the feedback
        }
        static void EndGame(bool won, string word, HashSet<char> guessedLetters = null)
        {
            Console.Clear();

            DrawHangman(won ? 7 : 0);

            if (won && guessedLetters != null)
            {
                DisplayWordProgress(word, guessedLetters);
                Console.WriteLine("\n");
            }

            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! YOU WIN!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER");
                Console.WriteLine($"The word was: {word.ToUpper()}");
            }
            Console.ResetColor();
        }
    }
}
