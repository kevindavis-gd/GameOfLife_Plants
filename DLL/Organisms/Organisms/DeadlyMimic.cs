using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{

    public class DeadlyMimic : Plant
    {
        int life, size, positionX, positionY, growth;
        static int count = 0;
        /// ******************************************** Properties *********************************
        public override int Count
        {
            get { return count; }
        }
        public override int Life
        {
            get { return life; }
            set { life = value; }
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
        public DeadlyMimic(int x, int y)
        {
            //increase the count
            count++;
            life = 5;
            size = 0;
            PositionX = x;
            PositionY = y;
        }   //Constructor
        public void Eat()
        {
            //if it gets food it can live for 5 generations
            //not compounded, it just resets, it is not added
            life = 5;
            growth += 2;
        }//Eat

        public override void Grow()
        {
            if (growth > 0)
            {
                growth--;
                size++;
            }
        }

        ~DeadlyMimic()
        {
            --count;
        }//destructor
    }//DeadlyMimic 
}
