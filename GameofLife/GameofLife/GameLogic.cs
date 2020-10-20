using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Organisms;

namespace GameofLife
{
    class GameLogic
    {
        bool autoRun;
        DataStructure Data;

        public DataStructure DataArr
        {
            get { return Data; }
        }
        public bool AutoRun
        {
            get { return autoRun; }
            set { autoRun = value; }
        }

        ///************************************************* Methods *******************************************
        public GameLogic()
        {
        }//constructor

        public void LoadGameLogic (DataStructure D)
        {
             Data = D;
        }

        ///************************************************* Reset Organism Count *******************************************
        public void ResetOrganismCount()
        {
            DataArr.FlyCount = 0;
            DataArr.MajesticCount = 0;
            DataArr.DeadlyCount = 0;
            DataArr.Flies.Clear();
        }


        public Image UpdateGrid(int x, int y, int gridSizeX, int gridSizeY)
        {
            Image ret = null;

            if (DataArr.Actors[x, y] != null)
            {
                //decrement life
                DataArr.Actors[x, y].Life--;
                int switchCase = 0;
                //switches can only use variables
                if (DataArr.Actors[x, y].GetType() == typeof(Organisms.DeadlyMimic))
                    switchCase = 0;
                if (DataArr.Actors[x, y].GetType() == typeof(Organisms.MajesticPlant))
                    switchCase = 1;
                if (DataArr.Actors[x, y].GetType() == typeof(Organisms.Fly))
                    switchCase = 2;


                //switch statement
                switch (switchCase)
                {

                    case 0:
                        if (DataArr.Actors[x, y].Life < 0)
                        {
                            DataArr.Actors[x, y] = null;
                            return null;
                        }

                        ((Organisms.DeadlyMimic)DataArr.Actors[x, y]).Grow();

                        if (((Organisms.DeadlyMimic)DataArr.Actors[x, y]).Size < 1)
                        {
                            ret = GameofLife.Properties.Resources.DeadlyMimic1;
                        }
                        else if (((Organisms.DeadlyMimic)DataArr.Actors[x, y]).Size < 2)
                        {
                            ret = GameofLife.Properties.Resources.DeadlyMimic2;
                        }
                        else
                        {
                            ret = GameofLife.Properties.Resources.DeadlyMimic3;
                        }

                        //Using static Variables
                        DataArr.DeadlyCount = DataArr.Actors[x, y].Count;
                        break;
                    case 1:
                        //plants dont die
                        ((Organisms.MajesticPlant)DataArr.Actors[x, y]).Grow();
                        if (((Organisms.MajesticPlant)DataArr.Actors[x, y]).Size < 1)
                        {
                            ret = GameofLife.Properties.Resources.MajesticPlant1;
                        }
                        else if (((Organisms.MajesticPlant)DataArr.Actors[x, y]).Size < 2)
                        {
                            ret = GameofLife.Properties.Resources.MajesticPlant2;
                        }
                        else
                        {
                            ret = GameofLife.Properties.Resources.MajesticPlant3;
                        }
                        //DataStructure.MajesticCount++;
                        DataArr.MajesticCount = DataArr.Actors[x, y].Count;
                        break;
                    case 2:
                        if (DataArr.Actors[x, y].Life < 0)
                        {
                            DataArr.Actors[x, y] = null;
                            DataArr.Actors[x, y] = null;
                            break;
                        }
                        ret = GameofLife.Properties.Resources.Fly1;
                        //DataStructure.FlyCount++;
                        DataArr.FlyCount = DataArr.Actors[x, y].Count;
                        DataArr.Flies.Add(DataArr.Actors[x, y]);
                        break;
                    default:
                        ret = null;
                        break;
                }
            }//if
            else
            {
                ret = null;
            }

            return ret;
        }



        ///************************************************* Move Flies *******************************************
        public void MoveFlies(int gridSizeX, int gridSizeY)
        {
            int originalX = 0;
            int originalY = 0;
            int newPosX;
            int newPosY;
            //only goes through the list of flies
            for (int x = 0; x < Data.Flies.Count; x++)
            {
                //delete the fly from the 2D array
                Data.Actors[Data.Flies[x].PositionX % gridSizeX, Data.Flies[x].PositionY % gridSizeY] = null;
                //store original values to use incase there is a colision that isnt with a deadly mimic
                originalX = Data.Flies[x].PositionX % gridSizeX;
                originalY = Data.Flies[x].PositionY % gridSizeY;
                //add random number to the object's positions by calling Move()
                ((Fly)Data.Flies[x]).Move();
                //new position mod the grid sizes so that it will wrap around
                newPosX = Data.Flies[x].PositionX % gridSizeX;
                newPosY = Data.Flies[x].PositionY % gridSizeY;

                //if actor position is null skip
                if (Data.Actors[newPosX, newPosY] != null)
                {
                    //if the fly collided with a majestic fly, keep original position
                    if (Data.Actors[newPosX, newPosY].GetType() == typeof(Organisms.MajesticPlant))
                    {
                        ((Fly)Data.Flies[x]).Eat();
                        //create a new plant object
                        Data.AddPlant(((MajesticPlant)Data.Actors[newPosX, newPosY]).Pollinate(), gridSizeX, gridSizeY);
                        //fly eats some of the plant then goes back to its original position
                        Data.Flies[x].PositionX = originalX;
                        Data.Flies[x].PositionY = originalY;
                        Data.Actors[originalX, originalY] = Data.Flies[x];
                    }
                    //if the fly collided with a Deadly Mimic, delete the fly
                    else if (Data.Actors[newPosX, newPosY].GetType() == typeof(Organisms.DeadlyMimic))
                    {
                        //increase the life of deadly mimic
                        ((DeadlyMimic)Data.Actors[newPosX, newPosY]).Eat();
                        //flyCount--;
                        Data.Flies[x] = null;
                    }
                    else if (Data.Actors[newPosX, newPosY].GetType() == typeof(Organisms.Fly))
                    {
                        //fly says hello then goes back to its original position
                        Data.Flies[x].PositionX = originalX;
                        Data.Flies[x].PositionY = originalY;
                        Data.Actors[originalX, originalY] = Data.Flies[x];
                    }
                }//outerIf
                else
                {
                    Data.Actors[newPosX, newPosY] = Data.Flies[x];
                }
            }//for
            //remove all the null items from the fly list
            Data.Flies.RemoveAll(item => item == null);
            System.GC.Collect();
        }//Move

    }//Class Data
}
