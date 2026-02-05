using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_TurnBasedBattleSystem
{
    // Base class
    internal class Unit
    {
        protected int currentHp;
        protected int maxHp;
        protected int currentMp;
        protected int maxMp;
        protected int attackPower;
        protected int healPower;
        protected string unitName;
        protected int speed; // Used as dodge chance
        protected int luck; // Critical hit chance

        protected static Random rng = new Random();

        public int Hp { get { return currentHp; } }
        public int Mp { get { return currentMp; } }
        public string UnitName { get { return unitName; } }
        public bool IsDead { get { return currentHp <= 0; } }
        public int Speed { get { return speed; } }
        public Unit(int maxHp, int maxMp, int attackPower, int healPower, string unitName, int speed, int luck)
        {
            this.maxHp = maxHp;
            this.currentHp = maxHp;
            this.maxMp = maxMp;
            this.currentMp = maxMp;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.unitName = unitName;
            this.speed = speed;
            this.luck = luck;
        }

        // Basic attack (can be overridden)
        public virtual void Attack(Unit target)
        {
            // Target may dodge based on its speed
            if (rng.Next(0, 100) < target.speed)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{target.unitName} dodged the attack from {unitName}!");
                Console.ResetColor();
                return;
            }

            double factor = rng.NextDouble();
            factor = factor / 2 + 0.75; // Adjust to range [0.75, 1.25)
            int damage = (int)(attackPower * factor);

            // Critical hit chance
            if (rng.Next(0, 100) < luck)
            {
                damage *= 2;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CRITICAL HIT!");
                Console.ResetColor();
            }

            target.TakeDamage(damage);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{unitName} attacks {target.unitName} and deals {damage} damage!");
        }

        // Special attack (can be overridden)
        public virtual void SuperAttack(Unit target)
        {
            const int superCost = 15;
            if (currentMp < superCost)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{unitName}: Not enough mana for Super Attack!");
                Console.ResetColor();
                return;
            }
            currentMp -= superCost;

            int damage = attackPower * 2;
            target.TakeDamage(damage);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{unitName} uses SUPER ATTACK and deals {damage} damage!");
            Console.ResetColor();
        }

        public virtual void Heal()
        {
            const int healCost = 10;
            if (currentMp < healCost)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{unitName}: Not enough mana to heal!");
                Console.ResetColor();
                return;
            }

            currentMp -= healCost;
            double factor = rng.NextDouble();
            factor = factor / 2 + 0.75; // Adjust to range [0.75, 1.25)
            int heal = (int)(healPower * factor);
            currentHp = currentHp + heal > maxHp ? maxHp : currentHp + heal;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{unitName} healed for {heal} HP. (HP: {currentHp}/{maxHp})");
            Console.ResetColor();
        }

        public void Rest()
        {
            int manaRegen = 20;
            currentMp = currentMp + manaRegen > maxMp ? maxMp : currentMp + manaRegen;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{unitName} rests and restores {manaRegen} mana. (MP: {currentMp}/{maxMp})");
            Console.ResetColor();
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage;
            if (currentHp < 0) currentHp = 0;
            if (IsDead)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{unitName} has been defeated!");
                Console.ResetColor();
            }
        }

        public void ShowStatus()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"--- {unitName}: {currentHp} HP, {currentMp} MP ---");
            Console.ResetColor();
        }
    }

    // Warrior: high HP, low magic, strong basic attacks
    internal class Warrior : Unit
    {
        public Warrior(string name) : base(maxHp: 140, maxMp: 20, attackPower: 22, healPower: 10, unitName: name, speed: 8, luck: 8)
        {
        }

        public override void Attack(Unit target)
        {
            // Warrior deals more stable physical damage
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{unitName} swings a heavy weapon!");
            Console.ResetColor();
            base.Attack(target);
        }

        public override void SuperAttack(Unit target)
        {
            const int cost = 12;
            if (currentMp < cost)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{unitName}: Not enough mana for Power Strike!");
                Console.ResetColor();
                return;
            }
            currentMp -= cost;

            int damage = attackPower * 3 / 2; //1.5x
            target.TakeDamage(damage);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{unitName} uses POWER STRIKE and deals {damage} damage!");
            Console.ResetColor();
        }
    }

    // Mage: low HP, high magic damage
    internal class Mage : Unit
    {
        public Mage(string name) : base(maxHp: 80, maxMp: 60, attackPower: 12, healPower: 20, unitName: name, speed: 10, luck: 2)
        {
        }

        public override void Attack(Unit target)
        {
            // Mage has weaker physical attacks
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{unitName} strikes with a magical bolt.");
            Console.ResetColor();
            base.Attack(target);
        }

        public override void SuperAttack(Unit target)
        {
            const int cost = 20;
            if (currentMp < cost)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{unitName}: Not enough mana for Fireball!");
                Console.ResetColor();
                return;
            }
            currentMp -= cost;

            // High magic damage with bigger randomness
            double factor = 2.0 + (rng.NextDouble() - 0.5); // ~[1.5, 2.5]
            int damage = (int)(attackPower * factor);
            target.TakeDamage(damage);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{unitName} casts FIREBALL and deals {damage} magic damage!");
            Console.ResetColor();
        }
    }

    // Rogue: high dodge chance and crit chance
    internal class Rogue : Unit
    {
        public Rogue(string name) : base(maxHp: 100, maxMp: 30, attackPower: 16, healPower: 12, unitName: name, speed: 25, luck: 20)
        {
        }

        public override void Attack(Unit target)
        {
            // Chance to strike twice
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{unitName} attempts a quick backstab!");
            Console.ResetColor();

            if (rng.Next(0, 100) < 25) // 25% chance for double hit
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Rogue strikes twice!");
                Console.ResetColor();
                base.Attack(target);
                base.Attack(target);
                return;
            }

            base.Attack(target);
        }

        public override void SuperAttack(Unit target)
        {
            const int cost = 15;
            if (currentMp < cost)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{unitName}: Not enough mana for Backstab!");
                Console.ResetColor();
                return;
            }

            currentMp -= cost;

            // Guaranteed critical-like hit
            int damage = attackPower * 3;
            target.TakeDamage(damage);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{unitName} performs BACKSTAB dealing {damage} massive damage!");
            Console.ResetColor();
        }
    }

}
