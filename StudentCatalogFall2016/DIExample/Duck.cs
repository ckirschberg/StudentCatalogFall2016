using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalogFall2016.DIExample
{
    public abstract class Duck
    {
        private IFlyBehaviour flyBehaviour;

        public Duck(IFlyBehaviour fly)
        {
            this.flyBehaviour = fly;
        }

        public void Quack()
        {
            Console.WriteLine("Quack");
        }

        public abstract void Speak();
        
        public void Fly()
        {
            this.flyBehaviour.Fly();
        }

    }
}