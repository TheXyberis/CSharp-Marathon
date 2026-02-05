using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_TicTacToe
{
    internal class Program
    {
        //current game state
        static string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static int[] winningLine = null;

        //history of finished games
        static List<string[]> historyGrids = new List<string[]>();
        static List<int[]> historyWinningLines = new List<int[]>();
        static List<string> historyResults = new List<string>();

        static void Main(string[] args)
        {
            bool playeAgain = true;

            while (playeAgain)
            {
                bool isPlayerOneTurn = true;
                int numTurns = 0;
                winningLine = null;

                //inner loop - single game
                while (CheckVictory() == null && numTurns != 9)
                {
                    Console.Clear();

                    //print finished games (history) so they stay visible
                    for (int h = 0; h < historyGrids.Count; h++)
                    {
                        PrintGrid(historyGrids[h], historyWinningLines[h]);
                        Console.WriteLine(historyResults[h]);
                        Console.WriteLine();
                    }
                    //print current ongoing game
                    PrintGrid(); //default uses current grid and winningLine

                    Console.ForegroundColor = isPlayerOneTurn ? ConsoleColor.Cyan : ConsoleColor.Magenta;
                    Console.WriteLine(isPlayerOneTurn ? "Player 1 (X)'s turn!" : "Player 2 (O)'s turn!");
                    Console.ResetColor();

                    string choice = Console.ReadLine();

                    if (grid.Contains(choice) && choice != "X" && choice != "O")
                    {
                        int gridIndex = Convert.ToInt32(choice) - 1;
                        grid[gridIndex] = isPlayerOneTurn ? "X" : "O";
                        numTurns++;

                        winningLine = CheckVictory();
                        if (winningLine != null) break;

                        isPlayerOneTurn = !isPlayerOneTurn;
                    }
                }

                Console.Clear();
                //game finished: print everything (histroy + current final board)
                for (int h = 0; h < historyGrids.Count; h++)
                {
                    PrintGrid(historyGrids[h], historyWinningLines[h]);
                    Console.WriteLine(historyResults[h]);
                    Console.WriteLine();
                }

                PrintGrid(); //current final grid

                //determine and show result
                if (winningLine != null)
                {
                    string winnerSymbol = grid[winningLine[0]]; // 'x' or 'o'
                    string resultText;

                    if (winnerSymbol == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        resultText = ("Player 1 (X) wins!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        resultText = ("Player 2 (O) wins!");
                    }
                    Console.WriteLine(resultText);
                    Console.ResetColor();

                    historyGrids.Add((string[])grid.Clone());
                    historyWinningLines.Add((int[])winningLine.Clone());
                    historyResults.Add(resultText);
                }
                else
                {
                    string tieText = "It's a tie!";
                    Console.WriteLine(tieText);

                    historyGrids.Add((string[])grid.Clone());
                    historyWinningLines.Add(null);
                    historyResults.Add(tieText);
                }

                //ask to play again
                Console.WriteLine();
                Console.Write("Do you want to play again? (y/n): ");
                string answer = Console.ReadLine();

                if (!string.IsNullOrEmpty(answer) && (answer.Equals("y", StringComparison.OrdinalIgnoreCase)))
                {
                    //reset current grid for the next game
                    grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                    winningLine = null;
                    //continue the outer loop - new game will be created
                }
                else
                {
                    playeAgain = false;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }

        static int[] CheckVictory()
        {
            int[][] lines = new int[][]
            {
                new int[] {0, 1, 2}, new int[] {3, 4, 5}, new int[] {6, 7, 8},
                new int[] {0, 3, 6}, new int[] {1, 4, 7}, new int[] {2, 5, 8},
                new int[] {0, 4, 8}, new int[] {6, 4, 2}
            };

            foreach (var line in lines)
            {
                if (grid[line[0]] == grid[line[1]] && grid[line[1]] == grid[line[2]])
                {
                    return line;
                }
            }
            return null;
        }

        static void PrintGrid(string[] gridToPrint = null, int[] winLine = null)
        {
            if (gridToPrint == null) gridToPrint = grid;
            if (winLine == null) winLine = winningLine;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int index = i * 3 + j;

                    if (winLine != null && winLine.Contains(index))
                        Console.BackgroundColor = ConsoleColor.DarkGreen;

                    if (grid[index] == "X") Console.ForegroundColor = ConsoleColor.Cyan;
                    else if (grid[index] == "O") Console.ForegroundColor = ConsoleColor.Magenta;
                    else Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write(" " + grid[index] + " ");
                    Console.ResetColor();

                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("-----------");
            }
        }
    }
}