using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsExersice
{
   
        // AbstractProductA interface
        interface ILaptop
        {
            string Name();
        }
        // ProductA1
        class GamingLaptop : ILaptop
        {
            public string Name()
            {
                return "Gaming Laptop";
            }
        }
        // ProductA2
        class NormalLaptop : ILaptop
        {
            public string Name()
            {
                return "Normal Laptop";
            }
        }
        // AbstractProductB interface
        interface IDesktop
        {
            string Name();
        }
        // ProductB1
        class GamingDesktop : IDesktop
        {
            public string Name()
            {
                return "Gaming Desktop";
            }
        }
        // ProductB2
        class NormalDesktop : IDesktop
        {
            public string Name()
            {
                return "Normal Desktop";
            }
        }
        // AbstractFactory interface
        interface IComputerFactory
        {
            ILaptop GetLaptop(string laptopType);
            IDesktop GetDesktop(string desktopType);
        }
        // ConcreteFactoryA
        class LenovoFactory : IComputerFactory
        {
            public ILaptop GetLaptop(string laptopType)
            {
                switch (laptopType)
                {
                    case "Gaming":
                        return new GamingLaptop();
                    case "Normal":
                        return new NormalLaptop();
                    default:
                        throw new ApplicationException(laptopType + "type can not be created");
                }
            }
            public IDesktop GetDesktop(string DesktopType)
            {
                switch (DesktopType)
                {
                    case "Gaming":
                        return new GamingDesktop();
                    case "Normal":
                        return new NormalDesktop();
                    default:
                        throw new ApplicationException(DesktopType + "type can not be created");
                }
            }
        }

        // ConcreteFactoryB
        class DellFactory : IComputerFactory
        {
            public ILaptop GetLaptop(string laptopType)
            {
                switch (laptopType)
                {
                    case "Gaming":
                        return new GamingLaptop();
                    case "Normal":
                        return new NormalLaptop();
                    default:
                        throw new ApplicationException(laptopType + "type can not be created");
                }
            }
            public IDesktop GetDesktop(string DesktopType)
            {
                switch (DesktopType)
                {
                    case "Gaming":
                        return new GamingDesktop();
                    case "Normal":
                        return new NormalDesktop();
                    default:
                        throw new ApplicationException(DesktopType + "type can not be created");
                }
            }
        }

        // Client class
        class ComputerClient
        {
            ILaptop laptop;
            IDesktop desktop;

            public ComputerClient(IComputerFactory computerFactory, string computerType)
            {
                laptop = computerFactory.GetLaptop(computerType);
                desktop = computerFactory.GetDesktop(computerType);
            }

            public string GetLaptopName()
            {
                return laptop.Name();
            }

            public string GetDesktopName()
            {
                return desktop.Name();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                IComputerFactory lenovoFactory = new LenovoFactory();
                IComputerFactory dellFactory = new DellFactory();

                Console.WriteLine("--------- Lenovo Products --------------------------");
                ComputerClient lenovoClient = new ComputerClient(lenovoFactory, "Gaming");
                Console.WriteLine(lenovoClient.GetLaptopName());
                Console.WriteLine(lenovoClient.GetDesktopName());

                lenovoClient = new ComputerClient(lenovoFactory, "Normal");
                Console.WriteLine(lenovoClient.GetLaptopName());
                Console.WriteLine(lenovoClient.GetDesktopName());

                Console.WriteLine("--------- Dell Products --------------------------");
                ComputerClient dellClient = new ComputerClient(dellFactory, "Gaming");
                Console.WriteLine(dellClient.GetLaptopName());
                Console.WriteLine(dellClient.GetDesktopName());

                dellClient = new ComputerClient(dellFactory, "Normal");
                Console.WriteLine(dellClient.GetLaptopName());
                Console.WriteLine(dellClient.GetDesktopName());

                Console.ReadLine();

            
        }
    }
}
