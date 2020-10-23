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
    public class MajesticPlant : Plant
    {
        int life, size, positionX, positionY, growth;
        string name;
        static int count = 0;
        /// ******************************************** Properties *********************************
        public override int Count
        {
            get { return count; }
        }
        public override int Life
        {
            set { life = value; }
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
        public override string Name
        {
            get { return name; }
        }
        /// ******************************************** Methods ************************************
        public MajesticPlant(int x, int y)
        {
            //increase the count
            count++;
            life = 1000;//can live forever
            size = 0;
            PositionX = x;
            PositionY = y;
            name = "MajesticPlant";
        }   //Constructor
        public override MajesticPlant Pollinate()
        {
            growth += 2;
            MajesticPlant child = new MajesticPlant(0, 0);//sprout
            Console.WriteLine("Majestic Born " + count);
            return child;
        }//Pollinate

        public override void Grow()
        {
            if(growth > 0)
            {
                growth--;
                size++;
            }
        }
  
        ~MajesticPlant()
        {
            --count;
        }//destructor
    }//MajesticPlant
}

