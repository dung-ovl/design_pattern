namespace Builder
{
    // Product class
    class Pizza
    {
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public string Topping { get; set; }

        public void Display()
        {
            Console.WriteLine($"Pizza with {Dough} dough, {Sauce} sauce, and {Topping} topping.");
        }
    }

    // Builder interface
    interface IPizzaBuilder
    {
        void BuildDough();
        void BuildSauce();
        void BuildTopping();
        Pizza GetPizza();
    }

    // Concrete builder
    class MargheritaPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public void BuildDough()
        {
            _pizza.Dough = "thin";
        }

        public void BuildSauce()
        {
            _pizza.Sauce = "tomato";
        }

        public void BuildTopping()
        {
            _pizza.Topping = "mozzarella cheese";
        }

        public Pizza GetPizza()
        {
            return _pizza;
        }
    }

    // Director class
    class PizzaMaker
    {
        private IPizzaBuilder _pizzaBuilder;

        public PizzaMaker(IPizzaBuilder pizzaBuilder)
        {
            _pizzaBuilder = pizzaBuilder;
        }

        public void MakePizza()
        {
            _pizzaBuilder.BuildDough();
            _pizzaBuilder.BuildSauce();
            _pizzaBuilder.BuildTopping();
        }

        public Pizza GetPizza()
        {
            return _pizzaBuilder.GetPizza();
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            IPizzaBuilder margheritaPizzaBuilder = new MargheritaPizzaBuilder();
            PizzaMaker pizzaMaker = new PizzaMaker(margheritaPizzaBuilder);

            pizzaMaker.MakePizza();
            Pizza pizza = pizzaMaker.GetPizza();

            pizza.Display();
        }
    }
}