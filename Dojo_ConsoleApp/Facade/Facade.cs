﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dojo_ConsoleApp.Facade.Dumbass.Keepgoing.Freakazoid
{
    class Facade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            _one.MethodOne();
            _two.MethodTwo();
            
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
                _two.MethodTwo();
                _three.MethodThree();
                _four.MethodFour();
         
        }
    }
}
