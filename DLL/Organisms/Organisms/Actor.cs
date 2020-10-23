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

namespace Organisms
{
    public abstract class Actor : IActors
    {
        /// ******************************************** Properties *********************************
        public abstract int Life { get; set; }
        public abstract int PositionX { get; set; }
        public abstract int PositionY { get; set; }
        public abstract int Count //abstract property
        {
            get;
        }
        public abstract int Size
        {
            get;
        }
        public abstract string Name
        {
            get;
        }

        /// ******************************************** Methods *********************************
        public abstract void Grow();
        public abstract MajesticPlant Pollinate();
        public virtual void Eat() { }
        public virtual void Move() { }

    }//Actor
}
