using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
    public abstract class Plant : Actor
    {

        /// ******************************************** Properties *********************************

        public override int Count //abstract property
        {
            get { return 0; }
        }
        public abstract int Size
        {
            get;
        }
        /// ******************************************** Methods ************************************
        public abstract void Grow();
    }
}
