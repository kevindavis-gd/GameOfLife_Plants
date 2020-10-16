using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Organisms;

namespace GameofLife
{
    class Data
    {
        Actor[,] actors; //= new Actor[5, 5];
        Random rand;
        int organismCount;
        int deadlyCount, flyCount, majesticCount;
        public List<Actor> Flies = new List<Actor>();
        ///************************************************* Properties *******************************************
        public int DeadlyCount
        {
            get { return deadlyCount; }
        }
        public int FlyCount
        {
            get { return flyCount; }
        }
        public int MajesticCount
        {
            get { return majesticCount; }
        }
        public int OrganismCount
        {
            get { return organismCount; }
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

        public void OrganismCountInitilize(int Deadly, int Fly, int Plant)
        {
            deadlyCount = Deadly;
            flyCount = Fly;
            majesticCount = Plant;
            organismCount = Deadly + Fly + Plant;
        }
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
            if (organismCount < gridSizeX * gridSizeY)
            {
                majesticCount++;
                organismCount++;
                //randomly insert child onto grid
                RandomInsert(child, gridSizeX, gridSizeY);
            }
            else 
            {
                Console.WriteLine("full");
                child = null;
            }
        }//AddPlant
        ///************************************************* Random Insert *******************************************
        public void RandomInsert(Actor temp, int gridSizeX, int gridSizeY)
        {   //if the grid can hold more organisms
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
            }//if
            else
            {
                temp = null;
            }
        }//RandomInsert
        ///************************************************* Move *******************************************
        public void Move(int gridSizeX, int gridSizeY)
        {
            int originalX = 0;
            int originalY = 0;
            int newPosX;
            int newPosY;
            for (int x = 0; x < Flies.Count; x++)
            {
                //decrement life ??????????????????????????????????????????????????????
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

                if (actors[newPosX, newPosY] != null)
                {
                    
                    if (actors[newPosX, newPosY].GetType() == typeof(Organisms.MajesticPlant))
                    {
                        Console.WriteLine("Plant");
                        ((Fly)Flies[x]).Eat();
                        //fly eats some of the plant then goes back to its original position
                        Flies[x].PositionX = originalX;
                        Flies[x].PositionY = originalY;
                        actors[originalX, originalY] = Flies[x];
                        AddPlant(((MajesticPlant)actors[newPosX, newPosY]).Pollinate(), gridSizeX, gridSizeY);

                    }
                    else if (actors[newPosX, newPosY].GetType() == typeof(Organisms.DeadlyMimic))
                    {
                        Console.WriteLine("Deadly");
                        ((DeadlyMimic)actors[newPosX, newPosY]).Eat();
                        flyCount--;
                        Flies[x] = null;
                        //current 2D Actor cell will have a Mimic in it
                    }
                    else if (actors[newPosX, newPosY].GetType() == typeof(Organisms.Fly))
                    {
                        Console.WriteLine("Fly");
                        //fly says hello then goes back to its original position
                        Flies[x].PositionX = originalX;
                        Flies[x].PositionY = originalY;
                        actors[originalX, originalY] = Flies[x];
                    }
                }
                else
                {
                    Console.WriteLine("Else");
                    actors[newPosX, newPosY] = Flies[x];
                }
            }//for
            //remove all the null items from the fly list
            Flies.RemoveAll(item => item == null);
            //System.GC.Collect();
        }//Move
    }//Class Data
}
