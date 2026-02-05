# ⚔️ Turn-Based Battle System

A sophisticated console-based RPG battle engine built with **C#** and **Object-Oriented Programming (OOP)** principles. This project demonstrates advanced logic, class inheritance, and resource management.

## 🌟 Key Features

* **Class Hierarchy:** Choose between distinct classes: **Warrior**, **Mage**, and **Rogue**.
* **Combat Mechanics:** Includes randomized damage ranges ($75\% - 125\%$), critical hits, and dodge chances based on unit speed.
* **Resource Management:** Units use **Mana (MP)** for special abilities and healing, requiring strategic use of the "Rest" action.
* **Smart AI:** The computer opponent makes tactical decisions (healing when low on HP, using super attacks, or resting to regain mana).
* **Polymorphism:** Each class has its own unique `SuperAttack` implementation using `virtual` and `override` methods.

## 🛠 Technical Implementation

* **Inheritance:** Used a base `Unit` class with `protected` fields to share logic across subclasses.
* **Encapsulation:** Properties with `get` accessors (like `IsDead`) provide clean logic checks.
* **Static Random:** Implemented a `static Random` instance to ensure high-quality, non-repeating random numbers across all game objects.
* **Color-Coded Feedback:** Enhanced user experience with colored console outputs for different battle events.

## 🕹 How to Play
1. **Choose your class** (Warrior, Mage, or Rogue).
2. **Select your action** during your turn:
   - `[a]` **Attack**: Basic physical strike (No cost).
   - `[s]` **Super Attack**: Powerful class-specific move (Costs Mana).
   - `[h]` **Heal**: Restore HP using magic (Costs Mana).
   - `[r]` **Rest**: Skip a turn to restore 20 Mana.
3. Defeat the enemy before your HP reaches zero!

## 📸 Project Previews

### 🎮 Gameplay (Console Output)
Detailed look at the turn-based logic, class-specific moves, and color-coded combat logs.

<details>
  <summary><b>Click to view Battle Gameplay</b></summary>
  <br>
  <img src="https://github.com/user-attachments/assets/1948bcd6-f264-41a8-b407-6c70e8eaba44" alt="Battle System Console Screenshot" width="800">
</details>
