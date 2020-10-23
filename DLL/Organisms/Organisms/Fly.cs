////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Name: Kevin Davis 
// Class : CMPS4143
// Assignment: Program 5
// Date: 10/23/2020
//
// Description :
// To create a library (dll) of critters; to instantiate objects of classes in an inheritance hierarchy and 
// polymorphically output each object’s attributes; to use static variables; to use a labels, text boxes and buttons;
// to use the switch statement; to use exception handling; to use a data structure to hold references to objects.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace Organisms
{
    public class Fly : Actor, IInsect
    {
        int life, positionX, positionY;
        string name;
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
        public override int Size
        {
            get;
        }
        public override string Name
        {
            get { return name; }
        }
        /// ******************************************** Methods *********************************
        public Fly(int x, int y)
        {
            //increase the count
            count++;
            life = 5;
            PositionX = x;
            PositionY = y;
            name = "Fly";
        }   //Constructor
        public override void Move()
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
        public override void Eat()
        {
            //if it gets food it can live for 5 generations
            life = 5;
        }//Eat

        public override MajesticPlant Pollinate() { return null; }
        public override void Grow() { }
        
        //teleport :)
        public void FlyAway()
        {
            Random rand = new Random();
            int xpos, ypos;
            //randomize, and if the number is 0, randomize again

            //do while loop
            do
            {
                xpos = rand.Next(-1, 4);
            } while (xpos == 0);
            //randomize, and if the number is 0, randomize again
            do
            {
                ypos = rand.Next(-1, 4);
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

        }//fly/teleport

        ~Fly()
        {
            count--;
        }//destructor
    }//Flies
}
