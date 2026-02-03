using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_DiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string playerName = Console.ReadLine();

            bool playAgain = true;

            do
            {
                Console.WriteLine("Enter number of rounds: ");
                int rounds;
                while (!int.TryParse(Console.ReadLine(), out rounds))
                {
                    Console.WriteLine("Please enter a valid number!");
                }

                int playerPoints = 0;
                int enemyPoints = 0;

                Random random = new Random();

                for (int i = 0; i < rounds; i++)
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"--- ROUND {i + 1} OF {rounds} ---");
                    Console.ResetColor();

                    Console.WriteLine($"{playerName}, press any key to roll the dice...");
                    Console.ReadKey();

                    //Player dice animation
                    Console.Write($"{playerName} rolling: ");
                    int cursorLeftPlayer = Console.CursorLeft;
                    int cursorTopPlayer = Console.CursorTop;
                    for (int j = 0; j < 10; j++)
                    {
                        int temp = random.Next(1, 7);
                        Console.Write(temp);
                        Thread.Sleep(120);
                        Console.SetCursorPosition(cursorLeftPlayer, cursorTopPlayer);
                    }
                    int playerRoll = random.Next(1, 7);
                    Console.WriteLine(playerRoll);

                    Console.WriteLine("...");
                    Thread.Sleep(600);

                    //Enemy dice animation
                    Console.Write("Enemy rolling: ");
                    int cursorLeftEnemy = Console.CursorLeft;
                    int cursorTopEnemy = Console.CursorTop;
                    for (int j = 0; j < 10; j++)
                    {
                        int temp = random.Next(1, 7);
                        Console.Write(temp);
                        Thread.Sleep(120);
                        Console.SetCursorPosition(cursorLeftEnemy, cursorTopEnemy);
                    }
                    int enemyRoll = random.Next(1, 7);
                    Console.WriteLine(enemyRoll);

                    if (playerRoll > enemyRoll)
                    {
                        playerPoints++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{playerName} wins this round!");
                        Console.ResetColor();
                    }
                    else if (enemyRoll > playerRoll)
                    {
                        enemyPoints++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enemy wins this round!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Draw!");
                        Console.ResetColor();
                    }

                    Console.WriteLine($"Score - {playerName}: {playerPoints} | Enemy: {enemyPoints}");
                }

                if (playerPoints > enemyPoints)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{playerName}, you win!");
                    Console.ResetColor();
                }
                else if (enemyPoints > playerPoints)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou lose.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nIt's a draw!");
                    Console.ResetColor();
                }

                Console.WriteLine("Do you want to play again? (y/n): ");
                string response = Console.ReadLine().ToLower();

                if (response != "y" && response != "yes")
                {
                    playAgain = false;
                    Console.WriteLine("Thanks for playing! Goodbye!");
                    Thread.Sleep(1000);
                }

            } while (playAgain);

            Console.ReadKey();
        }
    }
}
