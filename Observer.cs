using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsExersice
{

        // ISubject 
        interface IProduct
        {
            // attach observer
            void Subscribe(Customer customer);
            // detach observer
            void Unsubscribe(Customer customer);
            // notification to the subscribers
            void Notify();
        }
        // ConcreteSubject class
        public class Product : IProduct
        {
            string name;
            float basePrice;
            float currentPrice;
            List<Customer> customers = new List<Customer>();

            public Product(string name, float basePrice)
            {
                this.name = name;
                this.basePrice = basePrice;
                this.currentPrice = basePrice;
            }

            public float price
            {
                get
                {
                    return currentPrice;
                }
                set
                {
                    // if price of the laptop will be less than the base price then 
                    // notification will forwarded to the subscribers
                    currentPrice = value;
                    if (value <= basePrice)
                        Notify();
                }
            }
            public void Subscribe(Customer customer)
            {
                customers.Add(customer);
            }

            public void Unsubscribe(Customer customer)
            {
                customers.Remove(customer);
            }

            public void Notify()
            {
                foreach (Customer observer in customers)
                {
                    observer.Update(this);
                }
            }

            public string Name
            {
                get { return name; }
            }

            public float discount
            {
                get { return (basePrice - currentPrice) * 100 / basePrice; }
            }
            public float CurrentPrice
            {
                get { return currentPrice; }
            }
        }
        // IObserver Interface
        interface ICustomer
        {
            void Update(Product product);
        }
        // ConcreteObserver Interface
        public class Customer : ICustomer
        {
            string name;
            public Customer(string name)
            {
                this.name = name;
            }
            public void Update(Product product)
            {
                Console.WriteLine("{0}: {1} Laptop is now available at {2}; Discount = {3}%", this.name, product.Name, product.CurrentPrice, product.discount);
            }
        }

    class Program
    {
        static void Main(string[] args)
        {
            Product Laptop = new Product("DELL", 1000);
            Console.WriteLine("--------Customer 1 and Customer 2 is subscribed to the Laptop Product----------");
            // attach or subscribe customer 1
            Customer Customer1 = new Customer("customer 1");
            Laptop.Subscribe(Customer1);
            // attach or subscribe customer 2
            Customer Customer2 = new Customer("customer 2");
            Laptop.Subscribe(Customer2);

            // publish notification to the subscribers
            Laptop.price = 800;

            Console.WriteLine("--------customer 2 is unsubscribed and customer 3 is subscribed to the Laptop Product----------");
            // customer 2 is unsubscribed and customer 3 is subscribed
            Laptop.Unsubscribe(Customer2);
            Customer Customer3 = new Customer("customer 3");
            Laptop.Subscribe(Customer3);
            Laptop.price = 900;
            Console.ReadLine();
        }
    }
}
