using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
    public class DeadlyMimic : Actor
    {
        static int mycount = 0;
        /// ******************************************** Properties *********************************
        public override int Count
        {
            get { return mycount; }
        }//Count

        /// ******************************************** Methods ************************************
        public DeadlyMimic(int x, int y)
        {
            //increase the count
            mycount++;
            GenerationsToLive = 2;
            PositionX = x;
            PositionY = y;
        }   //Constructor
        public void Eat()
        {
            //if it gets food it can live for 5 generations
            //not compounded, it just resets, it is not added
            GenerationsToLive = 5;
        }//Eat
        
        public override string Draw()
        {
            return "P";
        }//Draw

    }//DeadlyMimic 
}
