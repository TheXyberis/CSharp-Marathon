# 🎲 Simple Dice Game

A console-based dice game where a player competes against an "enemy" (AI) over a specified number of rounds.

## ✨ Features
- **Dynamic Input:** Player can set their own name and the number of rounds.
- **Input Validation:** Uses `int.TryParse` to prevent crashes when a user enters non-numeric text.
- **Roll Animation:** Implements a visual "shuffling" effect using `Thread.Sleep` and `Console.SetCursorPosition` to simulate real dice rolling.
- **Color-Coded UI:** Different colors for rounds, wins, losses, and draws to improve user experience.
- **Replayability:** A `do-while` loop allows the player to start a new game without restarting the application.

## 🛠️ Concepts Applied
- **C# Basics:** Variables, Data Types, and Operators.
- **Control Flow:** `do-while` and `for` loops, `if-else` statements.
- **Randomization:** Utilizing the `Random` class for fair dice rolls.
- **Console Manipulation:** Changing text colors and managing cursor positions.

## 🚀 How to Run
1. Open the solution in **Visual Studio**.
2. Build and Run the project (`F5`).
3. Follow the instructions in the console.

## 📸 Preview

*The game features a smooth dice rolling animation and a scoreboard updated after every round.*

<details>
  <summary><b>Click to view Gameplay GIF (Animation)</b></summary>
  <br>
  <img src="https://github.com/user-attachments/assets/4f879dca-b648-4bfd-939d-cbea9c3916d4" alt="Dice Game Gameplay" width="600">
</details>

<details>
  <summary><b>Click to view Screenshot</b></summary>
  <br>
  <img src="https://github.com/user-attachments/assets/b4dd92a8-67e5-415f-ab61-8e84d0790505" alt="Dice Game Screenshot" width="800">
</details>
