using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalogFall2016.DIExample
{
    public class RubberDuck : Duck
    {
        public RubberDuck(IFlyBehaviour fly) : base(fly)
        {
        }

        public override void Speak()
        {
            Console.WriteLine("Squick");
        }
    }
}