using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
    public class Fly : Actor
    {
        public override void Draw() { }
        public void Eat()
        {
            //if it gets food it can live for 1 generations
            //not compounded, it just resets, it is not added
            GenerationsToLive = 1;
        }//Eat
    }//Flies
}
