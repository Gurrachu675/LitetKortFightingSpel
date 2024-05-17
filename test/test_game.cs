using System;

class Program
{
    static void Main(string[] args)
    {
        var playerEntity = new Entity(1);
        playerEntity.AddComponent(new HealthComponent { Health = 20 });
        playerEntity.AddComponent(new SwordComponent { damage = 5 });
        playerEntity.AddComponent(new NameComponent { name = "Player" });

        var monsterEntity = new Entity(2);
        monsterEntity.AddComponent(new HealthComponent { Health = 10 });
        monsterEntity.AddComponent(new SwordComponent { damage = 2 });

        var HealthSystem = new HealthSystem();
        var playSystem = new PlaySystem();

        // Test player taking damage
        HealthSystem.TakeDamage(playerEntity, monsterEntity);
        // Expected: Player health = 15 (20 - 5)
        Console.WriteLine("Player health after taking damage: " + playerEntity.GetComponent<HealthComponent>().Health);

        // Test player healing
        playerEntity.AddComponent(new HealthPotionComponent { regenAmount = 3 });
        HealthSystem.HealHealth(playerEntity);
        // Expected: Player health = 18 (15 + 3)
        Console.WriteLine("Player health after healing: " + playerEntity.GetComponent<HealthComponent>().Health);

        // Test player name setting
        var inputEntity = new Entity(3);
        inputEntity.AddComponent(new InputComponent { Input = "John" });
        playSystem.SetName(playerEntity, inputEntity);
        // Expected: Player name = "John"
        Console.WriteLine("Player name after setting: " + playerEntity.GetComponent<NameComponent>().name);

        // Test player setup
        playSystem.SetUp(playerEntity, 30, 8);
        // Expected: Player health = 30, Player damage = 8
        Console.WriteLine("Player health after setup: " + playerEntity.GetComponent<HealthComponent>().Health);
        Console.WriteLine("Player damage after setup: " + playerEntity.GetComponent<SwordComponent>().damage);

        // Test checking health
        // Expected: True (Player's health > 0)
        Console.WriteLine("Player health check result: " + HealthSystem.CheckHealth(playerEntity));

        // Additional scenario: Player encounters a monster
        // This scenario can't be tested through traditional unit tests, as it involves user input and interaction with the console.
        // You may manually test this scenario by running the program and simulating the user input.
    }
}