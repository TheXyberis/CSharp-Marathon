# 🪢 Hangman: Ultimate ASCII Edition

A fully-featured **Hangman** game built with **C#**. This version transitions from a basic logic test to a complete console application with dynamic graphics, optimized search algorithms, and polished user feedback.

## 🌟 Key Features

* **ASCII Art Visuals:** 8-stage evolving gallows that update in real-time as the player loses lives.
* **Smart Word Selection:** Randomly draws challenges from an internal `WordBank` for high replayability.
* **Modern Collections:** Uses `HashSet<char>` for high-performance tracking of guessed letters.
* **Robust UX:** Includes input validation (filtering non-letters), color-coded status messages, and timed feedback pauses.
* **Game Loop:** Seamless "Play Again" functionality with automated console clearing.

## 🛠 Technical Implementation

* **Data Optimization:** Implemented `HashSet` instead of `List` for guessed letters, reducing lookup time to $O(1)$.
* **Modular Architecture:** Logic is encapsulated into specialized methods:
    - `RunGameSession`: Manages the core game state.
    - `DrawHangman`: Handles the ASCII rendering engine.
    - `DisplayWordProgress`: Uses LINQ-style logic to mask/unmask characters.
* **Color Management:** Centralized `PrintColoredMessage` utility for consistent UI/UX styling.
* **State Management:** Uses `readonly` fields for the Random generator and Word Bank to ensure thread safety and data integrity.



## 🕹 How to Play
1. **The Gallows:** You start with an empty gallows. Each wrong guess builds a part of the hangman.
2. **The Guess:** Type a letter and press Enter. Only alphabetical characters are accepted.
3. **Tracking:** Your guessed letters are displayed so you don't repeat mistakes.
4. **The Goal:** Reveal all letters of the hidden word before the 7th life is lost!

## 📸 Project Previews

### 🎮 Gameplay Demonstration
Experience the full classic Hangman feel with real-time ASCII updates and smooth console transitions.

<details>
  <summary><b>🎬 Click to watch Gameplay Video</b></summary>
  <br>
  
  https://github.com/user-attachments/assets/e8540bd5-2b62-4c45-88aa-23e3d4d39255

</details>

<details>
  <summary><b>🖼️ Click to view Static Screenshot</b></summary>
  <br>
  <img src="https://github.com/user-attachments/assets/762efb71-453d-41c6-badb-117bec5e044f" alt="Hangman ASCII Art Screenshot" width="600">
</details>
