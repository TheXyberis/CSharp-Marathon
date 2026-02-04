# 02 - Quiz Game (File-Based) 🧠

A console-based Quiz application built with C# that dynamically loads questions and answers from an external text file. This project demonstrates skills in file I/O operations, data parsing, and list management.

## 🚀 Features

- **External Data Loading**: Questions are not hardcoded but read from a `questions.txt` file.
- **Dynamic Logic**: Uses mathematical algorithms (`i % 4`) to distinguish between questions and answer choices.
- **Visual Feedback**: Uses color-coded console output (Green for correct, Red for incorrect, Magenta for headers).
- **Score Tracking**: Calculates and displays the final score at the end of the session.

## 🛠 Technical Skills Applied

- **File Systems**: Utilizing `System.IO` for reading external assets.
- **Collections**: Managing data flow using `List<string>`.
- **String Manipulation**: Using `.StartsWith()` and `.Replace()` for custom data formatting (e.g., identifying correct answers with the `>` symbol).
- **Loops & Conditionals**: Implementing game state logic with `while` and `for` loops.

## 📋 File Structure (questions.txt)

The game expects a specific format in the text file:
1. Question Text
2. Choice 1
3. Choice 2 (Use `>` prefix for the correct answer)
4. Choice 3

## 📸 Project Previews

### 🎮 Gameplay (Console Output)
Detailed look at how the game handles user input and provides color-coded feedback.

<details>
  <summary><b>Click to view Console Gameplay</b></summary>
  <br>
  <img src="https://github.com/user-attachments/assets/b4ccca34-a4a8-4061-8885-6293f915c196" alt="Quiz Game Console Screenshot" width="800">
</details>

### 📄 Data Structure (questions.txt)
This is how the questions and answers should be formatted in the external file for the game to parse them correctly.

<details>
  <summary><b>Click to view Text File Structure</b></summary>
  <br>
  <img src="https://github.com/user-attachments/assets/4c113c2a-9a72-4b5a-bd3f-1b4d57f1cf7c" alt="Questions File Screenshot" width="800">
</details>

