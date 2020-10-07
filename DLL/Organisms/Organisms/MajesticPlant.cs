using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
    public class MajesticPlant : Actor
    {
        public override void Draw() { }
        public void Pollinate()
        {
            //if it gets food it can live for 2 generations
            //not compounded, it just resets, it is not added
            GenerationsToLive = 2;
        }//Pollinate
    }//MajesticPlant
}

