using System;
using Systems;
using components;
using Entitys;
using System.Collections.Generic;
using System.Reflection.Metadata.Emcma335;

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

