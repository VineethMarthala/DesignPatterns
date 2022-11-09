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


    class Program
    {
        static void Main(string[] args)
        {
            var regularOrder = new RegularOrder();
            Console.WriteLine("Reqular Order : "+regularOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var preOrder = new PreOrder();
            Console.WriteLine("Pre Order : "+ preOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var premiunPreOrder = new PremiumPreOrder(preOrder);
            Console.WriteLine("Premium Pre order Price : " + premiunPreOrder.CalculateTotalOrderPrice());

        }
    }
}
