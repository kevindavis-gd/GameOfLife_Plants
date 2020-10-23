////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Name: Kevin Davis 
// Class : CMPS4143
// Assignment: Program 5
// Date: 10/23/2020
//
// Description :
// To create a library (dll) of critters; to instantiate objects of classes in an inheritance hierarchy and 
// polymorphically output each object’s attributes; to use static variables; to use a labels, text boxes and buttons;
// to use the switch statement; to use exception handling; to use a data structure to hold references to objects.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using Organisms;

namespace GameofLife
{
    class DataStructure
    {
        Actor[,] actors;
        Random rand;
        int deadlyCount, flyCount, majesticCount;
        private List<Actor> flies = new List<Actor>();
        ///************************************************* Properties *******************************************
        ///
        public List<Actor> Flies
        {
            get
            {
                return flies;
            }
        }
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
            get
            {
                //only get, no set
                return actors;
            }
        }
        ///************************************************* Methods ***************************************************
        public DataStructure()
        {
            rand = new Random();
        }//constructor

        public DataStructure(int gridSizeX, int gridSizeY)
        {
            actors = new Actor[gridSizeX, gridSizeY];
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

        //******************************** Load Single Actor from Picture Grid ********************
        public void LoadSingleActorfromPictureGrid(string name, int x, int y, int gridSizeX, int gridSizeY )
        {
            
           int a = int.Parse(name);
           //switch
            switch (a)
            {
                case 1:
                    Actors[x, y] = new Organisms.Fly(x, y);
                    break;
                case 2:
                    Actors[x, y] = new Organisms.DeadlyMimic(x, y);
                    break;
                case 3:
                    Actors[x, y] = new Organisms.MajesticPlant(x, y);
                    break;
            }
        }

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
    }
}
