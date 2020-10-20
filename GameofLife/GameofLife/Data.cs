using System;
using System.Collections.Generic;
using Organisms;

namespace GameofLife
{
    class Data
    {
        Actor[,] actors;
        Random rand;
        int deadlyCount, flyCount, majesticCount;
        public List<Actor> Flies = new List<Actor>();
        ///************************************************* Properties *******************************************
        public int DeadlyCount
        {
            get { return deadlyCount; }
            set { deadlyCount = value; }
        }
        public int FlyCount
        {
            get { return flyCount; }
            set { flyCount = value; }
        }
        public int MajesticCount
        {
            get { return majesticCount; }
            set { majesticCount = value; }
        }

        public Actor[,] Actors
        {
            get { return actors; }
        }
        ///************************************************* Methods *******************************************
        public Data()
        {
            rand = new Random();
        }//constructor

        ///************************************************* Fill 2D Array *******************************************

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
        ///************************************************* Add Plant *******************************************
        public void AddPlant(MajesticPlant child, int gridSizeX, int gridSizeY)
        {
            //randomly insert child onto grid
            RandomInsert(child, gridSizeX, gridSizeY);

        }//AddPlant
        ///************************************************* Random Insert *******************************************
        public void RandomInsert(Actor temp, int gridSizeX, int gridSizeY)
        {   //if the grid can hold more organisms
            if (deadlyCount + flyCount + majesticCount < gridSizeX * gridSizeY)
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
            }//if
            else
            {
                temp = null;
            }
        }//RandomInsert
        ///************************************************* Move Flies *******************************************
        public void MoveFlies(int gridSizeX, int gridSizeY)
        {
            int originalX = 0;
            int originalY = 0;
            int newPosX;
            int newPosY;
            //only goes through the list of flies
            for (int x = 0; x < Flies.Count; x++)
            {
                //delete the fly from the 2D array
                actors[Flies[x].PositionX % gridSizeX, Flies[x].PositionY % gridSizeY] = null;
                //store original values to use incase there is a colision that isnt with a deadly mimic
                originalX = Flies[x].PositionX % gridSizeX;
                originalY = Flies[x].PositionY % gridSizeY;
                //add random number to the object's positions by calling Move()
                ((Fly)Flies[x]).Move();
                //new position mod the grid sizes so that it will wrap around
                newPosX = Flies[x].PositionX % gridSizeX;
                newPosY = Flies[x].PositionY % gridSizeY;

                //if actor position is null skip
                if (actors[newPosX, newPosY] != null)
                {
                    //if the fly collided with a majestic fly, keep original position
                    if (actors[newPosX, newPosY].GetType() == typeof(Organisms.MajesticPlant))
                    {
                        ((Fly)Flies[x]).Eat();
                        //create a new plant object
                        AddPlant(((MajesticPlant)actors[newPosX, newPosY]).Pollinate(), gridSizeX, gridSizeY);
                        //fly eats some of the plant then goes back to its original position
                        Flies[x].PositionX = originalX;
                        Flies[x].PositionY = originalY;
                        actors[originalX, originalY] = Flies[x];
                    }
                    //if the fly collided with a Deadly Mimic, delete the fly
                    else if (actors[newPosX, newPosY].GetType() == typeof(Organisms.DeadlyMimic))
                    {
                        //increase the life of deadly mimic
                        ((DeadlyMimic)actors[newPosX, newPosY]).Eat();
                        //flyCount--;
                        Flies[x] = null;
                    }
                    else if (actors[newPosX, newPosY].GetType() == typeof(Organisms.Fly))
                    {
                        //fly says hello then goes back to its original position
                        Flies[x].PositionX = originalX;
                        Flies[x].PositionY = originalY;
                        actors[originalX, originalY] = Flies[x];
                    }
                }//outerIf
                else
                {
                    actors[newPosX, newPosY] = Flies[x];
                }
            }//for
            //remove all the null items from the fly list
            Flies.RemoveAll(item => item == null);
            System.GC.Collect();
        }//Move

    }//Class Data
}
