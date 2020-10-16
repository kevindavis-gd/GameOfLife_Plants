﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Organisms
{

    public abstract class Actor
    {
        /// ******************************************** Properties *********************************
        public abstract int Life { get; }
        public abstract int PositionX { get; set; }
        public abstract int PositionY { get; set; }
        public abstract int Count //abstract property
        {
            get;
        }
        /// ******************************************** Methods ************************************
    }//Actor
}
