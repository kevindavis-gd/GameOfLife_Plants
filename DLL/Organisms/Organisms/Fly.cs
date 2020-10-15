using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Organisms
{
    public class Fly : Actor
    {
        static int count = 0;
        /// ******************************************** Properties *********************************
        public override int Count
        {
            get { return count; }
        }//Count

        /// ******************************************** Methods *********************************
        public Fly(int x, int y)
        {
            //increase the count
            count++;
            GenerationsToLive = 5;
            PositionX = x;
            PositionY = y;
        }   //Constructor
        public void Move(int x, int y)
        {
            PositionX += x;
            PositionY += y;
        }//Move

        public void Eat()
        {
            //if it gets food it can live for 5 generations
            GenerationsToLive = 5;
        }//Eat
        public override string Draw()
        {
            return "F";
        }//Draw
    }//Flies
}
