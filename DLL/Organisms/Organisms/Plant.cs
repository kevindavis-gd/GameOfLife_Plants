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
            get;
        }
        public override int Size
        {
            get;
        }
        
    }
}
