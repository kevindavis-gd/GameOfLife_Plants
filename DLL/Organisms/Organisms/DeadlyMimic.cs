using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
    public class DeadlyMimic : Actor
    {
        static int count = 0;
        Random rand;
        private int generationsToLive = 0; //number of iterations to live
        private int positionX, positionY = 0; // location on screen

        /// ******************************************** Properties *********************************
        public override int GenerationsToLive
        {
            get { return generationsToLive; }
            set { generationsToLive = value; }
        }//GenerationsToLive
        public override int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }//PositionX
        public override int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }//PositionY
        public int Count
        {
            get { return count; }
        }//Count

        /// ******************************************** Methods ************************************
        public DeadlyMimic(int x, int y)
        {
            
            //increase the count
            count++;
            GenerationsToLive = 2;
            positionX = x;
            positionY = y;
        }   //Constructor

        public override void Move(int x, int y)
        {
            positionX = x;
            positionY = y;
        }//Move

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
