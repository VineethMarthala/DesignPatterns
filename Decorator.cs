using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Decorator
{

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    //Component class
    public abstract class OrderBase
    {
        protected List<Product> products = new List<Product>
        {
            new Product {Name="Phone",Price=1000},
            new Product { Name="Tablet",Price=5000},
            new Product { Name="IPod", Price=10000}
        };

        public abstract double CalculateTotalOrderPrice();
    }

    //Concreet Component1
    public class RegularOrder : OrderBase
    {
        public override double CalculateTotalOrderPrice()
        {
            return products.Sum(x => x.Price);
        }
    }

    //Concreet Component2
    public class PreOrder : OrderBase
    {
        public override double CalculateTotalOrderPrice()
        {
            return products.Sum(x => x.Price) * 0.9;
        }
    }

    //Decorator Class
    public class OrderDecorator : OrderBase
    {
        protected OrderBase order;

        public OrderDecorator(OrderBase order)
        {
            this.order = order;
        }

        public override double CalculateTotalOrderPrice()
        {
            return order.CalculateTotalOrderPrice();
        }
    }

    //Concreate Decorator
    public class PremiumPreOrder : OrderDecorator
    {
        public PremiumPreOrder(OrderBase order) : base(order)
        {

        }

        public override double CalculateTotalOrderPrice()
        {
            var preOrderPrice =  base.CalculateTotalOrderPrice();

            return preOrderPrice * 0.9;
        }
    }


    class Decorator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------Decorator-------------");
            var regularOrder = new RegularOrder();
            Console.WriteLine("Reqular Order : "+regularOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var preOrder = new PreOrder();
            Console.WriteLine("Pre Order : "+ preOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var premiunPreOrder = new PremiumPreOrder(preOrder);
            Console.WriteLine("Premium Pre order Price : " + premiunPreOrder.CalculateTotalOrderPrice());
            Console.ReadKey();

            Console.WriteLine("---------SingleTon-------------");
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            // Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
            // Wait for user
            Console.ReadKey();

            Console.WriteLine("-----------------Factory Method------------");

            Console.WriteLine("App: Launched with the ConcreteCreator1.");
            ClientCode(new ConcreteCreator1());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreteCreator2.");
            ClientCode(new ConcreteCreator2());
            Console.ReadKey();

        }

        public static void ClientCode(Creator creator)
        {
            // ...
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
            // ...
        }
    }

   
}
