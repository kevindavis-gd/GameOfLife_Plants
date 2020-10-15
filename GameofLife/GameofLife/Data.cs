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
        Actor[,] actors = new Actor[5,5];
        Random rand;
        int organismCount;
        public List<Actor> Flies = new List<Actor>();
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
                Flies.Add(temp);
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

        
        public void Move(int gridSizeX, int gridSizeY)
        {
            foreach ( var fly in Flies)
            {
                Console.WriteLine("Stage 1");

                actors[fly.PositionX % gridSizeX, fly.PositionY % gridSizeY] = null;

                int xpos;
                do
                {
                    xpos = rand.Next(-1, 2);
                } while (xpos == 0);

                int ypos;
                do
                {
                    ypos = rand.Next(-1, 2);
                } while (ypos == 0);

                fly.PositionX += xpos;
                fly.PositionY += ypos;

                if (fly.PositionX < 0)
                {
                    fly.PositionX *= -1;
                    Console.WriteLine("Convert");
                }


                if (fly.PositionY < 0)
                {
                    fly.PositionY *= -1;
                    Console.WriteLine("Convert");
                }


                Console.WriteLine("X: " + xpos + "....... " + fly.PositionX);
                Console.WriteLine("Y: " + ypos + "......." +fly.PositionY);

                //place actor into its new position mod the grid sizes so that it will wrap around
                actors[fly.PositionX % gridSizeX, fly.PositionY % gridSizeY] = fly;

                Console.WriteLine("Stage 2");
            }
            /*
             for (int x = 0; x < gridSizeX; x++)
             {
                 for (int y = 0; y < gridSizeY; y++)
                 {
                     if (actors[x, y] != null && actors[x, y].GetType() == typeof(Organisms.Fly))
                     {
                         step++;
                         // copy actor to a temperory object
                         Actor temp = actors[x, y];
                         //set actor in array to null
                         actors[x, y] = null;
                         temp.PositionX +=rand.Next(-1, 2) % gridSizeX;
                         temp.PositionY +=rand.Next(-1, 2) % gridSizeY;
                         Console.WriteLine();
                         Console.Write("X:" + temp.PositionX);
                         Console.Write(",");
                         Console.Write("Y:" + temp.PositionY + " " + step + " Steps");

                         //place actor into its new position mod the grid sizes so that it will wrap around
                         actors[temp.PositionX, temp.PositionY] = temp;

                     }

                 }//innerFor
             }//outerFor
            */
        }
    }//Class Data
}
