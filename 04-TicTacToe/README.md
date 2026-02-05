# ⭕ Tic-Tac-Toe: Advanced Console Edition

A robust and visually enhanced implementation of the classic **Tic-Tac-Toe** game, built with **C#**. This project focuses on state management, history tracking, and dynamic UI feedback.

## 🌟 Key Features

* **Dynamic Visual Feedback:** Uses `ConsoleColor` to highlight the winning line and distinguish players with **Cyan (X)** and **Magenta (O)**.
* **Persistent Session History:** Keeps a live feed of all previous matches, displaying their final boards and results above the current game.
* **Victory Detection Engine:** A sophisticated algorithm that scans a 2D array of winning patterns to determine the victor or a tie instantly.
* **Smart Memory Management:** Implements `.Clone()` for grid and victory-line objects to preserve accurate snapshots for the history log.
* **Smooth Replayability:** Seamlessly transitions between matches with a reset system that clears the board while maintaining the session's scoreboard.

## 🛠 Technical Implementation

* **Logic Separation:** Features dedicated methods for `CheckVictory` (calculation) and `PrintGrid` (rendering) to maintain clean code.
* **Optional Parameters:** The rendering engine uses optional arguments (`gridToPrint = null`) to allow the same function to draw both active and historical boards.
* **State Control:** Managed via a centralized `string[] grid` and boolean flags to handle turn-switching and game loops.
* **Input Validation:** Robust handling of user choices to prevent overwriting existing moves or entering invalid coordinates.

## 🕹 How to Play
1.  **Start a Game:** The current board displays numbers **1-9**.
2.  **Make a Move:** Type the number corresponding to the cell where you want to place your symbol.
    -   **Player 1** is marked as `X`.
    -   **Player 2** is marked as `O`.
3.  **Win Condition:** Connect three identical symbols horizontally, vertically, or diagonally.
4.  **Review History:** Check your performance by looking at the archived boards at the top of the screen.

## 📸 Project Previews

### 🎮 Gameplay (Console Output)
Detailed look at the board rendering, color-coded winning lines, and match history.

<details>
  <summary><b>Click to view Tic-Tac-Toe Gameplay</b></summary>
  <br>
  <img src="https://github.com/user-attachments/assets/eece9ead-5837-42a4-ab41-9172aa66a949" alt="Tic-Tac-Toe Gameplay Screenshot" width="600">
</details>
