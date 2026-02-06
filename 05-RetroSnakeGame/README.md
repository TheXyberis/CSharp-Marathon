# 🐍 Retro Snake Game

A classic arcade-style **Snake Game** reimagined for the console, built with **C#** and structured with clean **Object-Oriented** logic. This project demonstrates real-time input handling, grid-based rendering, and dynamic data structures.

## 🌟 Key Features

* **Fluid Movement:** Implementation of a non-blocking input system using `Console.KeyAvailable`, allowing for smooth, real-time control.
* **Dynamic Tail Logic:** The snake grows longer with every apple consumed, managed by a `List<Coord>` history buffer.
* **Grid-Based Physics:** Custom collision detection for walls, self-intersection, and apple spawning logic.
* **Retro Aesthetics:** Styled with ASCII characters (`■`, `#`) and colored console output for a nostalgic gaming experience.
* **Live Scoring:** Real-time score tracking displayed at the top of the game screen.

## 🛠 Technical Implementation

* **Coord Class:** A dedicated class for coordinate management with overridden `Equals` method to simplify collision checks.
* **Direction Enum:** Used a strongly-typed `enum` to manage movement states, making the code readable and maintainable.
* **Frame Delay Logic:** Implemented a custom game loop with `DateTime` delta tracking to ensure consistent game speed.
* **Encapsulation:** Properties and private fields in the `Coord` class protect the integrity of positional data.

## 🕹 How to Play
1.  **Use Arrow Keys** (`↑`, `↓`, `←`, `→`) to control the snake's direction.
2.  **Eat the Apples** (`a`) to grow your tail and increase your score.
3.  **Avoid Walls** (`#`) and **don't bite your own tail**!
4.  If you crash, the game resets your score and position so you can try again immediately.

## 📸 Project Previews

### 🎮 Gameplay (Console Output)

<details>
  <summary><b>Click to view Snake Gameplay</b></summary>
  <br>
  <img src="https://github.com/user-attachments/assets/7f243445-64ac-47d9-ae45-3498f5a7d75f" alt="Snake Game Gameplay Screenshot" width="600">
</details>
