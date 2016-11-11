using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCatalogFall2016.DIExample
{
    public class NoFly : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("Oh no, I am falling");
        }
    }
}
