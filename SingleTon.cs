using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
  
 
    /// The 'Singleton' class
    public class Singleton
    {
        static Singleton instance;
        // Constructor is 'protected'
        protected Singleton()
        {
        }
        public static Singleton Instance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
