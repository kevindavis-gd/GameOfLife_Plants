using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organisms;

namespace GameofLife
{
    class Data
    {
        List<Actor> actors = new List<Actor>();
        Random rand = new Random();

        public List<Actor> Actors
        {
            get { return actors; }
        }

        public Data()
        {
            
        }//constructor

        public void FillList(int flyNum, int deadlyNum, int majesticNum)
        {
            for (int x = 0; x < flyNum; x++)
            {
                actors.Add(new Organisms.Fly(rand.Next(4), rand.Next(13)));
            }
            for (int x = 0; x < deadlyNum; x++)
            {
                actors.Add(new Organisms.DeadlyMimic(rand.Next(4), rand.Next(12)));
            }
            for (int x = 0; x < majesticNum; x++)
            {
                actors.Add(new Organisms.MajesticPlant(rand.Next(4), rand.Next(12)));
            }
        }//FillList
        

        public void AddActor(Actor child)
        {
            actors.Append(child);
        }//AddActor

    }
}
