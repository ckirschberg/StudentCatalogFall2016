using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentCatalogFall2016.DIExample;

namespace StudentCatalogFall2016.Tests.DIExample
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MallardDuck mallard = new MallardDuck(new CanFly());
            RedheadDuck redhead = new RedheadDuck(new CanFly());

            RubberDuck rubberDuck = new RubberDuck(new NoFly());

            mallard.Quack();
            mallard.Speak();
            mallard.Fly();
            Console.WriteLine("-------------------");

            redhead.Quack();
            redhead.Speak();
            redhead.Fly();

            Console.WriteLine("-------------------");

            rubberDuck.Quack();
            rubberDuck.Speak();
            rubberDuck.Fly();

        }
    }
}
