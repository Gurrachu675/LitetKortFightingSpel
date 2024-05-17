# Game System Readme

This repository contains a simple console-based game system implemented in C#. The system comprises several components and systems to simulate basic gameplay mechanics such as health management, combat, and user interaction.

## Components

### HealthComponent
- **Properties**:
  - `Health`: Represents the current health points of an entity.

### SwordComponent
- **Properties**:
  - `Damage`: Indicates the amount of damage inflicted by a sword wielded by an entity.

### NameComponent
- **Properties**:
  - `Name`: Stores the name of an entity.

### HealthPotionComponent
- **Properties**:
  - `RegenAmount`: Specifies the amount of health restored by a health potion.

### InputComponent
- **Properties**:
  - `Input`: Stores user input during gameplay.

## Systems

### HealthSystem
- **Methods**:
  - `TakeDamage(Entity entity, Entity monsterEntity)`: Reduces the health of an entity based on the damage inflicted by a monster entity.
  - `HealHealth(Entity entity)`: Restores the health of an entity using a health potion.
  - `CheckHealth(Entity entity)`: Checks if an entity's health has dropped to zero or below, indicating death.

### PlaySystem
- **Methods**:
  - `input(Entity entity)`: Captures user input during gameplay.
  - `SetName(Entity entity, Entity inputEntity)`: Sets the name of an entity based on user input.
  - `SetUp(Entity entity, int health, int swordDamage)`: Initializes the health and sword damage of an entity.

## Usage

1. Instantiate necessary systems: `HealthSystem` and `PlaySystem`.
2. Create player and monster entities using the `Entity` class.
3. Add required components to entities using the `AddComponent` method.
4. Initialize player entity's name and attributes using `SetNam`e and `SetUp` methods respectively.
5. Start the main game loop, where players encounter monsters and engage in combat.
6. During combat, players can choose to attack or defend. Damage is calculated based on sword damage and health points.
7. The game continues until the player decides to stop or the player's health drops to zero.

## Example

```csharp
class Game
{
    static void Main(string[] args)
    {
        var healthSystem = new HealthSystem();
        var playSystem = new PlaySystem();

        // Create player entity
        var playerEntity = new Entity(1);
        playerEntity.AddComponent(new HealthComponent { });
        playerEntity.AddComponent(new SwordComponent { });
        playerEntity.AddComponent(new NameComponent { });

        // Create input entity
        var inputEntity = new Entity(2);
        inputEntity.AddComponent(new InputComponent { });

        // Create monster entity
        var monsterEntity = new Entity(3);
        monsterEntity.AddComponent(new HealthComponent { });
        monsterEntity.AddComponent(new SwordComponent { });

        // Set player's name and attributes
        playSystem.SetName(playerEntity, inputEntity);
        playSystem.SetUp(playerEntity, 20, 5);

        // Main game loop
        bool continueGame = true;
        while (continueGame)
        {
            // Set up monster attributes
            playSystem.SetUp(monsterEntity, 10, 2);
            Console.WriteLine("You encounterd an enemy");

            bool isPlaying = true;
            while (isPlaying)
            {
                Console.WriteLine("Do you want to attack?");
                playSystem.input(inputEntity);
                if (inputComponent.Input == "yes")
                {
                    // Attack logic
                }
                else if (inputComponent.Input == "no")
                {
                    // End game logic
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }
        }
    }
}
```
## Features

- Basic health management system.
- Combat mechanics with damage calculation.
- User interaction through console input.
- Name customization for player entity.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- This project was inspired by text RPGs
