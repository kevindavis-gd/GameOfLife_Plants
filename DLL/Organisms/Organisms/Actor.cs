using System;
using System.Collections.Generic;
using System.Text;

namespace Organisms
{
    public abstract class Actor
    {
        private int generationsToLive = 0;
        private int positionX, positionY = 0;
        //virtial methods
        public virtual void Move() { }
        public virtual void Die() { }
        //Abstract methods
        public abstract void Draw();


        public virtual int PositionX
        {
            get;
            set;
        }
        public virtual int PositionY
        {
            get;
            set;
        }
        public virtual int GenerationsToLive
        {
            get;
            set;
        }

    }//Actor
}
