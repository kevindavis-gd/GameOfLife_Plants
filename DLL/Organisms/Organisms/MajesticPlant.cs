using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
    public class MajesticPlant : Actor
    {
        static int count = 0;
        /// ******************************************** Properties *********************************
        public override int Count
        {
            get { return count; }
        }//Count
        /// ******************************************** Methods ************************************
        public MajesticPlant(int x, int y)
        {
            //increase the count
            count++;
            GenerationsToLive = 2;
            PositionX = x;
            PositionY = y;
        }   //Constructor
        public virtual MajesticPlant Pollinate()
        {
            MajesticPlant child = Sprout();
            return child;
        }//Pollinate
        public MajesticPlant Sprout()
        {
            Random rand = new Random();
            MajesticPlant child = new MajesticPlant(rand.Next(4), rand.Next(13));
            return child;
        }//Sprout
        public override string Draw()
        {
            return "P";
        }//Draw
    }//MajesticPlant
}

