using System.Xml.Linq;

namespace FactoryMethod
{

    public interface IMonster
    {
        string Name { get; set; }
        void Spawn();
        void Attack();
        void Eat();
    }

    public class Zombie : IMonster
    {
        public string Name { get; set; } = "Zombie";
        public void Spawn()
        {
            Console.WriteLine($"Zombie{Name} spawned");
        }

        public void Attack()
        {
            Console.WriteLine($"Zombie{Name} attacked: Death Bite");
        }

        public void Eat()
        {
            Console.WriteLine($"Zombie{Name} ate: Human Flesh");
        }
    }

    public class Skeleton : IMonster
    {

        public string Name { get; set; } = "Skeleton";
        public void Spawn()
        {
            Console.WriteLine($"Skeleton{Name} spawned");
        }

        public void Attack()
        {
            Console.WriteLine($"Skeleton{Name} attacked: Throwing Bone");
        }

        public void Eat()
        {
            Console.WriteLine($"Skeleton{Name} ate: Nothing");
        }
    }

    public abstract class MonsterManager
    {
        public abstract IMonster CreateMonster();
        public IMonster Spawn(string name)
        {
            IMonster monster = CreateMonster();
            monster.Name = name.ToString();
            monster.Spawn();
            return monster;
        }

    }

    public class ZombieManager : MonsterManager
    {
        public override IMonster CreateMonster()
        {
            return new Zombie();
        }
    }

    public class SkeletonManager : MonsterManager
    {
        public override IMonster CreateMonster()
        {
            return new Skeleton();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            MonsterManager zomfactory = new ZombieManager();
            IMonster zom1 = zomfactory.Spawn("1");
            zom1.Attack();
            IMonster zom2 = zomfactory.Spawn("2");
            zom2.Eat();

            MonsterManager skefactory = new SkeletonManager();
            IMonster ske1 = skefactory.Spawn("1");
            ske1.Eat();
            IMonster ske2 = skefactory.Spawn("2");
            ske2.Attack();
        }
    }
}