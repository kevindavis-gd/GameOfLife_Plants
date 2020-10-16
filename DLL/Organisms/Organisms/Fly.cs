using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Organisms
{
    public class Fly : Actor
    {
        int life, positionX, positionY;
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
        /// ******************************************** Methods *********************************
        public Fly(int x, int y)
        {
            //increase the count
            count++;
            life = 5;
            PositionX = x;
            PositionY = y;
        }   //Constructor
        public void Move()
        {
            Random rand = new Random();
            int xpos, ypos;
            //randomize, and if the number is 0, randomize again

            //do while loop
            do
            {
                xpos = rand.Next(-1, 2);
            } while (xpos == 0);
            //randomize, and if the number is 0, randomize again
            do
            {
                ypos = rand.Next(-1, 2);
            } while (ypos == 0);
            PositionX += xpos;
            PositionY += ypos;



            //if position X is negative, multiply by -1
            if (PositionX < 0)
            {
                PositionX *= -1;
            }
            //if position Y is negative, multiply by -1
            if (PositionY < 0)
            {
                PositionY *= -1;
            }
        }//Move
        public void Eat()
        {
            //if it gets food it can live for 5 generations
            life = 5;
        }//Eat
        ~Fly()
        {
            count--;
        }//destructor
    }//Flies
}
