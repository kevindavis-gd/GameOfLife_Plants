using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Organisms
{
   
    public abstract class Actor
    {
        private int generationsToLive; //number of iterations to live
        private int positionX, positionY; // location on screen

        /// ******************************************** Properties *********************************
        public int GenerationsToLive
        {
            get { return generationsToLive; }
            set { generationsToLive = value; }
        }//GenerationsToLive
        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }//PositionX
        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }//PositionY
        public abstract int Count
        {
            get;
        }
        /// ******************************************** Methods ************************************

        public abstract string Draw();

    }//Actor
}
