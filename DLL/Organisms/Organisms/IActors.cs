using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
    interface IActors
    {
        int Life { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        int Count //abstract property
        {
            get;
        }
    }
}
