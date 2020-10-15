using System;
using System.CodeDom.Compiler;
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
        Actor[,] actors;
        Random rand;
        int organismCount;
        ///************************************************* Properties *******************************************
        public Actor[,] Actors
        {
            get { return actors; }
        }
        ///************************************************* Methods *******************************************
        public Data()
        {
            organismCount = 0;
            rand = new Random();
        }//constructor
        public void Fill2DArray(int flyNum, int deadlyNum, int majesticNum, int gridSizeX, int gridSizeY)
        {
            //create array the same size as the grid
            actors = new Actor[gridSizeX, gridSizeY];
            Actor temp;
            //Create the number of flys
            for (int x = 0; x < flyNum; x++)
            {
                temp = new Organisms.Fly(rand.Next(gridSizeX), rand.Next(gridSizeY));
                //inset organism randomly into the actors 2D array
                RandomInsert(temp, gridSizeX, gridSizeY);
            }
            for (int x = 0; x < deadlyNum; x++)
            {
                temp = new Organisms.DeadlyMimic(rand.Next(gridSizeX), rand.Next(gridSizeY));
                RandomInsert(temp, gridSizeX, gridSizeY);
            }
            for (int x = 0; x < majesticNum; x++)
            {
                temp = new Organisms.MajesticPlant(rand.Next(gridSizeX), rand.Next(gridSizeY));
                RandomInsert(temp, gridSizeX, gridSizeY);
            }
        }//Fill2DArray
        public void AddPlant(MajesticPlant child, int gridSizeX, int gridSizeY)
        {
            RandomInsert(child, gridSizeX, gridSizeY);
        }//AddActor
        public void RandomInsert(Actor temp, int gridSizeX, int gridSizeY)
        {
            if (organismCount < gridSizeX * gridSizeY)
            {
                //while the array position is taken, randomize object's position
                while (actors[temp.PositionX, temp.PositionY] != null)
                {
                    //randomize position of object's X and Y position
                    temp.PositionX = rand.Next(gridSizeX);
                    temp.PositionY = rand.Next(gridSizeY);
                }//while
                 //place the object in the actors array based on its position
                actors[temp.PositionX, temp.PositionY] = temp;
                //increment organism count
                organismCount++;
            }//if
        }//RandomInsert
    }
}
