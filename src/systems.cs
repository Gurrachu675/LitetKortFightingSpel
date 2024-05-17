namespace Systems
{
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

}