using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalogFall2016.DIExample
{
    public class CanFly : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("Wuhuuu, I am flying!");
        }
    }
}