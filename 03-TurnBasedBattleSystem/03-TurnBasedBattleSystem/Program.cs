using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_TurnBasedBattleSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.WriteLine("Choose your class: [1] Warrior [2] Mage [3] Rogue");
            string choice = Console.ReadLine();

            Unit player;
            switch (choice)
            {
                case "1": player = new Warrior("Player (Warrior)"); break;
                case "2": player = new Mage("Player (Mage)"); break;
                case "3": player = new Rogue("Player (Rogue)"); break;
                default: player = new Warrior("Player (Warrior)"); break;
            }

            // Create random enemy class
            int r = rng.Next(1, 4);
            Unit enemy;
            if (r == 1) enemy = new Warrior("Enemy (Warrior)");
            else if (r == 2) enemy = new Mage("Enemy (Mage)");
            else enemy = new Rogue("Enemy (Rogue)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Enemy chosen: {enemy.UnitName}\n");
            Console.ResetColor();

            // Battle loop
            while (!player.IsDead && !enemy.IsDead)
            {
                Console.WriteLine();
                player.ShowStatus();
                enemy.ShowStatus();
                Console.WriteLine();

                Console.WriteLine("Player turn! [a] Attack | [s] Super Attack | [h] Heal | [r] Rest");
                string act = Console.ReadLine().ToLower();

                if (act == "a") player.Attack(enemy);
                else if (act == "s") player.SuperAttack(enemy);
                else if (act == "h") player.Heal();
                else if (act == "r") player.Rest();
                else Console.WriteLine("Invalid action. Turn skipped.");

                if (enemy.IsDead || player.IsDead) break;

                // Enemy AI: heal if low HP, use super if possible, otherwise attack or rest
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEnemy turn!");
                Console.ResetColor();
                if (enemy.Hp <= (enemy is Warrior ? 50 : enemy.Hp / 4) && enemy.Mp >= 10)
                {
                    enemy.Heal();
                }
                else if (enemy.Mp >= 15)
                {
                    enemy.SuperAttack(player);
                }
                else if (enemy.Mp < 5)
                {
                    enemy.Rest();
                }
                else
                {
                    enemy.Attack(player);
                }
            }

            Console.WriteLine("\nBattle ended!");
            if (player.IsDead)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You lost.");
                Console.ResetColor();
            }
            else if (enemy.IsDead)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You won!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Draw.");
            }

            Console.ReadKey();
        }
    }
}
