namespace AbstractFactory
{
    using System;

    // Abstract Product A
    interface ITransport
    {
        void Deliver();
    }

    // Concrete Product A1
    class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by truck");
        }
    }

    // Concrete Product A2
    class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by ship");
        }
    }

    // Abstract Product B
    interface IWarehouse
    {
        void Store();
    }

    // Concrete Product B1
    class Warehouse : IWarehouse
    {
        public void Store()
        {
            Console.WriteLine("Storing in warehouse");
        }
    }

    // Concrete Product B2
    class RefrigeratedWarehouse : IWarehouse
    {
        public void Store()
        {
            Console.WriteLine("Storing in refrigerated warehouse");
        }
    }

    // Abstract Factory
    interface ILogisticsFactory
    {
        ITransport CreateTransport();
        IWarehouse CreateWarehouse();
    }

    // Concrete Factory 1
    class RoadLogisticsFactory : ILogisticsFactory
    {
        public ITransport CreateTransport()
        {
            return new Truck();
        }

        public IWarehouse CreateWarehouse()
        {
            return new Warehouse();
        }
    }

    // Concrete Factory 2
    class SeaLogisticsFactory : ILogisticsFactory
    {
        public ITransport CreateTransport()
        {
            return new Ship();
        }

        public IWarehouse CreateWarehouse()
        {
            return new RefrigeratedWarehouse();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Client code
            ILogisticsFactory factory;

            // Create a road logistics factory
            factory = new RoadLogisticsFactory();
            Console.WriteLine("Road logistics:");
            Console.WriteLine("Transport:");
            var truck = factory.CreateTransport();
            truck.Deliver();
            Console.WriteLine("Warehouse:");
            var warehouse = factory.CreateWarehouse();
            warehouse.Store();

            Console.WriteLine();

            // Create a sea logistics factory
            factory = new SeaLogisticsFactory();
            Console.WriteLine("Sea logistics:");
            Console.WriteLine("Transport:");
            var ship = factory.CreateTransport();
            ship.Deliver();
            Console.WriteLine("Warehouse:");
            var refrigeratedWarehouse = factory.CreateWarehouse();
            refrigeratedWarehouse.Store();
        }
    }

}