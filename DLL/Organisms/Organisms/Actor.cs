using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Organisms
{
    public abstract class Actor:IActors
    {
        /// ******************************************** Properties *********************************
        public abstract int Life { get; set; }
        public abstract int PositionX { get; set; }
        public abstract int PositionY { get; set; }
        public abstract int Count //abstract property
        {
            get;
        }
    }//Actor
}
