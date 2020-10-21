using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

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
