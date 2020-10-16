using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
    public class MajesticPlant : Plant
    {
        int life, size, positionX, positionY;
        static int count = 0;
        /// ******************************************** Properties *********************************
        public override int Count
        {
            get { return count; }
        }
        public override int Life
        {
            get { return life; }
        }
        public override int Size
        {
            get { return size; }
        }

        public override int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        public override int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
        /// ******************************************** Methods ************************************
        public MajesticPlant(int x, int y)
        {
            //increase the count
            count++;
            life = 2;//can live forever
            size = 0;
            PositionX = x;
            PositionY = y;
        }   //Constructor
        public MajesticPlant Pollinate()
        {
            MajesticPlant child = new MajesticPlant(0, 0);//sprout
            return child;
        }//Pollinate

        public override void Grow()
        {
            size++;
        }
        ~MajesticPlant()
        {
            count--;
        }//destructor
    }//MajesticPlant
}

