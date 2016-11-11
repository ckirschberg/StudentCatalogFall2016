﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalogFall2016.DIExample
{
    public class RedheadDuck : Duck
    {
        public RedheadDuck(IFlyBehaviour fly) : base(fly)
        {
            
        }

        public override void Speak()
        {
            Console.WriteLine("I am a redhead duck");
        }
    }
}