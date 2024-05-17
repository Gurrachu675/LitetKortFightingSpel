using System;
using System.Collections.Generic;



    public class HealthComponent
    {
        public int Health { get; set; }
    }

    public class SwordComponent
    {
        public int damage { get; set; }
    }

    public class NameComponent 

    {
        public string name { get; set; }
    }

    public class HealthPotionComponent
    {
        public int regenAmount { get; set; } 
    }
    
    public class InputComponent 
    {
        public string Input { get; set; }
    }


public class Entity
{
    public int Id { get; }
    private Dictionary<Type, object> components = new Dictionary<Type, object>();
    public Entity(int id)
    {
        Id = id;
    }
    public void AddComponent<T>(T component)
    {
        components[typeof(T)] = component;
    }
    public T GetComponent<T>() where T : class
    {
        if (components.TryGetValue(typeof(T), out var component))
        {
            return component as T;
        }
        return null;
    }
}
public class HealthSystem 
{
    public void TakeDamage(Entity entity, Entity monsterEntity)
    {
        var healthComponent = entity.GetComponent<HealthComponent>();
        var swordComponent = monsterEntity.GetComponent<SwordComponent>();

        if (healthComponent != null)
        {
            healthComponent.Health -= swordComponent.damage;
        }
    }

    public void HealHealth(Entity entity)
    {
        var healthComponent = entity.GetComponent<HealthComponent>();
        var healthPotionComponent = entity.GetComponent<HealthPotionComponent>();
        if (healthComponent != null)
        {
            healthComponent.Health += healthPotionComponent.regenAmount;
        }
    }

    public bool CheckHealth(Entity entity)
    {
        var healthComponent = entity.GetComponent<HealthComponent>(); 
        if (healthComponent.Health <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}


public class PlaySystem
{
    public void input(Entity entity)
    {
        var inputComponent = entity.GetComponent<InputComponent>();

        if (inputComponent != null)
        {
            inputComponent.Input = Console.ReadLine();
        }


    }

    public void SetName(Entity entity, Entity inputEntity)
    {
        var nameComponent = entity.GetComponent<NameComponent>();
        var inputComponent = inputEntity.GetComponent<InputComponent>();

        Console.WriteLine("what is your name");
        input(inputEntity);
        nameComponent.name = inputComponent.Input;
        Console.WriteLine(nameComponent.name);




    }

    public void SetUp(Entity entity, int health, int swordDamage)
    {
        var healthComponent = entity.GetComponent<HealthComponent>();
        var swordComponent = entity.GetComponent<SwordComponent>();

        healthComponent.Health = health;
        swordComponent.damage = swordDamage;

    }

}

class game
{
    static void Main(string[] args)
    {
        var HealthSystem = new HealthSystem();
        var playSystem = new PlaySystem();


        var playerEntity = new Entity(1);
        playerEntity.AddComponent(new HealthComponent { });
        playerEntity.AddComponent(new SwordComponent { });
        playerEntity.AddComponent(new NameComponent { });
        var healthComponent = playerEntity.GetComponent<HealthComponent>(); 

        var inputEntity = new Entity(2);
        inputEntity.AddComponent(new InputComponent { });
        var inputComponent = inputEntity.GetComponent<InputComponent>(); 

        var monsterEntity = new Entity(3);
        monsterEntity.AddComponent(new HealthComponent { });
        monsterEntity.AddComponent(new SwordComponent { });
        var MhealthComponent = monsterEntity.GetComponent<HealthComponent>();

        playSystem.SetName(playerEntity, inputEntity);

        playSystem.SetUp(playerEntity, 20, 5);

        bool continue1 = true;

        while (continue1)
        {
            playSystem.SetUp(monsterEntity, 10, 2);

            Console.WriteLine("you encounterd an enemy");


            bool isPlaying = true;
            while (isPlaying)
            {
                Console.WriteLine("do you want to attack");
                playSystem.input(inputEntity);
                if (inputComponent.Input == "yes")
                {
                    HealthSystem.TakeDamage(monsterEntity, playerEntity);
                    Console.WriteLine("the monster has " + MhealthComponent.Health + " health left");
                    if (HealthSystem.CheckHealth(monsterEntity) == false)
                    {
                        Console.WriteLine("you killed the monster");
                        Console.WriteLine("do you want to continue");
                        playSystem.input(inputEntity);
                        if (inputComponent.Input == "yes")
                        {
                            isPlaying = false;
                            break;
                        }
                        if (inputComponent.Input == "no")
                        {
                            continue1 = false;
                            break;
                        }


                    }
                }
                if (inputComponent.Input == "no")
                {
                    continue1 = false;
                    break;
                }
                Console.WriteLine("the monster hits back");
                HealthSystem.TakeDamage(playerEntity, monsterEntity);
                Console.WriteLine("your health is now at" + healthComponent.Health);
                if (HealthSystem.CheckHealth(playerEntity) == false)
                {
                    Console.WriteLine("you died");
                    continue1 = false;
                }

            }
        }







    }
}
