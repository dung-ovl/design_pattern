namespace Bridge
{

    interface IEnchantment
    {
        string Apply();
    }

    class Fire : IEnchantment
    {
        public string Apply()
        {
            return  ("Fire Element applied: Burn");
        }
    }

    class Ice : IEnchantment
    {
        public string Apply()
        {
            return ("Ice Element applied: Freeze");
        }
    }

    abstract class Weapon
    {
        protected IEnchantment enchantment;
        public Weapon(IEnchantment enchantment)
        {
            this.enchantment = enchantment;
        }
        public virtual string Attack()
        {
            return enchantment.Apply();
        }
    }

    class Sword : Weapon
    {
        public Sword(IEnchantment enchantment) : base(enchantment)
        {
        }

        public override string Attack()
        {
            return ($"Sword Attack: Swing <{base.Attack()}>");
        }
    }
    class Bow : Weapon
    {
        public Bow(IEnchantment enchantment) : base(enchantment)
        {
        }

        public override string Attack()
        {
            return ($"Bow Attack: Shoot <{base.Attack()}>");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnchantment fire = new Fire();
            IEnchantment ice = new Ice();

            Weapon sword = new Sword(fire);
            Weapon bow = new Bow(ice);

            System.Console.WriteLine(sword.Attack());
            System.Console.WriteLine(bow.Attack());
      
        }
    }
}