# User Documentation for Text-Based RPG Game

---

This user documentation provides detailed instructions on how to install, use, and troubleshoot the text-based RPG game. The game is developed using C# and follows the Entity Component System (ECS) architecture. This guide aims to help users understand, play, and troubleshoot the game effectively.

---

## Table of Contents
1. [Installation Guide](#installation-guide)
2. [User Manual](#user-manual)
3. [FAQs and Troubleshooting](#faqs-and-troubleshooting)
4. [Contact Information](#contact-information)

---

## Installation Guide

### System Requirements:
- .NET Core SDK installed on your system.
- A code editor or IDE such as Visual Studio or Visual Studio Code.

### Steps to Install and Run the Game:
1. **Clone the Repository:**
   Download the game files from the provided repository link or obtain them from the course materials.

2. **Build the Project:**
   Open a terminal or command prompt, navigate to the directory containing the game files, and execute the following command:
   ```bash
   dotnet build

## User Manual

### Starting the Game:
- Run the game using the steps mentioned in the Installation Guide.

### Game Controls:
- **Input Commands:** The game will prompt for text input during gameplay. Follow the instructions on the screen and type your responses accordingly.

### Gameplay Overview:
1. **Character Setup:**
   - Set your character's name when prompted.
   - Your character will be initialized with default health and sword damage.

2. **Encountering Enemies:**
   - You will encounter enemies randomly during the game.
   - You will have the option to attack or avoid combat.

3. **Combat:**
   - If you choose to attack, the game will handle the combat mechanics.
   - You and the enemy will take turns attacking each other until one is defeated.

4. **Health Management:**
   - Monitor your health during combat. Use health potions to regain health if necessary.

5. **Objective:**
   - Defeat enemies and survive as long as possible.

### Game End:
- The game will end if your health reaches zero or if you choose to quit during a prompt.

---

### FAQs and Troubleshooting

**Q: The game won't start. What should I do?**
   - Ensure that .NET Core SDK is installed correctly.
   - Verify that all game files are in the same directory.
   - Run the build and run commands in the terminal.

**Q: How can I heal my character?**
   - During gameplay, if your character has health potions, they will automatically use them to regain health when prompted.

**Q: The game crashes unexpectedly. What should I do?**
   - Check for any error messages in the terminal.
   - Ensure all components are correctly added to entities in the game files.
   - Restart the game and try again.

---

### Contact Information

For additional assistance, queries, or feedback, please reach out via GitHub. Visit my GitHub profile at [GitHub Profile](https://github.com/YourProfile) to contact me or report issues. We encourage users to open an issue for technical problems or feature suggestions related to the game.