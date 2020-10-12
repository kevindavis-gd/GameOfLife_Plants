using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
   
    public abstract class Actor
    {
        //public static int gridrows;
        //public static int gridcols;
        //private int generationsToLive; //number of iterations to live
       // private int positionX, positionY; // location on screen

        /// ******************************************** Properties *********************************
        public abstract int GenerationsToLive
        {
            get;
            set;
        }
        public abstract int PositionX
        {
            get;
            set;
        }
        public abstract int PositionY
        {
            get;
            set;
        }
        /// ******************************************** Methods ************************************

        //virtial methods
        public virtual void Move(int x, int y)
        {
        }//Move
        public abstract string Draw();



    }//Actor
}
